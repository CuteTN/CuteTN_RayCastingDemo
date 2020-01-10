using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RayCastingDemo
{
    class Ray
    {
        public Point Source;
        public double Angle; // radian
        public Point CastPoint;
        public Pen RayPen;

        public Ray(Point Source, double Angle, Pen RayPen)
        {
            this.Source = Source;
            this.Angle = Angle;
            this.RayPen = RayPen;
        }

        public Point InfPoint()
        {
            Point result = new Point();
            result.X = (int)( Source.X + Utility.oo*Math.Cos(Angle) );
            result.Y = (int)( Source.Y + Utility.oo*Math.Sin(Angle) );
            return result;
        }

        public void Update(Point NewPos, List<Obstacle> Obstacles)
        {
            Source = NewPos;

            CastPoint = InfPoint();
            double best = Utility.oo;

            foreach(var obs in Obstacles)
            {
                Point CastTemp = obs.Cast(this);
                double DisTemp = Utility.Distance(CastTemp, Source);
                if( DisTemp < best )
                {
                    CastPoint = CastTemp;
                    best = DisTemp;
                }
            }
        }

        public void Show(Graphics g_)
        {
            g_.DrawLine(RayPen, Source, CastPoint);
        }
    }
}
