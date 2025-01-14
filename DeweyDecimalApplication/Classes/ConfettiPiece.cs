using System;
using System.Drawing;

public class ConfettiPiece
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public Color Color { get; private set; }
    public int Speed { get; private set; }
    public int Size { get; private set; }

    private static Random random = new Random();

    public ConfettiPiece(int x, int y, Color color, int speed, int size)
    {
        X = x;
        Y = y;
        Color = color;
        Speed = speed;
        Size = size;
    }

    public void Update()
    {
        // Move the confetti piece downwards
        Y += Speed;

        // If it goes out of bounds, reset its position
        if (Y > 500) // Adjust the Y coordinate as needed for your form's height
        {
            Y = -Size;
            X = random.Next(500); // Adjust the X coordinate as needed for your form's width
        }
    }

    public void Draw(Graphics g)
    {
        using (Brush brush = new SolidBrush(Color))
        {
            g.FillEllipse(brush, X, Y, Size, Size);
        }
    }
}
