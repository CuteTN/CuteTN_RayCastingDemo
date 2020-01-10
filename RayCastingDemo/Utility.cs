using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RayCastingDemo
{
    public static class Utility
    {
        public const double oo = 100000;

        /// Euclidean norm of a vector
        static public double VNorm(Point vector)
        {
            int x = vector.X;
            int y = vector.Y;

            return Math.Sqrt(x*x + y*y);
        }

        /// Distance from point A to point B
        static public double Distance(Point A, Point B)
        {
            Point vector = new Point(B.X - A.X, B.Y - A.Y);
            return VNorm(vector);
        }

        /// Distance from point A to line BC
        static public double Distance(Point A, Point B, Point C)
        {
            return TriangleArea(A,B,C)/Distance(B,C);
        }

        static public double TriangleArea(Point A, Point B, Point C)
        {
            double a = Distance(B, C);
            double b = Distance(A, C);
            double c = Distance(A, B);
            double p = (a+b+c)/2;

            double Result = Math.Sqrt( p * (p-a) * (p-b) * (p-c) );
            return Result;
        }

        /// getting the bounding rectangle of a circle
        static public Rectangle BoundingRectangle(Point Center, double Radius)
        {
            Rectangle Result = new Rectangle();
            double SideLength = Radius*2;

            Result.Location = new Point( (int)(Center.X - SideLength/2), (int)(Center.Y - SideLength/2) );
            Result.Size = new Size( (int)SideLength, (int)SideLength );
            return Result;
        }

        /// dot product of 2 vectors
        static public double Dot(Point V1, Point V2)
        {
            return V1.X*V2.X + V1.Y*V2.Y;
        }


        /// Normalize a vector
        static public PointF Normalize(Point V)
        {
            float d = (float)VNorm(V);
            PointF result = new PointF( V.X/d, V.Y/d );
            return result;
        }

        /// Check if a color is dark
        static public bool IsDark(Color color)
        {
            return (color.R + color.G + color.B <= 381);
        }
    }
}
