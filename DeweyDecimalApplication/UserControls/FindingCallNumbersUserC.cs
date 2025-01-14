using DeweyDecimalApplication.Classes;
using DeweyDecimalApplication.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DeweyDecimalApplication.UserControls
{
    public partial class FindingCallNumbersUserC : UserControl
    {
        //Variables
        private RedBlackTree<string> deweyTree;
        private RedBlackTree<string>.Node root;
        private Random random = new Random();

        //--------------------------------------------------------------------------------Left Side Radio Buttons--------------------------------------------------------------------------------------------------------------//
        private RadioButton lastSelectedLeftRadioButton;
        //-------------------------------------------------------------------------------Right-side Radio Buttons -------------------------------------------------------------------------------------------------------------//
        private RadioButton lastSelectedRightRadioButton;
        //-------------------------------------------------------------------------------- Data Structurews --------------------------------------------------------------------------------------------------------------------//
        private List<PictureBox> pictureBoxes;
        private List<PictureBox> matchedPictureBoxes;
        private List<RadioButton> matchedLeftRadioButtons;
        private List<RadioButton> rightRadioButtons;
        private List<RadioButton> leftRadioButtons;
        private string randomThirdLevelCallNumber;
        private string lastSelectedLeftCallNumber;
        private DeweyNode associatedLevel2EntryForPictureBox1;
        private DeweyNode randomThirdLevelEntry;
        private int numberOfMatches = 0;
        private bool gameStarted = false;
        private int countdownSeconds;
        
        //----------------------------------------------------------------------------------Constructor ----------------------------------------------------------------------------------------------------------------------//

        public FindingCallNumbersUserC()
        {
            InitializeComponent();
            //Loads the Dewey Decimal Data from json file into the tree at run time 
            LoadDeweyDecimalDataIntoTree();
            deweyTree.PrintTree();
            // Display a random third-level entry in TextBox1
            // Subscribe the PictureBox_Paint event handler to the Paint event of pictureBox1
            pictureBox1.Paint += PictureBox_Paint;
            pictureBox2.Paint += PictureBox_Paint;
            pictureBox3.Paint += PictureBox_Paint;
            pictureBox4.Paint += PictureBox_Paint;
            pictureBox5.Paint += PictureBox_Paint;

            pictureBoxes = new List<PictureBox> { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 };
            matchedPictureBoxes = new List<PictureBox>();
            matchedLeftRadioButtons = new List<RadioButton>();
            rightRadioButtons = new List<RadioButton> { radioButton2, radioButton3, radioButton4, radioButton5 };
            // Set radio buttons initially disabled
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            radioButton5.Enabled = false;
            // Initialize timer properties
            timer1.Interval = 1000; // Timer interval in milliseconds (1 second)
            timer1.Tick += Timer_Tick; // Attach event handler for timer tick
            progressBar1.Maximum = 100; // Maximum value for the progress bar
            progressBar1.Value = progressBar1.Maximum; // Set initial value to maximum
        }

        #region Loads the data into the tree
        private void LoadDeweyDecimalDataIntoTree()
        {
            deweyTree = new RedBlackTree<string>();
            string filePath = "DeweyData.json"; // Adjust the path to your JSON file

            try
            {
                string jsonContent = File.ReadAllText(filePath);
                List<DeweyNode> deweyNodes = JsonConvert.DeserializeObject<List<DeweyNode>>(jsonContent);

                foreach (var deweyNode in deweyNodes)
                {
                    InsertNode(deweyNode, null, 0); // Insert the nodes into the tree
                }

                Console.WriteLine("Dewey Decimal data loaded successfully.");

                // Output the tree contents after loading
                Console.WriteLine("Tree contents after loading:");
                Console.WriteLine(deweyTree.GetTreeContents());

                deweyTree.PrintTree(); // Print tree after loading
                root = deweyTree.GetRoot();
                Console.WriteLine($"Root Key: {root.Key}, Depth: {root.Depth}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading Dewey Decimal data: {ex.Message}");
                MessageBox.Show($"Error loading Dewey Decimal data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Inserts Data into Tree
        private void InsertNode(DeweyNode node, RedBlackTree<string>.Node parent, int parentLevel)
        {
            int currentLevel = parentLevel + 1; // Increment the level for each child

            RedBlackTree<string>.Node newNode = new RedBlackTree<string>.Node
            {
                Key = node.CallNumbers,
                Value = node,
                IsRed = true,
                Depth = currentLevel // Set the depth for the new node
            };

            if (parent == null)
            {
                root = newNode;
            }
            else
            {
                int cmp = newNode.Key.CompareTo(parent.Key);
                if (cmp < 0)
                {
                    parent.Left = newNode;
                }
                else if (cmp > 0)
                {
                    parent.Right = newNode;
                }
                else
                {
                    // Handle duplicates if necessary
                }
            }

            // Recursively insert children with the correct depth
            foreach (var childNode in node.Children)
            {
                InsertNode(childNode, newNode, currentLevel);
            }

            deweyTree.Insert(newNode.Key, newNode.Value);
        }
        #endregion

        #region Handle the Time Ticking
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (countdownSeconds > 0)
            {
                countdownSeconds--;

                // Format the remaining time as MM:SS
                string formattedTime = $"{countdownSeconds / 60:00}:{countdownSeconds % 60:00}";

                DisplayTimeTicklbl.Text = formattedTime;
                progressBar1.Value = (countdownSeconds * 100) / GetMaxTime(); // Update progress bar
            }
            else
            {
                // Time is up, handle accordingly
                timer1.Stop(); // Stop the timer
                DisplayTimeTicklbl.Text = "Time's up!"; //Prompts the user that the time has run out
                GameOverForm gameOverForm = new GameOverForm();
                gameOverForm.Show();
                progressBar1.Value = 0; // resets the progress bar to zero

            }
        }
        #endregion

        #region Allocate time to Difficulty Level
        //Method to handle the allocated time 
        private int GetMaxTime() //Sets the maximum time for eacgh level 
        {
            // Get the maximum time based on the selected difficulty level
            switch (DifficultySelectercomboBox.SelectedItem.ToString())
            {
                case "Level 1":
                    return 30; // Level 1: 30 seconds
                case "Level 2":
                    return 20; // Level 2: 20 seconds
                case "Level 3":
                    return 10; // Level 3: 10 seconds
                default:
                    return 30; // Default to Level 1
            }
        }
        #endregion

        #region Start Game Button
        // Event Handler for Start Game Button Clicked  
        private void StartGameBtn_Click(object sender, EventArgs e)
        {
            // Check if a difficulty level is selected
            if (DifficultySelectercomboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a difficulty level before starting the game.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if no difficulty level is selected
            }
            // Set gameStarted to true when the game starts
            gameStarted = true;
            
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;
            radioButton5.Enabled = true;

            // Set countdown seconds based on the selected difficulty level
            countdownSeconds = GetMaxTime();

            // Start the timer
            timer1.Start();

            // Get a random third-level entry
            randomThirdLevelEntry = GetRandomThirdLevelEntry();
            // Save the call number
            randomThirdLevelCallNumber = randomThirdLevelEntry.CallNumbers;

            // Display the selected entry description on PictureBox 1
            DisplayDescriptionOnPictureBox(pictureBox1, randomThirdLevelEntry.Description);

            // Get all level 1 entries
            List<DeweyNode> level1Entries = GetLevel1Entries();

            // Select a random level 1 entry for each PictureBox (2-5)
            DisplayRandomLevel1Entries(level1Entries, randomThirdLevelEntry);
        }
        #endregion

        #region Method to get Random 3rd Level Entry
        //Retrieves Random Entry
        private DeweyNode GetRandomEntry(List<DeweyNode> entries)
        {
            // Check if there are any entries in the list
            if (entries.Count > 0)
            {
                // Select a random index
                Random random = new Random();
                int randomIndex = random.Next(entries.Count);

                // Return the randomly selected entry
                return entries[randomIndex];
            }

            return null;
        }
        #endregion

        #region Displays The Level 1 Entries into PictureBoxes 2-5
        private void DisplayRandomLevel1Entries(List<DeweyNode> level1Entries, DeweyNode randomThirdLevelEntry)
        {
            // Randomly select 4 level 1 entries
            List<DeweyNode> selectedLevel1Entries = new List<DeweyNode>();
            for (int i = 0; i < 4; i++)
            {
                DeweyNode randomLevel1Entry = GetRandomEntry(level1Entries);

                // Save the selected entry
                selectedLevel1Entries.Add(randomLevel1Entry);

                // Remove the displayed entry to avoid duplicates
                level1Entries.Remove(randomLevel1Entry);
            }

            // Sort the selected level 1 entries by call number
            selectedLevel1Entries.Sort((entry1, entry2) => entry1.CallNumbers.CompareTo(entry2.CallNumbers));

            // Display sorted level 1 entries on PictureBoxes 2-5
            for (int i = 2; i <= 5; i++)
            {
                // Get a level 1 entry
                DeweyNode level1Entry = selectedLevel1Entries[i - 2]; // Adjust the index

                // Display the selected entry call number and description on the respective PictureBox
                PictureBox pictureBox = GetPictureBoxByIndex(i);
                DisplayCallNumberAndDescriptionOnPictureBox(pictureBox, level1Entry);

                // If this is the PictureBox corresponding to the random third-level entry, save its level 1 entry
                if (i == randomThirdLevelEntry.AssociatedPictureBoxIndex)
                {
                    randomThirdLevelEntry.AssociatedLevel1Entry = level1Entry;
                }
            }
        }
        #endregion

        #region Displays Call Number and Description to Pictureboxes 2-5
        // Displays the text to pictureboxes 
        private void DisplayCallNumberAndDescriptionOnPictureBox(PictureBox pictureBox, DeweyNode entry)
        {
            pictureBox.Text = $"{entry.CallNumbers} - {entry.Description}";
            pictureBox.Invalidate(); // Trigger repaint to update the displayed text
        }
        #endregion

        #region retireves A 3rd level entries
        private DeweyNode GetRandomThirdLevelEntry()
        {
            // Get all third-level entries
            List<DeweyNode> thirdLevelEntries = GetThirdLevelEntries();

            // Select a random third-level entry
            DeweyNode randomThirdLevelEntry = GetRandomEntry(thirdLevelEntries);

            // Save the index of the PictureBox corresponding to this third-level entry
            randomThirdLevelEntry.AssociatedPictureBoxIndex = 1; // PictureBox1
            return randomThirdLevelEntry;
        }
        #endregion

        #region Retrieves All level 1 entries
        private List<DeweyNode> GetLevel1Entries()
        {
            // Get all level 1 entries
            DeweyMultiLevelData deweyData = new DeweyMultiLevelData();
            List<DeweyNode> allEntries = deweyData.GetData();

            // Extract all level 1 entries
            List<DeweyNode> level1Entries = new List<DeweyNode>();
            foreach (var entry in allEntries)
            {
                level1Entries.Add(entry);
            }

            return level1Entries;
        }
        #endregion

        #region retireves All 3rd level entries
        private List<DeweyNode> GetThirdLevelEntries()
        {
            // Get all third-level entries
            DeweyMultiLevelData deweyData = new DeweyMultiLevelData();
            List<DeweyNode> allEntries = deweyData.GetData();

            // Extract all third-level entries
            List<DeweyNode> thirdLevelEntries = new List<DeweyNode>();
            foreach (var entry in allEntries)
            {
                foreach (var childEntry in entry.Children)
                {
                    thirdLevelEntries.AddRange(childEntry.Children);
                }
            }

            return thirdLevelEntries;
        }
        #endregion

        #region fetch corresponding picturebox by their index 
        private PictureBox GetPictureBoxByIndex(int index)
        {
            string pictureBoxName = "pictureBox" + index;
            return Controls.Find(pictureBoxName, true).FirstOrDefault() as PictureBox;
        }
        #endregion
        #region Displays Descripton onto PictureBox1
        private void DisplayDescriptionOnPictureBox(PictureBox pictureBox, string description)
        {
            // Assuming you have a PictureBox
            pictureBox.Text = description;
            pictureBox.Invalidate(); // Trigger repaint to update the displayed text
        }
        #endregion
        #region Displays the data onto the pictureboxes
        //Method to Display the Data onto the pictureboxes 
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

        #region Handle Radio Button Clicks
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {

            RadioButton selectedRadioButton = (RadioButton)sender;

            // Check if the radio button is checked
            if (selectedRadioButton.Checked)
            {
                if (selectedRadioButton == radioButton1)
                {
                    // This is the left radio button
                    lastSelectedLeftRadioButton = selectedRadioButton;

                    // Update the left call number variable
                    lastSelectedLeftCallNumber = ExtractCallNumber(pictureBoxes[0].Text);
                }
                else if (rightRadioButtons.Contains(selectedRadioButton))
                {
                    // This is a right radio button
                    lastSelectedRightRadioButton = selectedRadioButton;
                }

                if (lastSelectedLeftRadioButton != null && lastSelectedRightRadioButton != null)
                {
                    int leftIndex = 0; // Left radio button is always at index 0
                    int rightIndex = rightRadioButtons.IndexOf(lastSelectedRightRadioButton);

                    PictureBox leftPictureBox = pictureBoxes[leftIndex];
                    PictureBox rightPictureBox = pictureBoxes[rightIndex + 1]; // Adjust the index for the right PictureBox

                    // Check if the PictureBoxes are not null
                    if (leftPictureBox != null && rightPictureBox != null)
                    {
                        // Extract first digit from the left call number
                        int leftFirstDigit = ExtractFirstDigitFromCallNumber(randomThirdLevelCallNumber);

                        // Extract first digit from the right call number
                        int rightFirstDigit = ExtractFirstDigitFromCallNumber(rightPictureBox.Text);

                        // Debugging: Display the extracted first digits
                        Debug.WriteLine($"Left First Digit: {leftFirstDigit}, Right First Digit: {rightFirstDigit}");

                        // Compare the first digits
                        if (leftFirstDigit == rightFirstDigit)
                        {
                            // Correct 1st match
                            leftPictureBox.BackColor = Color.Green;
                            rightPictureBox.BackColor = Color.Green;

                            // Add matched items to the lists
                            matchedPictureBoxes.Add(leftPictureBox);
                            matchedPictureBoxes.Add(rightPictureBox);
                            matchedLeftRadioButtons.Add(lastSelectedLeftRadioButton);

                            // Optional: Show a message box for debugging purposes
                            MessageBox.Show("Congratulations! You've completed the Level1!", "Debug Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Display new Level 2 entries
                            DisplayNewLevel2Entries(randomThirdLevelCallNumber);

                            // Increment the number of matches
                            numberOfMatches++;

                            // Check if the user has completed the second match
                            if (numberOfMatches == 2)
                            {
                                // Game over, display appropriate message
                                if (leftFirstDigit == rightFirstDigit)
                                {
                                    MessageBox.Show("Congratulations! You've completed the second match. Correct! Game Over!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    timer1.Stop(); // Stop the timer
                                    // Clear the matched items
                                    matchedPictureBoxes.Clear();
                                    matchedLeftRadioButtons.Clear();
                                    // Allow the user to reselect the correct match on the right
                                    lastSelectedRightRadioButton.Checked = false;
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect match. Game Over!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                                // Optionally, you can reset the game or perform other actions here
                            }

                            // Clear the matched items
                            matchedPictureBoxes.Clear();
                            matchedLeftRadioButtons.Clear();
                        }
                        else
                        {
                            // Incorrect match
                            leftPictureBox.BackColor = Color.Red;
                            rightPictureBox.BackColor = Color.Red;

                            // Allow the user to reselect the correct match on the right
                            lastSelectedRightRadioButton.Checked = false;

                            // Debugging: Display a message for incorrect match
                            Debug.WriteLine("Incorrect match! Please try again.");

                            // Optional: Show a message box for debugging purposes
                            MessageBox.Show("Incorrect match! Please try again.", "Debug Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            DisplayNewLevel2Entries(randomThirdLevelCallNumber);
                        }
                    }

                    // Reset the last selected radio buttons
                    lastSelectedLeftRadioButton.Checked = false;
                    lastSelectedRightRadioButton.Checked = false;
                    lastSelectedLeftRadioButton = null;
                    lastSelectedRightRadioButton = null;
                    lastSelectedLeftCallNumber = null; // Reset the left call number
                }
            }
        }
        #endregion

        #region Extracts 1st Digit
        private int ExtractFirstDigitFromCallNumber(string callNumber)
        {
            if (!string.IsNullOrEmpty(callNumber))
            {
                // Find the first digit in the call number
                foreach (char c in callNumber)
                {
                    if (char.IsDigit(c))
                    {
                        return int.Parse(c.ToString());
                    }
                }
            }

            return -1; // Return -1 if no digit is found
        }
        #endregion

        #region Extracts First 2 Digits
        private string ExtractFirstTwoDigitsFromCallNumber(string callNumber)
        {
            if (!string.IsNullOrEmpty(callNumber) && callNumber.Length >= 2)
            {
                // Take the first two characters of the call number
                return callNumber.Substring(0, 2);
            }

            return null; // Return null if the call number is empty or doesn't have at least two characters
        }
        #endregion

        //Extracts any digits from the text
        private string ExtractCallNumber(string text)
        {
            // Extract digits from the text
            return new string(text.Where(char.IsDigit).ToArray());
        }
        #region Displays Level 2 entries to pictureboxes 2-5
        private void DisplayNewLevel2Entries(string firstTwoDigits)
        {
            // Extract the first two digits of randomThirdLevelCallNumber
            string firstTwoDigitsVariable = randomThirdLevelCallNumber.Substring(0, 2);

            // Display the first 2 digits of randomThirdLevelCallNumber in the debugger at the beginning of the method
            Debug.WriteLine($"First 2 digits of randomThirdLevelCallNumber in DisplayNewLevel2Entries(): {firstTwoDigitsVariable}");

            // Clear the matched items
            matchedPictureBoxes.Clear();
            matchedLeftRadioButtons.Clear();

            // Get all level 2 entries
            List<DeweyNode> level2Entries = GetLevel2Entries();

            // Find the Level 2 entry associated with the random third-level entry
            DeweyNode associatedLevel2Entry = level2Entries.FirstOrDefault(entry => entry.CallNumbers.StartsWith(firstTwoDigitsVariable));

            // Create a list to store all four entries
            List<DeweyNode> allEntries = new List<DeweyNode>();

            if (associatedLevel2Entry != null)
            {
                // Add the associated level 2 entry to the list
                allEntries.Add(associatedLevel2Entry);

                // Select three other random level 2 entries excluding the associated one
                List<DeweyNode> otherLevel2Entries = level2Entries.Where(entry => entry != associatedLevel2Entry).ToList();
                otherLevel2Entries = otherLevel2Entries.OrderBy(x => random.Next()).Take(3).ToList();

                // Add the other three random level 2 entries to the list
                allEntries.AddRange(otherLevel2Entries);

                // Sort the list numerically by call number
                allEntries.Sort((entry1, entry2) => entry1.CallNumbers.CompareTo(entry2.CallNumbers));

                // Display all four entries on PictureBoxes 2-5
                for (int i = 2; i <= 5; i++)
                {
                    PictureBox pictureBox = GetPictureBoxByIndex(i);
                    DisplayCallNumberAndDescriptionOnPictureBox(pictureBox, allEntries[i - 2]);
                }
            }
            else
            {
                // Handle the case when no Level 2 entry is found for the given first two digits
                Debug.WriteLine("No Level 2 entry found for the given first two digits.");
            }

            // Reset the background color of all PictureBoxes except PictureBox1
            for (int i = 2; i <= 5; i++)
            {
                PictureBox pictureBox = GetPictureBoxByIndex(i);
                pictureBox.BackColor = Color.White;
            }
        }
        #endregion

        #region gets Level 2 Entries
        private List<DeweyNode> GetLevel2Entries()
        {
            // Get all level 1 entries
            List<DeweyNode> level1Entries = GetLevel1Entries();

            // Extract all level 2 entries
            List<DeweyNode> level2Entries = new List<DeweyNode>();
            foreach (var level1Entry in level1Entries)
            {
                foreach (var childEntry in level1Entry.Children)
                {
                    level2Entries.Add(childEntry);
                }
            }

            // Select a random order for level 2 entries
            level2Entries = level2Entries.OrderBy(x => random.Next()).ToList();

            // Sort the list by call number
            level2Entries.Sort((entry1, entry2) => entry1.CallNumbers.CompareTo(entry2.CallNumbers));

            return level2Entries;
        }
        #endregion
        #region How to Play Button
        private void HowToPlayButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In Order To Complete The Game Please Match the Description On The Left With The Number (Call Number) and Value (Descriptions) On The Right By CLicking Their Corresponding Radio Buttons", "How To Play", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
//----------------------------------------------------------------------------------------End Of File ---------------------------------------------------------------------------------------------------------------//
