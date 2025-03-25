using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string imagePath = ofd.FileName;
                string question = "Is this a floor plan?";

                bool? result = await gpt.AnalyzeImageAsync(imagePath, question);

                if (result.HasValue)
                    MessageBox.Show($"Result: {result.Value}");
                else
                    MessageBox.Show("Could not determine the result.");
            }
        }
    }
}