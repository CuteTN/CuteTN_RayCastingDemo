using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayCastingDemo
{
    public partial class FormMain : Form
    {
        List<Obstacle> Obstacles = new List<Obstacle>();
        Particle SpotLight;
        

        int numberOfRays = 500;
        public int NumberOfRays
        {
            get { return numberOfRays;  }
            set 
            { 
                if(numberOfRays != value)
                {
                    numberOfRays = value;
                    SpotLight.NumberOfRays = value;
                }
            }
        }

        Pen particleRaysPen = new Pen( Color.FromArgb(50, Color.LightPink), 10 );
        public Pen ParticleRaysPen
        {
            get { return particleRaysPen; }
            set
            {
                if(particleRaysPen != value)
                {
                    particleRaysPen = value;
                    SpotLight.RaysPen = value;
                }
            }
        }

        Color BackgroundColor = Color.Black;

        int reflectionLimit = 10;
        int ReflectionLimit
        {
            get { return reflectionLimit; }
            set
            {
                if( reflectionLimit == value )
                    return;

                reflectionLimit = value;
                SpotLight.ReflectingEnergy = value;
            }
        }


        public FormMain()
        {
            InitializeComponent();
            CustomInitialize();
        }

        private void InitializeEvents()
        {
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown_HotKeyHandle);

            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown_Delete);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove_Delete);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp_Delete);

            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown_Build);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove_Build);
        
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp_BuildWall);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp_BuildCircle);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp_BuildRectangle);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp_BuildCustom);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint_BuildWall);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint_BuildCircle);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint_BuildRectangle);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint_BuildCustom);

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint_DrawObstacles);

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint_DrawParticles);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove_UpdateParticle);
        }


        private void CustomInitialize()
        {
            SpotLight = new Particle(new PointF(0,0), ParticleRaysPen, NumberOfRays, ReflectionLimit);
            this.DoubleBuffered = true;
            InitializeEvents();
        }

        private void UserLog(string msg)
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen( Color.FromArgb(200, Color.White), 3);
            Brush b = new SolidBrush( Color.FromArgb(100, Color.White ) );
            Rectangle rect = new Rectangle(0, 0, this.Width, 30);

            g.DrawRectangle(p, rect);
            g.FillRectangle(b, rect);

            Font font = new Font("Arial", 15);
            b = new SolidBrush( Color.Black );
            g.DrawString(msg, font, b, new PointF(0, 5) );
        }


        // hotkeys handling ////////////////////////////////////////////////////////////////////////////////////////////////// 
        private void HotKeyHandle(Keys key)
        {
            switch ( key )
            {
                case Keys.Escape:
                {
                    Application.Exit();
                    break;
                }
                case Keys.D1:
                {
                    if(! LeftMouseIsHolding )
                        BuildType = ObstacleType.Wall;
                    break;
                }
                case Keys.D2:
                {
                    if(! LeftMouseIsHolding )
                        BuildType = ObstacleType.Circle;
                    break;
                }
                case Keys.D3:
                {
                    if(! LeftMouseIsHolding )
                        BuildType = ObstacleType.Rectangle;
                    break;
                }
                case Keys.D4:
                {
                    if(! LeftMouseIsHolding )
                        BuildType = ObstacleType.Custom;
                    break;
                }
                case Keys.F2:
                {
                    DoSetting();
                    break;
                }
                case Keys.Space:
                {
                    SpotLight.Enabled = ! SpotLight.Enabled;
                    this.Refresh();
                    break;
                }
                case Keys.Back:
                {
                    Obstacles.Clear();
                    SpotLight.Update(Cursor.Position, Obstacles);
                    this.Refresh();
                    break;
                }
                case Keys.M:
                {
                    IsBuildingMirrors = ! IsBuildingMirrors;
                    break;
                }
                default:
                {
                    break;
                }
            }
        }

        private void FormMain_KeyDown_HotKeyHandle(object sender, KeyEventArgs e)
        {
            HotKeyHandle(e.KeyCode);
        }

        // Update ////////////////////////////////////////////////////////////////////////////////////////////////// 
        private void FormMain_Paint_DrawObstacles(object sender, PaintEventArgs e)
        {
            foreach(var obstacle in Obstacles)
            {
                Pen LinePen;
                if(obstacle.Reflective)
                    LinePen = new Pen( Color.Turquoise, 5);
                else
                    LinePen = new Pen( Color.Chocolate, 5 );
                obstacle.Show(e.Graphics, LinePen);
            }
        }

        private void FormMain_Paint_DrawParticles(object sender, PaintEventArgs e)
        {
            if( LeftMouseIsHolding )
                return;

            SpotLight.Show(e.Graphics);
        }

        private void FormMain_MouseMove_UpdateParticle(object sender, MouseEventArgs e)
        {
            SpotLight.Update( Cursor.Position, Obstacles );
            this.Refresh();
        }


        // Deletion ////////////////////////////////////////////////////////////////////////////////////////////////// 
        bool RightMouseIsHolding = false;

        private void FormMain_MouseDown_Delete(object sender, MouseEventArgs e)
        {
            if( e.Button != MouseButtons.Right )
                return;

            RightMouseIsHolding = true;
            for(int i=Obstacles.Count-1; i>=0; i--)
            {
                var obs = Obstacles[i];
                if( obs.Touched( Cursor.Position ) )
                    Obstacles.RemoveAt(i);
            }
        }

        private void FormMain_MouseMove_Delete(object sender, MouseEventArgs e)
        {
            if( RightMouseIsHolding )
            {
                for(int i=Obstacles.Count-1; i>=0; i--)
                {
                    var obs = Obstacles[i];
                    if( obs.Touched( Cursor.Position ) )
                        Obstacles.RemoveAt(i);
                }
            }
        }

        private void FormMain_MouseUp_Delete(object sender, MouseEventArgs e)
        {
            if( e.Button != MouseButtons.Right )
                return;

            RightMouseIsHolding = false;
        }


        // Setting ////////////////////////////////////////////////////////////////////////////////////////////////// 
        private void InitSettingValue(FormSetting form)
        {
            form.NumberOfRay = this.NumberOfRays;
            form.RayBrightness = this.ParticleRaysPen.Color.A;
            form.RayThickness = (int)this.particleRaysPen.Width;
            form.ReflectionLimit = this.ReflectionLimit;
            form.RayColor = Color.FromArgb(255, this.particleRaysPen.Color);

            form.BackgroundColor = this.BackColor;
        }

        private void ApplySettingValue(FormSetting form)
        {
            this.NumberOfRays = form.NumberOfRay;
            this.ParticleRaysPen = new Pen( Color.FromArgb(form.RayBrightness, form.RayColor), form.RayThickness );
            this.ReflectionLimit = form.ReflectionLimit;

            this.BackColor = form.BackgroundColor;
        }

        private void DoSetting()
        {
            FormSetting frm = new FormSetting();
            InitSettingValue(frm);
            DialogResult dialogResult = frm.ShowDialog();

            if(dialogResult == DialogResult.OK)
            {
                ApplySettingValue(frm);
            }
        }

        // BUILD HANDLE //////////////////////////////////////////////////////////////////////////////////////////////////   
        bool LeftMouseIsHolding = false;
        PointF LeftMouseDownPos;
        PointF MousePos;
        
        ObstacleType buildType = ObstacleType.Wall;
        ObstacleType BuildType
        {
            get { return buildType; }
            set
            {
                buildType = value;

                this.Refresh();
                UserLog("Building type has changed to: " + buildType.ToString());
            }
        }

        bool isBuildingMirrors = false;
        bool IsBuildingMirrors
        {
            get { return isBuildingMirrors; }
            set
            {
                isBuildingMirrors = value;

                this.Refresh();
                UserLog("Mirror material: " + (isBuildingMirrors? "ON":"OFF") );
            }
        }

        private void FormMain_MouseDown_Build(object sender, MouseEventArgs e)
        {
            if( e.Button != MouseButtons.Left )
                return;

            LeftMouseIsHolding = true;
            LeftMouseDownPos = Cursor.Position;
            MousePos = Cursor.Position;
        }

        private void FormMain_MouseMove_Build(object sender, MouseEventArgs e)
        {
            if( LeftMouseIsHolding )
            {
                if(BuildType == ObstacleType.Custom)
                    MouseTraces.Add( Cursor.Position );

                MousePos = Cursor.Position;
            }
        }


        // WALL HANDLE //////////////////////////////////////////////////////////////////////////////////////////////////   
        private void FormMain_MouseUp_BuildWall(object sender, MouseEventArgs e)
        {
            if( e.Button != MouseButtons.Left )
                return;
            if( BuildType != ObstacleType.Wall )
                return;

            LeftMouseIsHolding = false;
            Obstacle NewObstacle = new Obstacle_Wall(LeftMouseDownPos, MousePos, IsBuildingMirrors);
            Obstacles.Add(NewObstacle);
        }

        private void FormMain_Paint_BuildWall(object sender, PaintEventArgs e)
        {
            if(! LeftMouseIsHolding )
                return;
            if( BuildType != ObstacleType.Wall )
                return;

            Graphics g = e.Graphics;
            Pen p = new Pen(Color.LightPink, 5f);
            Obstacle o = new Obstacle_Wall(LeftMouseDownPos, MousePos, IsBuildingMirrors);
            o.Show(g,p);
        }


        // CIRCLE HANDLE //////////////////////////////////////////////////////////////////////////////////////////////////   
        private void FormMain_MouseUp_BuildCircle(object sender, MouseEventArgs e)
        {
            if( e.Button != MouseButtons.Left )
                return;
            if( BuildType != ObstacleType.Circle )
                return;

            LeftMouseIsHolding = false;
            Obstacle NewObstacle = new Obstacle_Circle( LeftMouseDownPos, Utility.Distance(LeftMouseDownPos, MousePos), IsBuildingMirrors );
            Obstacles.Add(NewObstacle);
        }

        private void FormMain_Paint_BuildCircle(object sender, PaintEventArgs e)
        {
            if(! LeftMouseIsHolding )
                return;
            if( BuildType != ObstacleType.Circle )
                return;

            Graphics g = e.Graphics;
            Pen p = new Pen(Color.LightPink, 5f);
            Obstacle o = new Obstacle_Circle( LeftMouseDownPos, Utility.Distance(LeftMouseDownPos, MousePos), IsBuildingMirrors );
            o.Show(g,p);
        }

        // CUSTOM HANDLE //////////////////////////////////////////////////////////////////////////////////////////////////   
        List<PointF> MouseTraces = new List<PointF>();

        private void FormMain_MouseUp_BuildCustom(object sender, MouseEventArgs e)
        {
            if( e.Button != MouseButtons.Left )
                return;
            if( BuildType != ObstacleType.Custom )
                return;

            LeftMouseIsHolding = false;
            Obstacle NewObstacle = new Obstacle_Custom( MouseTraces, IsBuildingMirrors );
            Obstacles.Add(NewObstacle);

            MouseTraces.Clear();
        }

        private void FormMain_Paint_BuildCustom(object sender, PaintEventArgs e)
        {
            if(! LeftMouseIsHolding )
                return;
            if( BuildType != ObstacleType.Custom )
                return;

            Graphics g = e.Graphics;
            Pen p = new Pen(Color.LightPink, 5f);
            Obstacle o = new Obstacle_Custom( MouseTraces, IsBuildingMirrors );
            o.Show(g,p);
        }


        // RECTANGLE HANDLE //////////////////////////////////////////////////////////////////////////////////////////////////   
        private void FormMain_MouseUp_BuildRectangle(object sender, MouseEventArgs e)
        {
            if( e.Button != MouseButtons.Left )
                return;
            if( BuildType != ObstacleType.Rectangle )
                return;

            LeftMouseIsHolding = false;
            Obstacle NewObstacle = new Obstacle_Rectangle(LeftMouseDownPos, MousePos, IsBuildingMirrors);
            Obstacles.Add(NewObstacle);
        }

        private void FormMain_Paint_BuildRectangle(object sender, PaintEventArgs e)
        {
            if(! LeftMouseIsHolding )
                return;
            if( BuildType != ObstacleType.Rectangle )
                return;

            Graphics g = e.Graphics;
            Pen p = new Pen(Color.LightPink, 5f);
            Obstacle o = new Obstacle_Rectangle(LeftMouseDownPos, MousePos, IsBuildingMirrors);
            o.Show(g,p);
        }




    }
}
