using DevExpress.XtraEditors;
using ImageMagick;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        GPTClient gpt;
        private List<PlanData> planDataList;
        private readonly string directoryPath;
        private readonly string originalFilePath;
        private readonly string convertedFilePath;
        string connectionString = "Server=127.0.0.1;Port=5432;Database=buildsoft_12.2.1.0;User Id=standaloneBuildsoftUser;Password=pass4Buildsoftuser;CommandTimeout=180;Timeout=150;";
        public XtraForm1()
        {
            InitializeComponent();
            gpt = new GPTClient();
            directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            originalFilePath = Path.Combine(directoryPath, "original");
            convertedFilePath = Path.Combine(directoryPath, "converted");
            planDataList = new List<PlanData>();
           
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {

        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string folderPath = fbd.SelectedPath;
                string question = "Is this a floor plan?";
                string outputFolder = Path.Combine(folderPath, "FilteredResults");

                var results = await gpt.AnalyzeImagesInFolderAsync(folderPath, question, outputFolder);

                // Display results (e.g., in a textbox or messagebox)
                StringBuilder sb = new StringBuilder();
                foreach (var kvp in results)
                {
                    sb.AppendLine($"{kvp.Key}: {(kvp.Value.HasValue ? kvp.Value.ToString() : "Unknown")}");
                }

                MessageBox.Show(sb.ToString(), "Analysis Results");
            }
        }


        private void ReadDataFromPostgreSQL()
        {
            
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM plandata", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var planData = new PlanData
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            GlobalId = reader.IsDBNull(reader.GetOrdinal("globalid")) ? (Guid?)null : reader.GetGuid(reader.GetOrdinal("globalid")),
                            Data = reader.IsDBNull(reader.GetOrdinal("data")) ? null : (byte[])reader["data"],
                            Filename = reader.IsDBNull(reader.GetOrdinal("filename")) ? null : reader.GetString(reader.GetOrdinal("filename")),
                            PlanIndexOnFile = reader.IsDBNull(reader.GetOrdinal("planindexonfile")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("planindexonfile")),
                            IsVector = reader.IsDBNull(reader.GetOrdinal("isvector")) ? (bool?)null : reader.GetBoolean(reader.GetOrdinal("isvector")),
                            DetectSymbolsCache = reader.IsDBNull(reader.GetOrdinal("detectsymbolscache")) ? null : reader.GetString(reader.GetOrdinal("detectsymbolscache"))
                        };

                        planDataList.Add(planData);

                        // Save the Data field to a file
                        if (planData.Data != null && planData.Filename != null)
                        {
                            Directory.CreateDirectory(originalFilePath); // Ensure the directory exists
                            string filePath = Path.Combine(originalFilePath, planData.Filename);
                            File.WriteAllBytes(filePath, planData.Data);
                        }
                    }
                }
            }
        }

        private void ConvertFilesToJpg()
        {
            foreach (var planData in planDataList)
            {
                if (planData.Filename != null)
                {
                    string filePath = Path.Combine(originalFilePath, planData.Filename);
                    string jpgFilePath = Path.Combine(convertedFilePath, Path.GetFileNameWithoutExtension(planData.Filename) + ".jpg");

                    string extension = Path.GetExtension(planData.Filename).ToLower();
                    switch (extension)
                    {
                        case ".pdf":
                            ConvertPdfToJpg(filePath, jpgFilePath);
                            break;
                        case ".jpg":
                        case ".jpeg":
                        case ".png":
                            ConvertImageToJpg(filePath, jpgFilePath);
                            break;
                        case ".dwg":
                            // Handle DWG files if needed
                            break;
                    }
                }
            }
        }

        private void ConvertPdfToJpg(string pdfFilePath, string jpgFilePath)
        {
            try
            {
                int density = 300; // DPI setting for quality
                // Ensure the directory exists
                string directoryPath = Path.GetDirectoryName(jpgFilePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                MagickReadSettings settings = new MagickReadSettings
                {
                    Density = new Density(density, density)
                };

                // Read the first page of the PDF into a MagickImage.
                using (MagickImageCollection magickImageCollection = new MagickImageCollection())
                {
                    magickImageCollection.Read(pdfFilePath, settings);

                    foreach (MagickImage magickImage in magickImageCollection)
                    {
                        magickImage.Format = MagickFormat.Jpg;
                        magickImage.Write(jpgFilePath);
                        break; // Only process the first page
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving PDF as image: {ex.Message}");
            }
        }

        private void ConvertImageToJpg(string imageFilePath, string jpgFilePath)
        {
            try
            {
                // Ensure the directory exists
                string directoryPath = Path.GetDirectoryName(jpgFilePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                using (var image = System.Drawing.Image.FromFile(imageFilePath))
                {
                    var jpgEncoder = GetEncoder(System.Drawing.Imaging.ImageFormat.Jpeg);
                    var encoderParameters = new System.Drawing.Imaging.EncoderParameters(1);
                    encoderParameters.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                    image.Save(jpgFilePath, jpgEncoder, encoderParameters);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving image: {ex.Message}");
            }
        }

        private System.Drawing.Imaging.ImageCodecInfo GetEncoder(System.Drawing.Imaging.ImageFormat format)
        {
            var codecs = System.Drawing.Imaging.ImageCodecInfo.GetImageDecoders();
            foreach (var codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void btnGetPlan_Click(object sender, EventArgs e)
        {
            ReadDataFromPostgreSQL();
            ConvertFilesToJpg();
            MessageBox.Show("Files have been converted to JPG format.");
        }
    }
}