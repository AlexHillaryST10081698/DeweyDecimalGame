namespace DeweyDecimalApplication.Forms
{
    partial class HalloweenCustomDialogForm
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
            this.labelDialogText = new System.Windows.Forms.Label();
            this.pictureBoxDialogImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDialogImage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDialogText
            // 
            this.labelDialogText.AutoSize = true;
            this.labelDialogText.Location = new System.Drawing.Point(210, 51);
            this.labelDialogText.Name = "labelDialogText";
            this.labelDialogText.Size = new System.Drawing.Size(100, 25);
            this.labelDialogText.TabIndex = 5;
            this.labelDialogText.Text = "Message";
            // 
            // pictureBoxDialogImage
            // 
            this.pictureBoxDialogImage.Location = new System.Drawing.Point(267, 149);
            this.pictureBoxDialogImage.Name = "pictureBoxDialogImage";
            this.pictureBoxDialogImage.Size = new System.Drawing.Size(264, 227);
            this.pictureBoxDialogImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDialogImage.TabIndex = 4;
            this.pictureBoxDialogImage.TabStop = false;
            // 
            // HalloweenCustomDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelDialogText);
            this.Controls.Add(this.pictureBoxDialogImage);
            this.Name = "HalloweenCustomDialogForm";
            this.Text = "HalloweenCustomDialogForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDialogImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxDialogImage;
        private System.Windows.Forms.Label labelDialogText;
    }
}