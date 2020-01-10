using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RayCastingDemo
{
    class Obstacle_Circle: Obstacle
    {
        public PointF Center;
        public double Radius;

        public Obstacle_Circle(PointF Center_, double Radius_, bool Reflective)
        {
            this.Center = Center_;
            this.Radius = Radius_;
            this.Reflective = Reflective;
        }

        public override void Show(Graphics g_, Pen LinePen_)
        {
            g_.DrawEllipse( LinePen_, Utility.BoundingRectangle(Center, Radius) );
        }

        public override bool Touched(PointF Pos_)
        {
            bool Result = false;

            if( Math.Abs(Utility.Distance(Pos_, Center) - Radius) <= 5 )
                Result = true;

            return Result;
        }

        public override PointF Cast(Ray Ray_)
        {
            // sync with my sketch :)
            PointF S = Ray_.Source;
            PointF E = Ray_.InfPoint();
            PointF O = this.Center;
            double r = this.Radius;

            // quadratic equation
            double a = Math.Pow( ( E.X - S.X ) , 2 ) + Math.Pow( ( E.Y - S.Y ) , 2 );
            double b = 2d*( ( E.X - S.X )*( S.X - O.X ) + ( E.Y - S.Y )*( S.Y - O.Y ) );
            double c = Math.Pow( ( S.X - O.X ) , 2 ) + Math.Pow( ( S.Y - O.Y ) , 2 ) - r*r;
            double delta = b*b - 4*a*c;

            if(delta < 0)
                return E;

            double t;
            PointF Result;

            t = ( -b - Math.Sqrt(delta) ) / (2d*a);
            if( t>0 )
            {
                Result = new PointF( (float)(S.X + t*(E.X - S.X)), (float)(S.Y + t*(E.Y - S.Y)) );
                return Result;
            }

            t = ( -b + Math.Sqrt(delta) ) / (2d*a);
            if( t>0 )
            {
                Result = new PointF( (float)(S.X + t*(E.X - S.X)), (float)(S.Y + t*(E.Y - S.Y)) );
                return Result;
            }

            return Ray_.InfPoint();
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

            double Angle = 2*Utility.GetDir(Center, Source) + Math.PI - Ray_.Angle;
            Source = Utility.MovePointOffset(Source, Angle);

            Ray Result = new Ray(Source, Angle, Ray_.RayPen, Ray_.ReflectingEnergy - 1);
            return Result;
        }

    }
}
