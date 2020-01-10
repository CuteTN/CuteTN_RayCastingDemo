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
        public const double eps = 5;

        /// Euclidean norm of a vector
        static public double VNorm(PointF vector)
        {
            double x = vector.X;
            double y = vector.Y;

            return Math.Sqrt(x*x + y*y);
        }

        /// Distance from PointF A to PointF B
        static public double Distance(PointF A, PointF B)
        {
            PointF vector = new PointF(B.X - A.X, B.Y - A.Y);
            return VNorm(vector);
        }

        /// Distance from PointF A to line BC
        static public double Distance(PointF A, PointF B, PointF C)
        {
            return TriangleArea(A,B,C)/Distance(B,C);
        }

        static public double TriangleArea(PointF A, PointF B, PointF C)
        {
            double a = Distance(B, C);
            double b = Distance(A, C);
            double c = Distance(A, B);
            double p = (a+b+c)/2;

            double Result = Math.Sqrt( p * (p-a) * (p-b) * (p-c) );
            return Result;
        }

        /// getting the bounding rectangle of a circle
        static public RectangleF BoundingRectangle(PointF Center, double Radius)
        {
            RectangleF Result = new RectangleF();
            double SideLength = Radius*2;

            Result.Location = new PointF( (float)(Center.X - SideLength/2), (float)(Center.Y - SideLength/2) );
            Result.Size = new SizeF( (float)SideLength, (float)SideLength );
            return Result;
        }

        /// dot product of 2 vectors
        static public double Dot(PointF V1, PointF V2)
        {
            return V1.X*V2.X + V1.Y*V2.Y;
        }


        /// Normalize a vector
        static public PointF Normalize(PointF V)
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

        /// Finding direction of a line
        static public double GetDir(PointF A, PointF B)
        {
            try
            {
                double dy = A.Y - B.Y;
                double dx = A.X - B.X;

                // dy/dx == the slope of the line
                double temp = Math.Atan( dy/dx );   
                
                if( double.IsNaN(temp) || double.IsInfinity(temp) )
                    return Math.PI/2;
                return temp;
            }
            catch
            {
                return Math.PI/2;
            }
        }

        /// move the PointF a little bit...
        static public PointF MovePointOffset(PointF origin, double dir)
        {
            PointF result = new PointF();
            result.X = (float)( origin.X + eps*Math.Cos(dir) );
            result.Y = (float)( origin.Y + eps*Math.Sin(dir) );
            return result;
        }
    }
}
