namespace DeweyDecimalApplication
{
    partial class Home_Form
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.FindingCallNumBtn = new System.Windows.Forms.Button();
            this.IdentifyingAreasBtn = new System.Windows.Forms.Button();
            this.ReplacingBooksBtn = new System.Windows.Forms.Button();
            this.HomeBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelMove = new System.Windows.Forms.Panel();
            this.HomePagePanel = new System.Windows.Forms.Panel();
            this.replacingBooksUserC1 = new DeweyDecimalApplication.UserControls.HomeUc();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.panel3.SuspendLayout();
            this.HomePagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(27)))), ((int)(((byte)(9)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1787, 120);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(181, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dewey Decimal Game";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DeweyDecimalApplication.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(11, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.ExitBtn);
            this.panelContainer.Controls.Add(this.FindingCallNumBtn);
            this.panelContainer.Controls.Add(this.IdentifyingAreasBtn);
            this.panelContainer.Controls.Add(this.ReplacingBooksBtn);
            this.panelContainer.Controls.Add(this.HomeBtn);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContainer.Location = new System.Drawing.Point(0, 120);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1787, 100);
            this.panelContainer.TabIndex = 1;
            // 
            // ExitBtn
            // 
            this.ExitBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(228)))));
            this.ExitBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.ExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.Color.Black;
            this.ExitBtn.Image = global::DeweyDecimalApplication.Properties.Resources.ExitIcon;
            this.ExitBtn.Location = new System.Drawing.Point(1428, 0);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(371, 100);
            this.ExitBtn.TabIndex = 4;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // FindingCallNumBtn
            // 
            this.FindingCallNumBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(228)))));
            this.FindingCallNumBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.FindingCallNumBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.125F);
            this.FindingCallNumBtn.ForeColor = System.Drawing.Color.Black;
            this.FindingCallNumBtn.Image = global::DeweyDecimalApplication.Properties.Resources.FindIcon;
            this.FindingCallNumBtn.Location = new System.Drawing.Point(1071, 0);
            this.FindingCallNumBtn.Name = "FindingCallNumBtn";
            this.FindingCallNumBtn.Size = new System.Drawing.Size(357, 100);
            this.FindingCallNumBtn.TabIndex = 3;
            this.FindingCallNumBtn.Text = "FInding Call Numbers";
            this.FindingCallNumBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FindingCallNumBtn.UseVisualStyleBackColor = false;
            this.FindingCallNumBtn.Click += new System.EventHandler(this.FindingCallNumBtn_Click);
            // 
            // IdentifyingAreasBtn
            // 
            this.IdentifyingAreasBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(228)))));
            this.IdentifyingAreasBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.IdentifyingAreasBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.125F);
            this.IdentifyingAreasBtn.ForeColor = System.Drawing.Color.Black;
            this.IdentifyingAreasBtn.Image = global::DeweyDecimalApplication.Properties.Resources.SearchIcon;
            this.IdentifyingAreasBtn.Location = new System.Drawing.Point(714, 0);
            this.IdentifyingAreasBtn.Name = "IdentifyingAreasBtn";
            this.IdentifyingAreasBtn.Size = new System.Drawing.Size(357, 100);
            this.IdentifyingAreasBtn.TabIndex = 2;
            this.IdentifyingAreasBtn.Text = "Identifying Areas";
            this.IdentifyingAreasBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.IdentifyingAreasBtn.UseVisualStyleBackColor = false;
            this.IdentifyingAreasBtn.Click += new System.EventHandler(this.IdentifyingAreasBtn_Click);
            // 
            // ReplacingBooksBtn
            // 
            this.ReplacingBooksBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(228)))));
            this.ReplacingBooksBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.ReplacingBooksBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.125F);
            this.ReplacingBooksBtn.ForeColor = System.Drawing.Color.Black;
            this.ReplacingBooksBtn.Image = global::DeweyDecimalApplication.Properties.Resources.ReplaceIcon;
            this.ReplacingBooksBtn.Location = new System.Drawing.Point(357, 0);
            this.ReplacingBooksBtn.Name = "ReplacingBooksBtn";
            this.ReplacingBooksBtn.Size = new System.Drawing.Size(357, 100);
            this.ReplacingBooksBtn.TabIndex = 1;
            this.ReplacingBooksBtn.Text = "  Replacing Books";
            this.ReplacingBooksBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ReplacingBooksBtn.UseVisualStyleBackColor = false;
            this.ReplacingBooksBtn.Click += new System.EventHandler(this.ReplacingBooksBtn_Click);
            // 
            // HomeBtn
            // 
            this.HomeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(228)))));
            this.HomeBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.HomeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeBtn.ForeColor = System.Drawing.Color.Black;
            this.HomeBtn.Image = global::DeweyDecimalApplication.Properties.Resources.HomeIcon;
            this.HomeBtn.Location = new System.Drawing.Point(0, 0);
            this.HomeBtn.Name = "HomeBtn";
            this.HomeBtn.Size = new System.Drawing.Size(357, 100);
            this.HomeBtn.TabIndex = 0;
            this.HomeBtn.Text = "       Home";
            this.HomeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.HomeBtn.UseVisualStyleBackColor = false;
            this.HomeBtn.Click += new System.EventHandler(this.HomeBtn_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(27)))), ((int)(((byte)(9)))));
            this.panel3.Controls.Add(this.panelMove);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 220);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1787, 26);
            this.panel3.TabIndex = 2;
            // 
            // panelMove
            // 
            this.panelMove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.panelMove.Location = new System.Drawing.Point(3, 3);
            this.panelMove.Name = "panelMove";
            this.panelMove.Size = new System.Drawing.Size(354, 17);
            this.panelMove.TabIndex = 3;
            // 
            // HomePagePanel
            // 
            this.HomePagePanel.Controls.Add(this.replacingBooksUserC1);
            this.HomePagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HomePagePanel.Location = new System.Drawing.Point(0, 246);
            this.HomePagePanel.Name = "HomePagePanel";
            this.HomePagePanel.Size = new System.Drawing.Size(1787, 788);
            this.HomePagePanel.TabIndex = 3;
            // 
            // replacingBooksUserC1
            // 
            this.replacingBooksUserC1.Location = new System.Drawing.Point(3, 0);
            this.replacingBooksUserC1.Name = "replacingBooksUserC1";
            this.replacingBooksUserC1.Size = new System.Drawing.Size(1787, 788);
            this.replacingBooksUserC1.TabIndex = 0;
            // 
            // Home_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1787, 1034);
            this.Controls.Add(this.HomePagePanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panel1);
            this.Name = "Home_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.HomePagePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button HomeBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelMove;
        private System.Windows.Forms.Panel HomePagePanel;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button FindingCallNumBtn;
        private System.Windows.Forms.Button IdentifyingAreasBtn;
        private System.Windows.Forms.Button ReplacingBooksBtn;
        private UserControls.HomeUc replacingBooksUserC1;
    }
}

