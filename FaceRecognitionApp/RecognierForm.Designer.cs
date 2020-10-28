namespace FaceRecognitionApp
{
    partial class RecognierForm
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
            this.sodosbdBtn = new System.Windows.Forms.Button();
            this.phongLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sodosbdBtn
            // 
            this.sodosbdBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sodosbdBtn.Location = new System.Drawing.Point(161, 12);
            this.sodosbdBtn.Name = "sodosbdBtn";
            this.sodosbdBtn.Size = new System.Drawing.Size(142, 61);
            this.sodosbdBtn.TabIndex = 0;
            this.sodosbdBtn.Text = "Sơ đồ SBD";
            this.sodosbdBtn.UseVisualStyleBackColor = true;
            this.sodosbdBtn.Click += new System.EventHandler(this.sodosbdBtn_Click);
            // 
            // phongLabel
            // 
            this.phongLabel.AutoSize = true;
            this.phongLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phongLabel.Location = new System.Drawing.Point(12, 12);
            this.phongLabel.Name = "phongLabel";
            this.phongLabel.Size = new System.Drawing.Size(69, 25);
            this.phongLabel.TabIndex = 1;
            this.phongLabel.Text = "Phong";
            // 
            // RecognierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 89);
            this.Controls.Add(this.phongLabel);
            this.Controls.Add(this.sodosbdBtn);
            this.Name = "RecognierForm";
            this.Text = "RecognierForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sodosbdBtn;
        private System.Windows.Forms.Label phongLabel;
    }
}