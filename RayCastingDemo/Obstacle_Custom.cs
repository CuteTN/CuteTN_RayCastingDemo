using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RayCastingDemo
{
    class Obstacle_Custom: Obstacle
    {
        List<Obstacle_Wall> Segments = new List<Obstacle_Wall>();

        public Obstacle_Custom(List<Point> points_)
        {
            for(int i=1; i<points_.Count; i++)
            {
                Segments.Add( new Obstacle_Wall(points_[i-1], points_[i]) );
            }
        }

        public override void Show(Graphics g_, Pen LinePen_)
        {
            foreach(var Segment in Segments)
            {
                Segment.Show(g_, LinePen_);
            }
        }

        public override bool Touched(Point Pos_)
        {
            foreach(var Segment in Segments)
            {
                if( Segment.Touched( Pos_ ) )
                    return true;
            }

            return false;
        }

        public override Point Cast(Ray Ray_)
        {
            Point CastPoint = Ray_.InfPoint();
            double best = Utility.oo;
            
            foreach(var Segment in Segments)
            {
                Point CastTemp = Segment.Cast(Ray_);
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
