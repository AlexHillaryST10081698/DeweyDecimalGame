using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class ConfettiAnimation : Panel
{
    private List<ConfettiPiece> confettiPieces = new List<ConfettiPiece>();
    private Timer animationTimer = new Timer();

    public ConfettiAnimation()
    {
        DoubleBuffered = true;
        animationTimer.Interval = 50; 
        animationTimer.Tick += AnimationTimer_Tick;
        animationTimer.Start();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        foreach (ConfettiPiece piece in confettiPieces)
        {
            piece.Draw(e.Graphics);
        }
    }

    private void AnimationTimer_Tick(object sender, EventArgs e)
    {
        // Move and update the confetti pieces
        foreach (ConfettiPiece piece in confettiPieces)
        {
            piece.Update();
        }

        // Repaint the panel to show the updated confetti positions
        Invalidate();
    }

    public void AddConfetti(int count)
    {
        Random random = new Random();

        for (int i = 0; i < count; i++)
        {
            int x = random.Next(Width); //Random width
            int y = random.Next(Height); //Random Height
            Color color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));//Random Colours
            int speed = random.Next(1, 5); // The speed range
            int size = random.Next(5, 15); // The size range

            ConfettiPiece piece = new ConfettiPiece(x, y, color, speed, size);
            confettiPieces.Add(piece);
        }
    }
}
