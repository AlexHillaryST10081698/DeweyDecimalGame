using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class HalloweenObject
{
    // Properties to store the position and speed of the Halloween object
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Speed { get; private set; }

    private static Random random = new Random(); 
    private HalloweenAnimation parentPanel; 

    // Constructor for initializing the HalloweenObject
    public HalloweenObject(HalloweenAnimation panel, int x, int y, int speed)
    {
        parentPanel = panel;
        X = x;
        Y = y;
        Speed = speed;
    }

    // Update the object's position
    public void Update()
    {
        Y += Speed;

        // If the object goes off the screen, reset its position
        if (Y > parentPanel.Height)
        {
            Y = -30; // Move the object above the panel
            X = random.Next(parentPanel.Width - 30); // Randomly position the object horizontally
        }
    }

    // Draw the object using the provided Graphics object
    public void Draw(Graphics g)
    {
        // Define constants for the pumpkin shape
        int pumpkinSize = 30;
        int stemHeight = 10;
        int stemWidth = 5;

        // Draw the pumpkin body (an orange ellipse)
        g.FillEllipse(Brushes.Orange, X, Y, pumpkinSize, pumpkinSize);

        // Draw the eyes and mouth (black ellipses)
        int eyeSize = 4;
        g.FillEllipse(Brushes.Black, X + pumpkinSize / 4, Y + pumpkinSize / 4, eyeSize, eyeSize);
        g.FillEllipse(Brushes.Black, X + pumpkinSize * 3 / 4 - eyeSize, Y + pumpkinSize / 4, eyeSize, eyeSize);
        g.FillEllipse(Brushes.Black, X + pumpkinSize / 2 - eyeSize / 2, Y + pumpkinSize * 2 / 3, eyeSize, eyeSize);

        // Draw the stem (a brown rectangle)
        g.FillRectangle(Brushes.Brown, X + pumpkinSize / 2 - stemWidth / 2, Y - stemHeight, stemWidth, stemHeight);
    }
}
