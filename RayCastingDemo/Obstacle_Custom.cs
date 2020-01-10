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

        public Obstacle_Custom(List<PointF> points_, bool Reflective)
        {
            this.Reflective = Reflective;

            for(int i=1; i<points_.Count; i++)
            {
                Segments.Add( new Obstacle_Wall(points_[i-1], points_[i], Reflective) );
            }
        }

        public override void Show(Graphics g_, Pen LinePen_)
        {
            foreach(var Segment in Segments)
            {
                Segment.Show(g_, LinePen_);
            }
        }

        public override bool Touched(PointF Pos_)
        {
            foreach(var Segment in Segments)
            {
                if( Segment.Touched( Pos_ ) )
                    return true;
            }

            return false;
        }

        public override PointF Cast(Ray Ray_)
        {
            PointF CastPoint = Ray_.InfPoint();
            double best = Utility.oo;
            
            foreach(var Segment in Segments)
            {
                PointF CastTemp = Segment.Cast(Ray_);
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

            foreach(var Segment in Segments)
            {
                PointF CastPoint = Segment.Cast(Ray_);
                if( Source == CastPoint )
                    return Segment.ReflectedRay(Ray_);
            }

            // code never reaches here!
            return null;
        }

    }
}
