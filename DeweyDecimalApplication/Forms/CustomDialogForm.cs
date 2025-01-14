using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeweyDecimalApplication.Forms
{
    public partial class CustomDialogForm : Form
    {
        private ConfettiAnimation confettiAnimation;
        public CustomDialogForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            confettiAnimation = new ConfettiAnimation();
            confettiAnimation.Dock = DockStyle.Fill;
            Controls.Add(confettiAnimation);

            // Call AddConfetti to start the animation
            confettiAnimation.AddConfetti(100); // Adjust the count as needed
        }
        public string DialogText
        {
            get { return labelDialogText.Text; }
            set { labelDialogText.Text = value; }
        }

        public System.Drawing.Image DialogImage
        {
            get { return pictureBoxDialogImage.Image; }
            set { pictureBoxDialogImage.Image = value; }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();//Closes the form
        }
    }
}
