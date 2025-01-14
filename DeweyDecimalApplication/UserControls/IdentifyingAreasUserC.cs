using DeweyDecimalApplication.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DeweyDecimalApplication.UserControls
{
    public partial class IdentifyingAreasUserC : UserControl
    {
        // Declarations for various components and data structures
        private Dictionary<int, string> callNumberMappings;
        private List<PictureBox> pictureBoxes;
        private Timer gameTimer;
        private int totalTime;
        private List<RadioButton> leftRadioButtons;
        private List<RadioButton> rightRadioButtons;
        private RadioButton lastSelectedLeftRadioButton;
        private PictureBox lastSelectedPictureBox;
        private int correctMatches;
        private RadioButton lastSelectedRightRadioButton;
        private List<PictureBox> matchedPictureBoxes;
        private List<RadioButton> matchedLeftRadioButtons;
        private int selectedDifficulty; 
        private TimeSpan timeTaken; 

        //----------------------------------------------------------------------Constructor----------------------------------------------------------------------------------------//
        public IdentifyingAreasUserC()
        {
            InitializeComponent();

            // Initialize the call number mappings
            callNumberMappings = new Dictionary<int, string>
            {
                // Mapping Dewey Decimal System numbers to categories
                {1, "Generalities"},
                {2, "Philosophy"},
                {3, "Religion"},
                {4, "Social Science"},
                {5, "Languages"},
                {6, "Natural Science"},
                {7, "Applied Science"},
                {8, "Arts and Recreation"},
                {9, "Literature"},
                {10, "Geography and History"}
       
            };

            // Create a list of PictureBox controls
            pictureBoxes = new List<PictureBox>
            {
                // List of PictureBox controls used in the game
                pictureBox1, pictureBox2, pictureBox3, pictureBox4,
                pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11 // 11 total pictureboxes 
            };

            // Create a list of left and right radio buttons
            leftRadioButtons = new List<RadioButton>
            {
                // Radio buttons on the left panel
                radioButton1, radioButton2, radioButton3, radioButton4
            };

            rightRadioButtons = new List<RadioButton>
            {
                // Radio buttons on the right panel
                radioButton5, radioButton6, radioButton7, radioButton8, radioButton9, radioButton10, radioButton11
            };

            // Attach the Paint event handler for each PictureBox
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.Paint += PictureBox_Paint;
            }

            // Attach the RadioButton_CheckedChanged event handler to all radio buttons in panelLeft
            foreach (RadioButton radioButton in leftRadioButtons)
            {
                radioButton.CheckedChanged += RadioButton_CheckedChanged;
            }

            // Attach the RadioButton_CheckedChanged event handler to all radio buttons in panelRight
            foreach (RadioButton radioButton in rightRadioButtons)
            {
                radioButton.CheckedChanged += RadioButton_CheckedChanged;
            }

            // Initialize the timer
            gameTimer = new Timer();
            gameTimer.Interval = 1000; // 1 second
            gameTimer.Tick += GameTimer_Tick;
            // Initialize the correct matches counter
            correctMatches = 0;
            matchedPictureBoxes = new List<PictureBox>();
            matchedLeftRadioButtons = new List<RadioButton>();

            // Disable all radio buttons initially
            foreach (RadioButton radioButton in leftRadioButtons)
            {
                radioButton.Enabled = false;
            }

            foreach (RadioButton radioButton in rightRadioButtons)
            {
                radioButton.Enabled = false;
            }
        }

        #region Event handler For RadioButtons
        // Event handler for radio button changes
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Radio button checked change event

            RadioButton selectedRadioButton = (RadioButton)sender;

            if (leftRadioButtons.Contains(selectedRadioButton))
            {
                // This is a left radio button
                lastSelectedLeftRadioButton = selectedRadioButton;
            }
            else if (rightRadioButtons.Contains(selectedRadioButton))
            {
                // This is a right radio button
                lastSelectedRightRadioButton = selectedRadioButton;
            }

            if (lastSelectedLeftRadioButton != null && lastSelectedRightRadioButton != null)
            {
                int leftIndex = leftRadioButtons.IndexOf(lastSelectedLeftRadioButton);
                int rightIndex = rightRadioButtons.IndexOf(lastSelectedRightRadioButton);

                if (leftIndex >= 0 && rightIndex >= 0)
                {
                    PictureBox leftPictureBox = pictureBoxes[leftIndex];
                    PictureBox rightPictureBox = pictureBoxes[rightIndex + 4];

                    // Check if the pair has not been matched yet
                    if (!matchedPictureBoxes.Contains(leftPictureBox) && !matchedPictureBoxes.Contains(rightPictureBox))
                    {
                        // Retrieve the selected key and the value from the PictureBoxes
                        int selectedKey = int.Parse(leftPictureBox.Text.Split('-')[0].Trim()); // Extract selected key
                        string selectedValue = rightPictureBox.Text;

                        // Check if the selected key matches the value in the dictionary
                        if (callNumberMappings.ContainsKey(selectedKey) && callNumberMappings[selectedKey] == selectedValue)
                        {
                            // Correct match

                            // Disable the matching radio buttons
                            lastSelectedLeftRadioButton.Enabled = false;
                            lastSelectedRightRadioButton.Enabled = false;

                            // Change the color of the matching PictureBoxes to green
                            leftPictureBox.BackColor = Color.Green;
                            rightPictureBox.BackColor = Color.Green;

                            // Add matched items to the lists
                            matchedPictureBoxes.Add(leftPictureBox);
                            matchedPictureBoxes.Add(rightPictureBox);
                            matchedLeftRadioButtons.Add(lastSelectedLeftRadioButton);

                            correctMatches++;
                        }
                        else
                        {
                            // Incorrect match

                            // Change the color of the selected picture box on the right to red
                            rightPictureBox.BackColor = Color.Red;

                            // Allow the user to reselect the correct match on the right
                            lastSelectedRightRadioButton.Checked = false;
                        }

                        // Reset the last selected radio buttons
                        lastSelectedLeftRadioButton = null;
                        lastSelectedRightRadioButton = null;

                        if (correctMatches == 4)
                        {
                            // All matches complete
                            gameTimer.Stop(); // Stop the timer
                            DisplayCustomDialog(selectedDifficulty, timeTaken); 
                        }
                    }
                }
            }
        }
        #endregion

        #region Centers the text In each PictureBox
        // Paint event handler to center text in PictureBox
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Graphics g = e.Graphics;

            string text = pictureBox.Text;

            // Center the text
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            g.DrawString(text, pictureBox.Font, Brushes.Black, pictureBox.ClientRectangle, stringFormat);
        }
        #endregion

        #region Time Ticking Event
        // Timer tick event for game timer
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (totalTime > 0)
            {
                totalTime--;

                // Format the time in mm:ss
                int minutes = totalTime / 60;
                int seconds = totalTime % 60;
                string timeString = $"{minutes:D2}:{seconds:D2}";

                // Update the Label with the formatted time
                DisplayTimeTicklbl.Text = timeString;

                // Update the ProgressBar
                progressBar1.Value = (int)(((double)totalTime / ((4 - selectedDifficulty + 1) * 15)) * 100);
            }
            else
            {
                gameTimer.Stop();
                // Calculate the time taken
                int totalSeconds = (4 - selectedDifficulty + 1) * 15;
                int elapsedSeconds = totalSeconds - totalTime;
                timeTaken = new TimeSpan(0, 0, elapsedSeconds);
                GameOverForm gameOverForm = new GameOverForm();
                gameOverForm.Show();
            }
        }
        #endregion

        #region StartGameButton Click Event
        // Event handler for starting the game
        private void StartGameButton_Click(object sender, EventArgs e)
        {
            if (DifficultySelectercomboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a difficulty level before starting the game.");
                return;
            }

            Random random = new Random();

            // Shuffle the call number mappings
            var shuffledMappings = callNumberMappings.OrderBy(x => random.Next()).ToDictionary(item => item.Key, item => item.Value);

            // Select 4 random keys
            var selectedKeys = shuffledMappings.Keys.Take(4).ToList();

            // Shuffle the PictureBoxes for the values
            var shuffledPictureBoxes = pictureBoxes.Skip(4).OrderBy(x => random.Next()).ToList();

            // Display the selected keys in the first 4 PictureBox controls
            for (int i = 0; i < 4; i++)
            {
                int selectedKey = selectedKeys[i];
                int minRange = (selectedKey - 1) * 100;
                int maxRange = selectedKey * 100 - 1;
                int randomNumber = random.Next(minRange, maxRange + 1);

                // Combine the selected key and the generated random key
                string displayText = $"{selectedKey} - {randomNumber}";

                pictureBoxes[i].Text = displayText;
            }

            // Select 3 random values from the dictionary
            var dictionaryValues = shuffledMappings.Values.Except(selectedKeys.Select(key => shuffledMappings[key])).ToList();

            // Select 4 random values associated with the selected keys
            var selectedValues = new List<string>();

            for (int i = 0; i < 4; i++)
            {
                selectedValues.Add(shuffledMappings[selectedKeys[i]]);
            }

            while (selectedValues.Count < 7)
            {
                var randomValue = dictionaryValues[random.Next(dictionaryValues.Count)];
                if (!selectedValues.Contains(randomValue))
                {
                    selectedValues.Add(randomValue);
                }
            }

            // Display the selected values in random PictureBox controls (5-11)
            for (int i = 4; i < 11; i++)
            {
                shuffledPictureBoxes[i - 4].Text = selectedValues[i - 4];
            }

            // Set the selected difficulty
            selectedDifficulty = DifficultySelectercomboBox.SelectedIndex + 1;

            // Set the total time based on the selected difficulty
            int totalSeconds = (4 - selectedDifficulty + 1) * 15;
            totalTime = totalSeconds;

            // Enable all radio buttons
            foreach (RadioButton radioButton in leftRadioButtons)
            {
                radioButton.Enabled = true;
            }

            foreach (RadioButton radioButton in rightRadioButtons)
            {
                radioButton.Enabled = true;
            }

            // Start the game timer
            gameTimer.Start();
        }
        #endregion

        #region Selecting Difficulty Level
        // Event handler for difficulty level selection
        private void DifficultySelectercomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DifficultySelectercomboBox.SelectedIndex >= 0)
            {
                StartGameButton.Enabled = true; 
            }
            else
            {
                StartGameButton.Enabled = false;
            }
        }
        #endregion

        #region Display Achievment Badges
        // Method to display a custom dialog when the game is completed
        private void DisplayCustomDialog(int levelCompleted, TimeSpan timeTaken)
        {
            using (HalloweenCustomDialogForm customDialog = new HalloweenCustomDialogForm())
            {
                customDialog.StartPosition = FormStartPosition.CenterScreen;

                string message;
                System.Drawing.Image badgeImage;

                switch (levelCompleted)
                {
                    case 1:
                        //Display Bronze Badge
                        message = "Congratulations! You've earned a Bronze badge!"; //Complete level 1
                        badgeImage = Properties.Resources.halloweenThemedBronzeBadge;
                        break;
                    case 2:
                        //Display Silver Badge
                        message = "Congratulations! You've earned a Silver badge!"; //COmplete Level 2
                        badgeImage = Properties.Resources.HalloweenthemedSilverBadge;
                        break;
                    case 3:
                        //Display Gold Badge
                        message = "Congratulations! You've earned a Gold badge!"; //Complete Level 3
                        badgeImage = Properties.Resources.HalloweenThemedAchievementBadge;
                        break;
                    default:
                        message = "Congratulations! You've completed a level!";
                        badgeImage = null;
                        break;
                }

                //message += Environment.NewLine + "Time Taken: " + timeTaken.ToString(@"mm\:ss");

                customDialog.DialogText = message;
                customDialog.DialogImage = badgeImage;

                customDialog.ShowDialog();
            }
        }
        #endregion

        #region How to Play Event Button
        private void HowToPlayButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In Order To Complete The Game Please Match the Numbers (CallNumbers) On The Left With The Values (Descriptions) On The Right By CLicking Their Corresponding Radio Buttons");
        }
    }
    #endregion
}
//--------------------------------------------------------------------------------End Of File---------------------------------------------------------------------------------------//
