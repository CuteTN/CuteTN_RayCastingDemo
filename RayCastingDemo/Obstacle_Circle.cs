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
        public Point Center;
        public double Radius;

        public Obstacle_Circle(Point Center_, double Radius_)
        {
            this.Center = Center_;
            this.Radius = Radius_;
        }

        public override void Show(Graphics g_, Pen LinePen_)
        {
            g_.DrawEllipse( LinePen_, Utility.BoundingRectangle(Center, Radius) );
        }

        public override bool Touched(Point Pos_)
        {
            bool Result = false;

            if( Math.Abs(Utility.Distance(Pos_, Center) - Radius) <= 5 )
                Result = true;

            return Result;
        }

        public override Point Cast(Ray Ray_)
        {
            // sync with my sketch :)
            Point S = Ray_.Source;
            Point E = Ray_.InfPoint();
            Point O = this.Center;
            double r = this.Radius;

            // quadratic equation
            double a = Math.Pow( ( E.X - S.X ) , 2 ) + Math.Pow( ( E.Y - S.Y ) , 2 );
            double b = 2d*( ( E.X - S.X )*( S.X - O.X ) + ( E.Y - S.Y )*( S.Y - O.Y ) );
            double c = Math.Pow( ( S.X - O.X ) , 2 ) + Math.Pow( ( S.Y - O.Y ) , 2 ) - r*r;
            double delta = b*b - 4*a*c;

            if(delta < 0)
                return E;

            double t;
            Point Result;

            t = ( -b - Math.Sqrt(delta) ) / (2d*a);
            if( t>0 )
            {
                Result = new Point( (int)(S.X + t*(E.X - S.X)), (int)(S.Y + t*(E.Y - S.Y)) );
                return Result;
            }

            t = ( -b + Math.Sqrt(delta) ) / (2d*a);
            if( t>0 )
            {
                Result = new Point( (int)(S.X + t*(E.X - S.X)), (int)(S.Y + t*(E.Y - S.Y)) );
                return Result;
            }

            return Ray_.InfPoint();
        }
    }
}
