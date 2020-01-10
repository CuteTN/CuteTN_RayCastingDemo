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
        public bool Reflective = false;

        abstract public void Show(Graphics g_, Pen LinePen_);
        abstract public PointF Cast(Ray Ray_);
        abstract public bool Touched(PointF Pos_);
        abstract public Ray ReflectedRay(Ray Ray_);
    }
}
