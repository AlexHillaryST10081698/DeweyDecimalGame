using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class HalloweenAnimation : Panel
{
    private List<HalloweenObject> animationObjects = new List<HalloweenObject>();
    private Timer animationTimer = new Timer();

    public HalloweenAnimation()
    {
        DoubleBuffered = true; // Enable double buffering for smoother animation
        animationTimer.Interval = 50; // Set the animation update interval to 50 milliseconds
        animationTimer.Tick += AnimationTimer_Tick; // Attach the event handler for animation updates
        animationTimer.Start(); // Start the animation timer
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Render the Halloween objects on the panel
        foreach (HalloweenObject obj in animationObjects)
        {
            obj.Draw(e.Graphics);
        }
    }

    private void AnimationTimer_Tick(object sender, EventArgs e)
    {
        // Move and update the animation objects in the list
        foreach (HalloweenObject obj in animationObjects)
        {
            obj.Update();
        }

        // Repaint the panel to show the updated animation positions
        Invalidate();
    }

    // Method to add a falling pumpkin to the animation
    public void AddFallingPumpkin(int x, int speed)
    {
        HalloweenObject pumpkin = new HalloweenObject(this, x, 0, speed); // Create a new HalloweenObject
        animationObjects.Add(pumpkin); // Add the object to the animation list
    }

    // Method to clear all animation objects from the list
    public void ClearAnimationObjects()
    {
        animationObjects.Clear();
    }
}
