using DeweyDecimalApplication.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeweyDecimalApplication.UserControls
{
    public partial class ReplacingBooksUserC : UserControl
    {
        private Point startPoint;
        private PictureBox currentPictureBox = null;
        private FlowLayoutPanel currentPanel = null;
        private List<PictureBox> pictureBoxes = new List<PictureBox>(); //list that stores all the pictureboxes
        private List<double> deweyDecimalNumbers = new List<double>();//list to hold the dewey decimal numbers
        private List<double> sortedDeweyDecimalNumbers = new List<double>();
        private Timer gameTimer = new Timer();
        private int remainingSeconds = 0;
        private DateTime startTime; // Variable to record the start time
        private bool gameStarted = false; //variable to check wheather game has started or not
        private GameOverForm gameOverForm;
        private List<string> initialsList = new List<string>();


        public ReplacingBooksUserC()
        {
            InitializeComponent();

            // Add all PictureBox controls to the list
            pictureBoxes.Add(pictureBox1);
            pictureBoxes.Add(pictureBox2);
            pictureBoxes.Add(pictureBox3);
            pictureBoxes.Add(pictureBox4);
            pictureBoxes.Add(pictureBox5);
            pictureBoxes.Add(pictureBox6);
            pictureBoxes.Add(pictureBox7);
            pictureBoxes.Add(pictureBox8);
            pictureBoxes.Add(pictureBox9);
            pictureBoxes.Add(pictureBox10);

            // Attach event handlers to all PictureBox controls
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.MouseDown += PictureBox_MouseDown;
                pictureBox.MouseMove += PictureBox_MouseMove;
                pictureBox.MouseUp += PictureBox_MouseUp;
            }
            gameOverForm = new GameOverForm();
            // Initialize the Timer control
            gameTimer.Interval = 1000; // Timer tick every 1 second (1000 milliseconds)
            gameTimer.Tick += GameTimer_Tick;
        }

        #region Moving Mouse Down
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (!gameStarted)
            {
                MessageBox.Show("Please click the 'Start Game' button before dragging the PictureBoxes.");//Exception to only allow the user to drag the pictureboxes once the game has started
                return;
            }
            currentPictureBox = sender as PictureBox;
            startPoint = e.Location;
            currentPictureBox.BringToFront(); // Bring the clicked PictureBox to the front
        }
        #endregion
        #region Method For Moving The Mouse
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentPictureBox != null && e.Button == MouseButtons.Left)
            {
                int deltaX = e.X - startPoint.X;
                int deltaY = e.Y - startPoint.Y;

                currentPictureBox.Left += deltaX;
                currentPictureBox.Top += deltaY;

                // Check if the PictureBox is inside a FlowLayoutPanel
                foreach (Control control in this.Controls)
                {
                    if (control is FlowLayoutPanel panel && panel.ClientRectangle.Contains(panel.PointToClient(Cursor.Position)))
                    {
                        if (currentPanel != null && currentPanel != panel)
                        {
                            // Moving between FlowLayoutPanel1 and FlowLayoutPanel2
                            currentPanel.Controls.Remove(currentPictureBox); // Remove from the current panel
                            panel.Controls.Add(currentPictureBox); // Add to the new panel
                            UpdateProgressBar(); // Update the progress bar
                        }

                        currentPanel = panel;
                    }
                }

                // Check if all PictureBoxes are now in flowLayoutPanel2
                bool allInLayoutPanel2 = pictureBoxes.All(pb => flowLayoutPanel2.Controls.Contains(pb));
                if (allInLayoutPanel2)
                {
                    SortDeweyDecimalNumbers(); // Sort the Dewey Decimal numbers

                    bool isAscending = ArePictureBoxesInAscendingOrder();

                    if (isAscending)
                    {
                        // All PictureBoxes are in flowLayoutPanel2 and sorted, stop the timer
                        gameTimer.Stop();
                        DisplayTimelbl.Text = "00:00"; // Display "00:00" when time's up

                        // Calculate the time taken by subtracting the start time from the current time
                        TimeSpan timeTaken = DateTime.Now - startTime;

                        int selectedLevel = selectDiffcomboBox.SelectedIndex + 1;
                        DisplayCustomDialog(selectedLevel, timeTaken);
                    }
                    else
                    {
                        // PictureBoxes are in flowLayoutPanel2 but not sorted
                        MessageBox.Show("The PictureBoxes are not in ascending order. Please arrange them in ascending order.");
                    }
                }
            }
        }
        #endregion

        #region Moving Mouse Up
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            currentPictureBox = null; // Reset the current PictureBox
        }
        #endregion

        #region Start Game Button
        private void button1_Click(object sender, EventArgs e)
        {
            // Check if a difficulty level is selected
            if (selectDiffcomboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a difficulty level before starting the game.");
                return; // Exit the event handler
            }
            gameStarted = true;

            GenerateAndDisplayValues(); // Call the method to generate and display values

            // Clear the progress bar
            progressBar1.Value = 0;

            // Start the game based on the selected level
            int selectedLevel = selectDiffcomboBox.SelectedIndex;
            StartGame(selectedLevel);
        }


        #endregion

        #region Method For Selecting Level
        private void StartGame(int level)
        {
            startTime = DateTime.Now; // Record the start time

            switch (level)
            {
                case 0: // Level 1 (1 minutes and 30 seconds)
                    remainingSeconds = 90;
                    break;
                case 1: // Level 2 (1 minute)
                    remainingSeconds = 60;
                    break;
                case 2: // Level 3 (45 seconds)
                    remainingSeconds = 45;
                    break;
                case 3: // Level 4 (1 minute)
                    remainingSeconds = 60;
                    break;

                default:
                    remainingSeconds = 0;
                    break;
            }

            // Start the game timer
            gameTimer.Start();
        }
        #endregion

        #region Method for Sorting the Dewey Decimal Numbers
        private void SortDeweyDecimalNumbers()
        {
            sortedDeweyDecimalNumbers.Sort(); // Sort the list in ascending order
        }
        #endregion

        #region Method For Handeling The Ticking of The Time
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            // Update the remaining time and display it
            remainingSeconds--;

            if (remainingSeconds >= 0)
            {
                DisplayTimelbl.Text = TimeSpan.FromSeconds(remainingSeconds).ToString(@"mm\:ss");

                // Check if it's time to reset the Dewey Decimal numbers
                int selectedLevel = selectDiffcomboBox.SelectedIndex;

                if (selectedLevel == 3)
                {
                    // Reset Dewey Decimal numbers and initials every 20 seconds
                    if (remainingSeconds % 20 == 0)
                    {
                        ResetDeweyDecimalNumbers();
                    }
                }
            }
            else
            {
                // Time's up, stop the timer
                gameTimer.Stop();
                DisplayTimelbl.Text = "00:00"; // Display "00:00" when time's up

                // Calculate the time taken by subtracting the start time from the current time
                TimeSpan timeTaken = DateTime.Now - startTime;

                int selectedLevel = selectDiffcomboBox.SelectedIndex + 1;
                
                // Show the GameOverForm and start the animation
                gameOverForm.Show();
            }
        }

        #endregion
        #region Method Created to Generate 10 Dewey Decimal Number
        private void GenerateAndDisplayValues()
        {
            // Clear the existing labels from PictureBoxes
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.Controls.Clear();
            }

            deweyDecimalNumbers.Clear(); // Clear the list before generating new numbers
            initialsList.Clear(); // Clear the initials list

            // Generate 10 random Dewey Decimal numbers and initials
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                double deweyDecimalNumber = random.NextDouble() * 1000; 
                deweyDecimalNumbers.Add(deweyDecimalNumber); // Added the generated number to the list

                // Generate two random indices for initials (A to Z)
                int initialIndex1 = random.Next(0, 26);
                int initialIndex2 = random.Next(0, 26);

                char initial1 = (char)('A' + initialIndex1); // Get the first random initial
                char initial2 = (char)('A' + initialIndex2); // Get the second random initial

                initialsList.Add(initial1.ToString() + "." + initial2.ToString()); // Add the initials as "A.B"

                // Create a label for displaying the Dewey Decimal number and initials on separate lines
                Label label = new Label();
                label.Text = deweyDecimalNumber.ToString("F2") + "\n" + initial1.ToString() + "." + initial2.ToString();
                label.BackColor = Color.White;

                // Set the label's position and size within the PictureBox
                label.Location = new System.Drawing.Point(10, 10); 

                // Measure the text size
                Size textSize = TextRenderer.MeasureText(label.Text, label.Font);

                // Set the label's size based on the text size
                label.Size = textSize;

                // Determine which PictureBox to add the label to
                PictureBox pictureBox = pictureBoxes[i]; 

                // Center the label horizontally within the PictureBox
                int centerX = (pictureBox.Width - textSize.Width) / 2;
                int centerY = (pictureBox.Height - textSize.Height) / 2;
                label.Location = new Point(centerX, centerY);

                // Add the label to the PictureBox
                pictureBox.Controls.Add(label);
            }
        }
        #endregion

        #region Method For Updating The Progress Bar
        private void UpdateProgressBar()
        {
            //counter for number pictureboxes in flowlayoutpanel
            int pictureBoxCount = flowLayoutPanel2.Controls.OfType<PictureBox>().Count();
            progressBar1.Maximum = pictureBoxes.Count;
            progressBar1.Value = pictureBoxCount;
        }
        #endregion

        #region For checking if the PictureBoxes are Stored in Acsending Order
        private bool ArePictureBoxesInAscendingOrder()
        {
            double previousValue = double.MinValue; // Initialize with a minimum value

            foreach (PictureBox pictureBox in flowLayoutPanel2.Controls.OfType<PictureBox>())
            {
                // Retriving the Dewey Decimal number from the PictureBox label
                if (pictureBox.Controls.Count > 0 && pictureBox.Controls[0] is Label label)
                {
                    double deweyDecimalNumber;
                    if (double.TryParse(label.Text.Split('\n')[0], out deweyDecimalNumber))
                    {
                        // Check if the current number is greater than or equal to the previous number
                        if (deweyDecimalNumber < previousValue)
                        {
                            return false; // PictureBoxes are not in ascending order
                        }

                        previousValue = deweyDecimalNumber; // Update the previous value
                    }
                }
            }

            return true; // PictureBoxes are in ascending order
        }

        #endregion

        #region Method For Displaying Achievement Badges
        private void DisplayCustomDialog(int levelCompleted, TimeSpan timeTaken)
        {
            using (CustomDialogForm customDialog = new CustomDialogForm())
            {
                customDialog.StartPosition = FormStartPosition.CenterScreen;

                string message;
                System.Drawing.Image badgeImage;

                switch (levelCompleted)
                {
                    //Switch statement for displaying Achievment Badges based on level completed
                    case 1:
                        message = "Congratulations! You've earned a Bronze badge!";
                        badgeImage = Properties.Resources.BronzeBadge;
                        break;
                    case 2:
                        message = "Congratulations! You've earned a Silver badge!";
                        badgeImage = Properties.Resources.SilverBadge;
                        break;
                    case 3:
                        message = "Congratulations! You've earned a Gold badge!";
                        badgeImage = Properties.Resources.GoldBadge;
                        break;
                    case 4:
                        message = "Congratulations! You've earned a Platinum badge!";
                        badgeImage = Properties.Resources.PlatinumBadge;
                        break;
                    default:
                        message = "Congratulations! You've completed a level!";
                        badgeImage = null;
                        break;
                }

                message += Environment.NewLine + "Time Taken: " + timeTaken.ToString(@"mm\:ss");

                customDialog.DialogText = message;
                customDialog.DialogImage = badgeImage;

                customDialog.ShowDialog();
            }
        }
        #endregion

        #region Method For resetting The Dewey Decimal Number 
        private void ResetDeweyDecimalNumbers()
        {
            // Clearing the existing labels from PictureBoxes
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.Controls.Clear();
            }

            deweyDecimalNumbers.Clear(); // Clearing the list before generating new numbers
            initialsList.Clear(); // Clearing the initials list

            // Generate 10 random Dewey Decimal numbers and initials
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                double deweyDecimalNumber = random.NextDouble() * 1000; 
                deweyDecimalNumbers.Add(deweyDecimalNumber); // Added the generated number to the list

                // Generate two random indices for initials (A to Z)
                int initialIndex1 = random.Next(0, 26);
                int initialIndex2 = random.Next(0, 26);

                char initial1 = (char)('A' + initialIndex1); // Get the first random initial
                char initial2 = (char)('A' + initialIndex2); // Get the second random initial

                string initials = initial1.ToString() + "." + initial2.ToString(); // Add the initials as "A.B"
                initialsList.Add(initials); // Add the initials to the list

                // Create a label for displaying the Dewey Decimal number and initials on separate lines
                Label label = new Label();
                label.Text = deweyDecimalNumber.ToString("F2") + "\n" + initials;
                label.BackColor = Color.White;

                // Set the label's position and size within the PictureBox
                label.Location = new System.Drawing.Point(10, 10); // Adjust the position

                // Measure the text size
                Size textSize = TextRenderer.MeasureText(label.Text, label.Font);

                // Set the label's size based on the text size
                label.Size = textSize;

                // Determine which PictureBox to add the label to
                PictureBox pictureBox = pictureBoxes[i]; // Use the PictureBox from the list

                // Center the label horizontally within the PictureBox
                int centerX = (pictureBox.Width - textSize.Width) / 2;
                int centerY = (pictureBox.Height - textSize.Height) / 2;
                label.Location = new Point(centerX, centerY);

                // Add the label to the PictureBox
                pictureBox.Controls.Add(label);
            }
        }

        #endregion

        #region Method To Restart The Game
        private void RestartGame()
        {
            // Clear the existing labels from PictureBoxes
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.Controls.Clear();
            }

            // Move all PictureBoxes back to flowLayoutPanel1
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                flowLayoutPanel1.Controls.Add(pictureBox);
            }

            // Reset the progress bar
            progressBar1.Value = 0;

            // Stop the game timer if it's running
            gameTimer.Stop();
            DisplayTimelbl.Text = "00:00"; // Reset the timer display
        }
        #endregion

        #region RestartButton Event
        private void RestartBtn_Click(object sender, EventArgs e)
        {
            RestartGame(); // Call the restart method when the button is clicked
        }
        #endregion
    }
}
