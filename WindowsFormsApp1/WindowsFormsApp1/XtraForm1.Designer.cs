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
            this.filterFloorPlan = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnGetPlan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // filterFloorPlan
            // 
            this.filterFloorPlan.Location = new System.Drawing.Point(621, 184);
            this.filterFloorPlan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterFloorPlan.Name = "filterFloorPlan";
            this.filterFloorPlan.Size = new System.Drawing.Size(81, 24);
            this.filterFloorPlan.TabIndex = 0;
            this.filterFloorPlan.Text = "Filter Floor Plan";
            this.filterFloorPlan.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(738, 188);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(107, 20);
            this.textEdit1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(621, 243);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "labelControl1";
            // 
            // btnGetPlan
            // 
            this.btnGetPlan.Location = new System.Drawing.Point(609, 486);
            this.btnGetPlan.Name = "btnGetPlan";
            this.btnGetPlan.Size = new System.Drawing.Size(114, 55);
            this.btnGetPlan.TabIndex = 3;
            this.btnGetPlan.Text = "Get Plan";
            this.btnGetPlan.UseVisualStyleBackColor = true;
            this.btnGetPlan.Click += new System.EventHandler(this.btnGetPlan_Click);
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 891);
            this.Controls.Add(this.btnGetPlan);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.filterFloorPlan);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "XtraForm1";
            this.Text = "XtraForm1";
            this.Load += new System.EventHandler(this.XtraForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton filterFloorPlan;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Button btnGetPlan;
    }
}