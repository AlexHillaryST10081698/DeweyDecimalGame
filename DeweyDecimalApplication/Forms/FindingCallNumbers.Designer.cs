namespace DeweyDecimalApplication.Forms
{
    partial class FindingCallNumbers
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
            this.findingCallNumbersUserC1 = new DeweyDecimalApplication.UserControls.FindingCallNumbersUserC();
            this.SuspendLayout();
            // 
            // findingCallNumbersUserC1
            // 
            this.findingCallNumbersUserC1.Location = new System.Drawing.Point(1, -3);
            this.findingCallNumbersUserC1.Name = "findingCallNumbersUserC1";
            this.findingCallNumbersUserC1.Size = new System.Drawing.Size(1787, 788);
            this.findingCallNumbersUserC1.TabIndex = 0;
            // 
            // FindingCallNumbers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1788, 785);
            this.Controls.Add(this.findingCallNumbersUserC1);
            this.Name = "FindingCallNumbers";
            this.Text = "FindingCallNumbers";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.FindingCallNumbersUserC findingCallNumbersUserC1;
    }
}