using System;
using System.Drawing;
using System.Windows.Forms;

namespace DeweyDecimalApplication.Forms
{
    public partial class GameOverForm : Form
    {
        private int animationStep = 0;
        private Color[] colors = { Color.Red, Color.Yellow, Color.Green, Color.Blue };
        private int colorIndex = 0;

        public GameOverForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            // Customize the label's properties
            gameoverLabel.Text = "Game Over!";
            gameoverLabel.Font = new Font("Arial", 36, FontStyle.Bold);
            gameoverLabel.ForeColor = Color.Red;
            gameoverLabel.BackColor = Color.Transparent;
            gameoverLabel.TextAlign = ContentAlignment.MiddleCenter;
            //animationTimer.Enabled = true;

            animationTimer.Interval = 100; // Change to a smaller value for quicker animation

            // Start the animation timer
            animationTimer.Start();
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            // Bounce animation
            int bounceHeight = 20; // Adjust the bounce height as needed

            switch (animationStep)
            {
                case 0:
                    // Bounce up
                    gameoverLabel.Top -= bounceHeight;
                    break;
                case 1:
                    // Bounce down
                    gameoverLabel.Top += bounceHeight;
                    break;
                case 2:
                    // Change text color
                    gameoverLabel.ForeColor = colors[colorIndex];
                    colorIndex = (colorIndex + 1) % colors.Length;
                    break;
                case 3:
                    // Reset animation
                    gameoverLabel.Top = 100; // Adjust the initial position
                    gameoverLabel.ForeColor = Color.Red;
                    break;
            }

            // Increment animation step
            animationStep = (animationStep + 1) % 4;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
