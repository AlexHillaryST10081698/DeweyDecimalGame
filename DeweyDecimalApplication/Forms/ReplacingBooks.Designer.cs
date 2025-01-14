namespace DeweyDecimalApplication.Forms
{
    partial class ReplacingBooks
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
            this.replacingBooksUserC1 = new DeweyDecimalApplication.UserControls.ReplacingBooksUserC();
            this.SuspendLayout();
            // 
            // replacingBooksUserC1
            // 
            this.replacingBooksUserC1.Location = new System.Drawing.Point(2, -2);
            this.replacingBooksUserC1.Name = "replacingBooksUserC1";
            this.replacingBooksUserC1.Size = new System.Drawing.Size(1787, 788);
            this.replacingBooksUserC1.TabIndex = 0;
            // 
            // ReplacingBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1788, 785);
            this.Controls.Add(this.replacingBooksUserC1);
            this.Name = "ReplacingBooks";
            this.Text = "ReplacingBooks";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ReplacingBooksUserC replacingBooksUserC1;
    }
}