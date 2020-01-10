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
        Point StartPos;
        Point EndPos;

        public Obstacle_Wall(Point StartPoint_, Point EndPoint_)
        {
            this.StartPos = StartPoint_;
            this.EndPos = EndPoint_;
        }

        public override void Show(Graphics g_, Pen LinePen_)
        {
            g_.DrawLine(LinePen_, StartPos, EndPos);
        }

        public override bool Touched(Point Pos_)
        {
            bool Result = false;
            if( Utility.Distance(StartPos, Pos_) + Utility.Distance(EndPos, Pos_) <= Utility.Distance(StartPos, EndPos) + 5 )
                Result = true;

            return Result;
        }

        public override Point Cast(Ray Ray_)
        {
            // https://en.wikipedia.org/wiki/Line–line_intersection
            Point p1 = Ray_.Source;
            Point p2 = Ray_.InfPoint();
            Point p3 = StartPos;
            Point p4 = EndPos;

            try
            {
                double t =   ( (double)(p1.X-p3.X)*(p3.Y-p4.Y) - (p1.Y-p3.Y)*(p3.X-p4.X) ) / ( (p1.X-p2.X)*(p3.Y-p4.Y) - (p1.Y-p2.Y)*(p3.X-p4.X) );
                double u = - ( (double)(p1.X-p2.X)*(p1.Y-p3.Y) - (p1.Y-p2.Y)*(p1.X-p3.X) ) / ( (p1.X-p2.X)*(p3.Y-p4.Y) - (p1.Y-p2.Y)*(p3.X-p4.X) );

                if( t>=0 && u>=0 && u<=1 )
                {
                    Point result = new Point( (int)(p3.X + u*(p4.X - p3.X)), (int)(p3.Y + u*(p4.Y - p3.Y)) );
                    // Point result = new Point( (int)(p1.X + t*(p2.X - p1.X)), (int)(p1.Y + t*(p2.Y - p1.Y)) );
                    return result;
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

    }
}
