using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DeweyDecimalApplication.Classes
{
    internal class LineDrawing
    {
        private List<Line> lines = new List<Line>();

        public void AddLine(Point start, Point end)
        {
            lines.Add(new Line(start, end));
        }

        public void DrawLines(Graphics g)
        {
            foreach (var line in lines)
            {
                g.DrawLine(Pens.Black, line.Start, line.End);
            }
        }

        public void ClearLines()
        {
            lines.Clear();
        }
    }
}

internal class Line
{
    public Point Start { get; }
    public Point End { get; }

    public Line(Point start, Point end)
    {
        Start = start;
        End = end;
    }
}
