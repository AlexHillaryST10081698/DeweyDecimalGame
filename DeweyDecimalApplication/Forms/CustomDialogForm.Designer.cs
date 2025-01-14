namespace DeweyDecimalApplication.Forms
{
    partial class CustomDialogForm
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
            this.CloseBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDialogImage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDialogText
            // 
            this.labelDialogText.AutoSize = true;
            this.labelDialogText.Location = new System.Drawing.Point(216, 68);
            this.labelDialogText.Name = "labelDialogText";
            this.labelDialogText.Size = new System.Drawing.Size(100, 25);
            this.labelDialogText.TabIndex = 2;
            this.labelDialogText.Text = "Message";
            // 
            // pictureBoxDialogImage
            // 
            this.pictureBoxDialogImage.Location = new System.Drawing.Point(265, 137);
            this.pictureBoxDialogImage.Name = "pictureBoxDialogImage";
            this.pictureBoxDialogImage.Size = new System.Drawing.Size(264, 227);
            this.pictureBoxDialogImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDialogImage.TabIndex = 3;
            this.pictureBoxDialogImage.TabStop = false;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(622, 342);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(95, 48);
            this.CloseBtn.TabIndex = 4;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // CustomDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.pictureBoxDialogImage);
            this.Controls.Add(this.labelDialogText);
            this.Name = "CustomDialogForm";
            this.Text = "Achievment";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDialogImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDialogText;
        private System.Windows.Forms.PictureBox pictureBoxDialogImage;
        private System.Windows.Forms.Button CloseBtn;
    }
}