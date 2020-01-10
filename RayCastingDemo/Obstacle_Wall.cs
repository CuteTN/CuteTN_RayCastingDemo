using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms; // message box only

namespace RayCastingDemo
{
    class Obstacle_Wall: Obstacle
    {
        PointF StartPos;
        PointF EndPos;

        public Obstacle_Wall(PointF StartPoint_, PointF EndPoint_, bool Reflective)
        {
            this.StartPos = StartPoint_;
            this.EndPos = EndPoint_;
            this.Reflective = Reflective;
        }

        public override void Show(Graphics g_, Pen LinePen_)
        {
            g_.DrawLine(LinePen_, StartPos, EndPos);
        }

        public override bool Touched(PointF Pos_)
        {
            bool Result = false;
            if( Utility.Distance(StartPos, Pos_) + Utility.Distance(EndPos, Pos_) <= Utility.Distance(StartPos, EndPos) + 5 )
                Result = true;

            return Result;
        }

        public override PointF Cast(Ray Ray_)
        {
            // https://en.wikipedia.org/wiki/Line–line_intersection
            PointF p1 = Ray_.Source;
            PointF p2 = Ray_.InfPoint();
            PointF p3 = StartPos;
            PointF p4 = EndPos;

            try
            {
                double t =   ( (double)(p1.X-p3.X)*(p3.Y-p4.Y) - (p1.Y-p3.Y)*(p3.X-p4.X) ) / ( (p1.X-p2.X)*(p3.Y-p4.Y) - (p1.Y-p2.Y)*(p3.X-p4.X) );
                double u = - ( (double)(p1.X-p2.X)*(p1.Y-p3.Y) - (p1.Y-p2.Y)*(p1.X-p3.X) ) / ( (p1.X-p2.X)*(p3.Y-p4.Y) - (p1.Y-p2.Y)*(p3.X-p4.X) );

                if( t>=0 && u>=0 && u<=1 )
                {
                    PointF Result = new PointF( (float)(p3.X + u*(p4.X - p3.X)), (float)(p3.Y + u*(p4.Y - p3.Y)) );
                    // PointF result = new PointF( (float)(p1.X + t*(p2.X - p1.X)), (float)(p1.Y + t*(p2.Y - p1.Y)) );
                    return Result;
                }
                else
                {
                    return p2;
                }
            }
            catch
            {
                return p2;
            }
        }

        public override Ray ReflectedRay(Ray Ray_)
        {
            if(! Reflective )
                return null;
            if( Ray_.ReflectingEnergy == 0 )
                return null;
            
            PointF Source = this.Cast(Ray_);
            if( Source == Ray_.InfPoint() )
                return null;

            double Angle = 2*Utility.GetDir(StartPos, EndPos) - Ray_.Angle;
            Source = Utility.MovePointOffset(Source, Angle);
        
            Ray Result = new Ray(Source, Angle, Ray_.RayPen, Ray_.ReflectingEnergy - 1);
            return Result;
        }

    }
}
