namespace WindowsFormsApp1
{
    partial class XtraForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetPlan = new System.Windows.Forms.Button();
            this.btnFilterFloorPlan = new System.Windows.Forms.Button();
            this.txtBoxConnectionStr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOutputFolder = new System.Windows.Forms.Label();
            this.txtBoxOutput = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnGetPlan
            // 
            this.btnGetPlan.Location = new System.Drawing.Point(161, 286);
            this.btnGetPlan.Name = "btnGetPlan";
            this.btnGetPlan.Size = new System.Drawing.Size(290, 92);
            this.btnGetPlan.TabIndex = 3;
            this.btnGetPlan.Text = "Get Plan";
            this.btnGetPlan.UseVisualStyleBackColor = true;
            this.btnGetPlan.Click += new System.EventHandler(this.btnGetPlan_Click);
            // 
            // btnFilterFloorPlan
            // 
            this.btnFilterFloorPlan.Location = new System.Drawing.Point(161, 462);
            this.btnFilterFloorPlan.Name = "btnFilterFloorPlan";
            this.btnFilterFloorPlan.Size = new System.Drawing.Size(290, 108);
            this.btnFilterFloorPlan.TabIndex = 4;
            this.btnFilterFloorPlan.Text = "Filter Floor Plan";
            this.btnFilterFloorPlan.UseVisualStyleBackColor = true;
            this.btnFilterFloorPlan.Click += new System.EventHandler(this.btnFilterFloorPlan_Click);
            // 
            // txtBoxConnectionStr
            // 
            this.txtBoxConnectionStr.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxConnectionStr.Location = new System.Drawing.Point(279, 121);
            this.txtBoxConnectionStr.Name = "txtBoxConnectionStr";
            this.txtBoxConnectionStr.Size = new System.Drawing.Size(824, 33);
            this.txtBoxConnectionStr.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(157, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Database:";
            // 
            // lblOutputFolder
            // 
            this.lblOutputFolder.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutputFolder.Location = new System.Drawing.Point(156, 187);
            this.lblOutputFolder.Name = "lblOutputFolder";
            this.lblOutputFolder.Size = new System.Drawing.Size(290, 33);
            this.lblOutputFolder.TabIndex = 7;
            this.lblOutputFolder.Text = "Filter output plan folder:";
            // 
            // txtBoxOutput
            // 
            this.txtBoxOutput.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxOutput.Location = new System.Drawing.Point(413, 187);
            this.txtBoxOutput.Name = "txtBoxOutput";
            this.txtBoxOutput.ReadOnly = true;
            this.txtBoxOutput.Size = new System.Drawing.Size(690, 33);
            this.txtBoxOutput.TabIndex = 8;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(161, 655);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(590, 45);
            this.progressBar.TabIndex = 9;
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 891);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.txtBoxOutput);
            this.Controls.Add(this.lblOutputFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxConnectionStr);
            this.Controls.Add(this.btnFilterFloorPlan);
            this.Controls.Add(this.btnGetPlan);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "XtraForm1";
            this.Text = "XtraForm1";
            this.Load += new System.EventHandler(this.XtraForm1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGetPlan;
        private System.Windows.Forms.Button btnFilterFloorPlan;
        private System.Windows.Forms.TextBox txtBoxConnectionStr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOutputFolder;
        private System.Windows.Forms.TextBox txtBoxOutput;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}