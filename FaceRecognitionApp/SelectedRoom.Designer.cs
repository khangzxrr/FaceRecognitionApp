namespace FaceRecognitionApp
{
    partial class SelectedRoom
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
            this.phongLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // phongLabel
            // 
            this.phongLabel.AutoSize = true;
            this.phongLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phongLabel.Location = new System.Drawing.Point(12, 9);
            this.phongLabel.Name = "phongLabel";
            this.phongLabel.Size = new System.Drawing.Size(113, 29);
            this.phongLabel.TabIndex = 0;
            this.phongLabel.Text = "Phòng ....";
            // 
            // SelectedRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 523);
            this.Controls.Add(this.phongLabel);
            this.Name = "SelectedRoom";
            this.Text = "SelectedRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label phongLabel;
    }
}