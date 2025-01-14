namespace DeweyDecimalApplication.Forms
{
    partial class HomeForm
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
            this.homeUc1 = new DeweyDecimalApplication.UserControls.HomeUc();
            this.SuspendLayout();
            // 
            // homeUc1
            // 
            this.homeUc1.Location = new System.Drawing.Point(3, 0);
            this.homeUc1.Name = "homeUc1";
            this.homeUc1.Size = new System.Drawing.Size(1787, 788);
            this.homeUc1.TabIndex = 0;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1788, 785);
            this.Controls.Add(this.homeUc1);
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.HomeUc homeUc1;
    }
}