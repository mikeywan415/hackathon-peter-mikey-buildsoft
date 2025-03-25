using DevExpress.XtraEditors;
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
        public XtraForm1()
        {
            InitializeComponent();
            gpt = new GPTClient();
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
    }
}