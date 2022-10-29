using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Simulation
{
    public partial class Form1 : Form
    {

        Simulation simulation;
        double sim_speed = 1;
        public Form1()
        {
            InitializeComponent();
            Size = new Size(730, 680);
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, Base, new object[] { true });
            
            try
            {
                timer_render.Interval = (int)Time_interval.Value;
            }
            catch { }
            
            StartSimulation();
        }

        private void StartSimulation()
        {
            string border="", gravity="";
            if (Border_none.Checked)
                border = "none";
            if (Border_solid.Checked)
                border = "solid";
            if (Border_loop.Checked)
                border = "loop";

            if (G_none.Checked)
                gravity = "none";
            if (G_vert.Checked)
                gravity = "vert";
            if (G_rad.Checked)
                gravity = "rad";

            simulation = new Simulation(
                new Vect(0,0), new Vect(Base.Width,Base.Height),
                border:border, abs:Absorbsion.Value,
                Gravity:Particle_grav.Checked,
                g_type:gravity,
                origin: new Vect(Base.Width / 2.0, Base.Height / 2.0));
        }
        private void controll_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Base_Paint(object sender, PaintEventArgs e)
        { 
            
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Gray);
            SolidBrush brush = new SolidBrush(Color.Gray);



            if (Force_field.Checked)
            {
                Paint_Force_field(g);
            }
            brush.Color = Color.Black;

            foreach (Particle p in simulation.particles)
            {
                float r = (float)Math.Min(Math.Log(p.m) + 1,p.m+6);
                
                g.FillEllipse(brush, (float)(p.r.x1-r/2.0), (float)(p.r.x2 - r / 2.0), r, r);
            }
        }

        private void Paint_Force_field(Graphics g)
        {
            Vect f;
            Pen pen = new Pen(Color.Gray);
            SolidBrush brush = new SolidBrush(Color.Gray);
            for (int x = 0; x < Base.Width; x += 13)
            {
                for (int y = 0; y < Base.Height; y += 13)
                {
                    f = simulation.CumulativeGForce(new Vect(x, y));
                    double l = f.length()+1;
                    double m = Math.Max(2, Math.Min(l, 15));
                    f *= m / l;
                    g.FillEllipse(brush, x - 2, y - 2, 4, 4);
                    g.DrawLine(pen, x, y, (int)(x + f.x1), (int)(y + f.x2));
                }
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            timer_render.Enabled = true;
        }


        private void pause_Click(object sender, EventArgs e)
        {
            timer_render.Enabled = !timer_render.Enabled;
        }

        private void timer_render_Tick(object sender, EventArgs e)
        {
            Invalidate();
            simulation.Update(timer_render.Interval/1000.0*sim_speed);
        }

        private void reset_Click(object sender, EventArgs e)
        {
            StartSimulation();
            Invalidate();
            Console.WriteLine(Convert.ToString(Height), Convert.ToString(Width));
        }

        private void Force_field_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void particle_grav_CheckedChanged(object sender, EventArgs e)
        {
            if (Particle_grav.Checked)
                simulation.Enable_Gravity();
            else
                simulation.Disable_Gravity();
        }

        private void Speed_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Speed.Value >= 20)
                {
                    sim_speed = (float)Math.Pow(2.718281828, (double)Speed.Value - 17);
                }
                else if (Speed.Value >= 0)
                    sim_speed = (float)Speed.Value + 1;
                else
                    sim_speed = (float)Math.Pow(2.718, (double)Speed.Value);
                label2.Text = "Speed:\n" + Convert.ToString((float)sim_speed);
            }
            catch { }

        }

        private void Time_interval_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                timer_render.Interval = (int)Time_interval.Value;
            }
            catch { }
        }

        private void Border_none_CheckedChanged(object sender, EventArgs e)
        {
            if (Border_none.Checked)
            {
                simulation.SetBorder();
            }
        }

        private void Border_solid_CheckedChanged(object sender, EventArgs e)
        {
            if (Border_solid.Checked)
            {
                simulation.SetBorder("solid", Absorbsion.Value);
            }
        }

        private void Border_loop_CheckedChanged(object sender, EventArgs e)
        {
            if (Border_loop.Checked)
            {
                simulation.SetBorder("loop");
            }
        }

        private void Absorbsion_Scroll(object sender, EventArgs e)
        {
            if (Border_solid.Checked)
            {
                simulation.SetBorder("solid", Absorbsion.Value);
            }
        }

        private void G_none_CheckedChanged(object sender, EventArgs e)
        {
            if (G_none.Checked)
            {
                simulation.SetForceField("none");
            }
        }

        private void G_vert_CheckedChanged(object sender, EventArgs e)
        {
            if (G_vert.Checked)
            {
                simulation.SetForceField("vert");
            }
        }

        private void G_rad_CheckedChanged(object sender, EventArgs e)
        {
            if (G_rad.Checked)
            {
                simulation.SetForceField("rad", new Vect(Base.Width/2.0,Base.Height/2.0));
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            simulation.AddParticle(Math.Pow(2.71,Mass_setter.Value/100.0), Particle_grav.Checked);
        }

        private void Mass_setter_Scroll(object sender, EventArgs e)
        {
            label3.Text = "Mass:\n" + Convert.ToString(Math.Pow(2.71, Mass_setter.Value/100.0));
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
