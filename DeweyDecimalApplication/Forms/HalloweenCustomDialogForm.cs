using System;
using System.Windows.Forms;

namespace DeweyDecimalApplication.Forms
{
    public partial class HalloweenCustomDialogForm : Form
    {
        private HalloweenAnimation halloweenAnimation;

        public HalloweenCustomDialogForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // Create an instance of HalloweenAnimation
            halloweenAnimation = new HalloweenAnimation();
            halloweenAnimation.Dock = DockStyle.Fill; // Fill the entire form
            this.Controls.Add(halloweenAnimation); // Add it to the form

            // Start the Halloween animation when the form loads
            this.Load += HalloweenCustomDialogForm_Load;
        }

        private void HalloweenCustomDialogForm_Load(object sender, EventArgs e)
        {
            // Start the Halloween animation
            StartHalloweenAnimation();
        }

        public string DialogText
        {
            get { return labelDialogText.Text; } // Get the text displayed in the dialog
            set { labelDialogText.Text = value; } // Set the text to be displayed in the dialog
        }

        public System.Drawing.Image DialogImage
        {
            get { return pictureBoxDialogImage.Image; } // Get the image displayed in the dialog
            set { pictureBoxDialogImage.Image = value; } // Set the image to be displayed in the dialog
        }

        private void StartHalloweenAnimation()
        {
            // Add falling pumpkins to the HalloweenAnimation control
            Random random = new Random();
            for (int i = 0; i < 10; i++) // Add 10 falling pumpkins
            {
                int x = random.Next(halloweenAnimation.Width); // Generate a random X-coordinate
                int speed = random.Next(2, 5); // Generate a random speed between 2 and 4 (adjust as needed)
                halloweenAnimation.AddFallingPumpkin(x, speed); // Add a falling pumpkin to the animation
            }
        }
    }
}
