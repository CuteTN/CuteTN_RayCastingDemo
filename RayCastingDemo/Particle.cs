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
        public int ReflectingEnergy;
        
        PointF Pos;

        Pen raysPen;
        public Pen RaysPen
        {
            get { return raysPen; }
            set
            {
                if( raysPen == value )
                    return;

                raysPen = value;
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
                    Rays.Add( new Ray(Pos, i*Math.PI*2/value, RaysPen, ReflectingEnergy) );
                }
            }
        }

        public Particle(PointF Pos, Pen RaysPen, int NumberOfRays, int ReflectingEnergy)
        {
            this.RaysPen = RaysPen;
            this.Pos = Pos;

            this.ReflectingEnergy = ReflectingEnergy;
            this.NumberOfRays = NumberOfRays;
            // for(int i=0; i<NumberOfRays; i++)
            // {
            //     Rays.Add( new Ray(Pos, i*Math.PI*2/NumberOfRays, RaysPen, ReflectingEnergy) );
            // }
        }

        public void Update(PointF NewPos, List<Obstacle> Obstacles)
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
