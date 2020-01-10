using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RayCastingDemo
{
    public enum ObstacleType
    {
        Wall = 1,
        Circle = 2,
        Rectangle = 3,
        Custom = 4,
    }

    abstract class Obstacle
    {
        abstract public void Show(Graphics g_, Pen LinePen_);
        abstract public Point Cast(Ray Ray_);
        abstract public bool Touched(Point Pos_);
    }
}
