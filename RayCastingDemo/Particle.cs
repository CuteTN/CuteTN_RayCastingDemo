using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RayCastingDemo
{
    class Particle
    {
        List<Ray> Rays = new List<Ray>();
        public bool Enabled = true;
        
        Point Pos;

        Pen raysPen;
        public Pen RaysPen
        {
            get { return raysPen; }
            set
            {
                if( raysPen == value )
                    return;

                foreach (var ray in Rays)
                {
                    ray.RayPen = value;
                }
            }
        }

        public int NumberOfRays
        {
            get { return Rays.Count; }
            set
            {
                Rays.Clear();
                
                for(int i=0; i<value; i++)
                {
                    Rays.Add( new Ray(Pos, i*Math.PI*2/value, RaysPen) );
                }
            }
        }

        public Particle(Point Pos, Pen RaysPen, int NumberOfRays)
        {
            this.RaysPen = RaysPen;
            this.Pos = Pos;

            for(int i=0; i<NumberOfRays; i++)
            {
                Rays.Add( new Ray(Pos, i*Math.PI*2/NumberOfRays, RaysPen) );
            }
        }

        public void Update(Point NewPos, List<Obstacle> Obstacles)
        {
            foreach(var ray in Rays)
            {
                ray.Update(NewPos, Obstacles);
            }
        }

        public void Show(Graphics g_)
        {
            if(! Enabled)
                return;

            foreach(var ray in Rays)
            {
                ray.Show(g_);
            }
        }
    }
}
