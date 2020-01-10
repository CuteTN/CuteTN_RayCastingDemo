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
        public PointF Source;
        public double Angle; // radian
        public PointF CastPoint;
        public Pen RayPen;
        public int ReflectingEnergy;
        
        public Ray ReflectedRay = null;

        public Ray(PointF Source, double Angle, Pen RayPen, int ReflectingEnergy)
        {
            this.Source = Source;
            this.Angle = Angle;
            this.RayPen = RayPen;
            this.ReflectingEnergy = ReflectingEnergy;
        }

        public PointF InfPoint()
        {
            PointF result = new PointF();
            result.X = (float)( Source.X + Utility.oo*Math.Cos(Angle) );
            result.Y = (float)( Source.Y + Utility.oo*Math.Sin(Angle) );
            return result;
        }

        public void Update(PointF NewPos, List<Obstacle> Obstacles)
        {
            Source = NewPos;

            CastPoint = InfPoint();
            double best = Utility.oo;
            ReflectedRay = null;

            foreach(var obs in Obstacles)
            {
                PointF CastTemp = obs.Cast(this);
                double DisTemp = Utility.Distance(CastTemp, Source);
                if( DisTemp < best )
                {
                    CastPoint = CastTemp;
                    ReflectedRay = obs.ReflectedRay(this);
                    if( ReflectedRay != null )
                    {
                        ReflectedRay?.Update(ReflectedRay.Source, Obstacles);
                    }
                    best = DisTemp;
                }
            }
        }

        public void Show(Graphics g_)
        {
            g_.DrawLine(RayPen, Source, CastPoint);
            ReflectedRay?.Show(g_);
        }
    }
}
