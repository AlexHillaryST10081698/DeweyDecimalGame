namespace DeweyDecimalApplication.Forms
{
    partial class IdentifyingAreas
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
            this.identifyingAreasUserC1 = new DeweyDecimalApplication.UserControls.IdentifyingAreasUserC();
            this.SuspendLayout();
            // 
            // identifyingAreasUserC1
            // 
            this.identifyingAreasUserC1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.identifyingAreasUserC1.Location = new System.Drawing.Point(-2, 0);
            this.identifyingAreasUserC1.Name = "identifyingAreasUserC1";
            this.identifyingAreasUserC1.Size = new System.Drawing.Size(1787, 788);
            this.identifyingAreasUserC1.TabIndex = 0;
            // 
            // IdentifyingAreas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1788, 785);
            this.Controls.Add(this.identifyingAreasUserC1);
            this.Name = "IdentifyingAreas";
            this.Text = "IdentifyingAreas";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.IdentifyingAreasUserC identifyingAreasUserC1;
    }
}