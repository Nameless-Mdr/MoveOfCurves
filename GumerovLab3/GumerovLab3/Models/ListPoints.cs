using System.Collections.Generic;
using System.Drawing;

namespace GumerovLab3.Models;

public struct ListPoints
{
    // список точек
    public List<Point> List = new List<Point>();

    // флаги нарисованных фигур
    public bool Polygon { get; set; } = false;
    public bool Curve { get; set; } = false;
    public bool Beziers { get; set; } = false;
    public bool FillCurve { get; set; } = false;

    // радиус точки
    public int R { get; set; } = 5;

    // цвета точки и линий
    public Color ColorPoint { get; set; } = Color.Black;
    public Color ColorSpline { get; set; } = Color.Brown;

    // смещение по иксу и игрику на форме для всей фигуры
    public int Ox = 0;
    public int Oy = 0;

    // смещение по иксу и игрику на форме для каждой точки отдельно
    public (int, int)[] Dirs = new (int, int)[] { };

    public ListPoints() { }

    public void Clear()
    {
        List.Clear();
        Polygon = Curve = Beziers = FillCurve = false;
    }

    public Point[] ToArray() => List.ToArray();
}