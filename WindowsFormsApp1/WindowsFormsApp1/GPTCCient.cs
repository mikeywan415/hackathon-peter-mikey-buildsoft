using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class GPTClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = ""; // Replace with your real API key

    public GPTClient()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
    }

    public async Task<string> AskGPTAsync(string prompt)
    {
        var requestBody = new
        {
            model = "gpt-3.5-turbo", // Or gpt-4 if you have access
            messages = new[]
            {
                new { role = "user", content = prompt }
            }
        };

        var jsonRequest = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
        var responseString = await response.Content.ReadAsStringAsync();

        JsonDocument json = JsonDocument.Parse(responseString);
        return json.RootElement
                   .GetProperty("choices")[0]
                   .GetProperty("message")
                   .GetProperty("content")
                   .GetString()
                   .Trim();
    }

    public async Task<bool?> AnalyzeImageAsync(string imagePath, string question)
    {
        if (!File.Exists(imagePath)) return null;

        byte[] imageBytes = File.ReadAllBytes(imagePath);
        string base64Image = Convert.ToBase64String(imageBytes);

        var visionRequest = new
        {
            model = "gpt-4o",
            messages = new[]
            {
                new
                {
                    role = "user",
                    content = new object[]
                    {
                        new { type = "text", text = question + " Respond only with true or false." },
                        new
                        {
                            type = "image_url",
                            image_url = new
                            {
                                url = $"data:image/jpeg;base64,{base64Image}"
                            }
                        }
                    }
                }
            },
            max_tokens = 5
        };

        var jsonRequest = JsonSerializer.Serialize(visionRequest);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
        var responseString = await response.Content.ReadAsStringAsync();

        JsonDocument json = JsonDocument.Parse(responseString);
        string result = json.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString()
            .Trim()
            .ToLower();

        // Parse the response to boolean
        if (result.Contains("true")) return true;
        if (result.Contains("false")) return false;

        return null; // Could not determine
    }

    public async Task<Dictionary<string, bool?>> AnalyzeImagesInFolderAsync(string folderPath, string question, string outputFolder)
    {
        var results = new Dictionary<string, bool?>();

        if (!Directory.Exists(folderPath))
            return results;

        // Create output folder if it doesn't exist
        if (!Directory.Exists(outputFolder))
            Directory.CreateDirectory(outputFolder);

        string[] imageFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly)
                                       .Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                                                   || file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
                                                   || file.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                                       .ToArray();

        foreach (var imagePath in imageFiles)
        {
            Console.WriteLine($"Processing: {Path.GetFileName(imagePath)}...");
            bool? result = await AnalyzeImageAsync(imagePath, question);
            results[Path.GetFileName(imagePath)] = result;

            if (result == true)
            {
                string fileName = Path.GetFileName(imagePath);
                string destinationPath = Path.Combine(outputFolder, fileName);

                // You can choose to Copy or Move the file
                File.Copy(imagePath, destinationPath, overwrite: true);
            }
        }

        return results;
    }
}
