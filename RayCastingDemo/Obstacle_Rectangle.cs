using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RayCastingDemo
{
    class Obstacle_Rectangle: Obstacle
    {
        Obstacle_Wall[] Sides = new Obstacle_Wall[4];
        Rectangle DrawingRectangle;


        public Obstacle_Rectangle(Point Corner1_, Point Corner2_)
        {
            Point A = Corner1_;
            Point B = new Point(Corner1_.X, Corner2_.Y);
            Point C = Corner2_;
            Point D = new Point(Corner2_.X, Corner1_.Y);

            Sides[0] = new Obstacle_Wall(A, B);
            Sides[1] = new Obstacle_Wall(B, C);
            Sides[2] = new Obstacle_Wall(C, D);
            Sides[3] = new Obstacle_Wall(D, A);

            DrawingRectangle = new Rectangle();
            DrawingRectangle.Location = new Point( Math.Min(A.X, C.X), Math.Min(A.Y, C.Y) );
            DrawingRectangle.Size = new Size( Math.Abs(A.X - C.X), Math.Abs(A.Y - C.Y) );
        }

        public override void Show(Graphics g_, Pen LinePen_)
        {
            g_.DrawRectangle(LinePen_, DrawingRectangle);
        }

        public override bool Touched(Point Pos_)
        {
            foreach(var Side in Sides)
            {
                if( Side.Touched( Pos_ ) )
                    return true;
            }

            return false;
        }

        public override Point Cast(Ray Ray_)
        {
            Point CastPoint = Ray_.InfPoint();
            double best = Utility.oo;
            
            foreach(var Side in Sides)
            {
                Point CastTemp = Side.Cast(Ray_);
                double DisTemp = Utility.Distance(CastTemp, Ray_.Source);
                if( DisTemp < best )
                {
                    CastPoint = CastTemp;
                    best = DisTemp;
                }
            }

            return CastPoint;
        }
    }
}
