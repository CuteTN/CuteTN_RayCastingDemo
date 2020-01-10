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
        RectangleF DrawingRectangle;


        public Obstacle_Rectangle(PointF Corner1_, PointF Corner2_, bool Reflective)
        {
            this.Reflective = Reflective;

            PointF A = Corner1_;
            PointF B = new PointF(Corner1_.X, Corner2_.Y);
            PointF C = Corner2_;
            PointF D = new PointF(Corner2_.X, Corner1_.Y);

            Sides[0] = new Obstacle_Wall(A, B, Reflective);
            Sides[1] = new Obstacle_Wall(B, C, Reflective);
            Sides[2] = new Obstacle_Wall(C, D, Reflective);
            Sides[3] = new Obstacle_Wall(D, A, Reflective);

            DrawingRectangle = new Rectangle();
            DrawingRectangle.Location = new PointF( Math.Min(A.X, C.X), Math.Min(A.Y, C.Y) );
            DrawingRectangle.Size = new SizeF( Math.Abs(A.X - C.X), Math.Abs(A.Y - C.Y) );
        }

        public override void Show(Graphics g_, Pen LinePen_)
        {
            Rectangle rect = new Rectangle( (int)DrawingRectangle.Location.X, (int)DrawingRectangle.Location.Y, (int)DrawingRectangle.Size.Width, (int)DrawingRectangle.Size.Height);
            g_.DrawRectangle(LinePen_, rect);
        }

        public override bool Touched(PointF Pos_)
        {
            foreach(var Side in Sides)
            {
                if( Side.Touched( Pos_ ) )
                    return true;
            }

            return false;
        }

        public override PointF Cast(Ray Ray_)
        {
            PointF CastPoint = Ray_.InfPoint();
            double best = Utility.oo;
            
            foreach(var Side in Sides)
            {
                PointF CastTemp = Side.Cast(Ray_);
                double DisTemp = Utility.Distance(CastTemp, Ray_.Source);
                if( DisTemp < best )
                {
                    CastPoint = CastTemp;
                    best = DisTemp;
                }
            }

            return CastPoint;
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

            foreach(var Side in Sides)
            {
                PointF CastPoint = Side.Cast(Ray_);
                if( Source == CastPoint )
                    return Side.ReflectedRay(Ray_);
            }

            // code never reaches here!
            return null;
        }
    
    }
}
