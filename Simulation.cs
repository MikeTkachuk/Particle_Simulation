using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    class Simulation
    {
        public List<Particle> particles;
        public List<Force_field> fields;
        public Vect top_left;
        public Vect bot_right;
        public Border border;

        public Simulation()
        {
            particles = new List<Particle> { };
            fields = new List<Force_field> {
                new Force_field(-1,delegate (Vect r) { return new Vect(); })};
        }

        public Simulation( Vect tl, Vect br,
            double abs=0, string border="none",
            bool Gravity=false,
            string g_type="vert",
            Vect origin=null) : this()
        {
            top_left = new Vect(tl);
            bot_right = new Vect(br);
            SetBorder(border, abs);

            Random R = new Random();
            for (int i = 0; i < 3; i++)
            {
                AddParticle(1E13, false,R);
            }
            if (Gravity)
                Enable_Gravity();
            SetForceField(g_type: g_type, origin: origin);
        }

        public void AddParticle(double mass, bool Gravity, Random Rand=null)
        {
            Random R = Rand ?? new Random();

            particles.Add(new Particle(R.NextDouble() * 300 + 100,
                R.NextDouble() * 300 + 100,
                mass));
            if (Gravity)
                particles[particles.Count - 1].Enable_Gravity();
        }

        public void Update(double dt)
        {
            Vect f, output;
            List<List<Vect>> updates = new List<List<Vect>> { };
            foreach (Particle pick in particles)
            {
                f = new Vect();
                foreach (Force_field field in fields)
                {
                    output = pick.Compute_F(field);
                    f += output;
                }
                foreach (Particle influencer in particles)
                {
                    if (pick == influencer)
                        continue;
                    output = pick.Influence(influencer);
                    f += output;
                }
                updates.Add(pick.Compute_update(dt,f));
            }
            if (border is null)
            {
                for (int i = 0; i < particles.Count; i++)
                    particles[i].Update(updates[i][1], updates[i][0]);
            }
            else
                border.Process_update(particles, updates);
        }

        public void Enable_Gravity()
        {
            foreach (Particle p in particles)
            {
                p.Enable_Gravity();
            }
        }
        public void Disable_Gravity()
        {
            foreach (Particle p in particles)
            {
                p.Disable_Gravity();
            }
        }

        /// <summary>
        /// Used for drawing the gravity vector field on the screen
        /// </summary>
        /// <param name="R"></param>
        /// <returns></returns>
        public Vect CumulativeGForce(Vect R)
        {
            Vect output = new Vect();
            foreach(Particle pick in particles)
            {
                output += pick.field[0].func(R);
            }
            foreach(Force_field field in fields)
            {
                output += field.func(R);
            }
            return output;
        }

        public void SetBorder(string type="none", double absorbsion=0)
        {
            if (type == "loop")
                border = new Loop_border(top_left, bot_right);
            if (type == "solid")
                border = new Solid_border(top_left, bot_right, absorbsion);
            if (type == "none")
                border = null;
        }

        public void UpdateSize(Vect tl, Vect br)
        {
            border.UpdateBorders(tl, br);
        }
        public void SetForceField(string g_type = "none",
                                  Vect origin = null)
        {
            if (origin is null)
                origin = new Vect();
            else
                origin = new Vect(origin);


            if (g_type == "vert")
            {
                fields[0] = new Force_field(0, delegate (Vect r) { return new Vect(0, 9.81); });
            }
            if (g_type == "rad")
            {
                fields[0] = new Force_field(0, delegate (Vect r) { return (origin-r).norm()*9.81; });
            }
            if(g_type == "none")
            {
                fields[0] = new Force_field(0, delegate (Vect r) { return new Vect(); });
            }
        }

    }

    abstract class Border
    {
        public Vect top_left;
        public Vect bot_right;
        public Border(Vect a, Vect b)
        {
            top_left = new Vect(a);
            bot_right = new Vect(b);
        }
        public abstract void Process_update(List<Particle> particles, List<List<Vect>> updates);
        public void UpdateBorders(Vect tl, Vect br)
        {
            top_left = new Vect(tl);
            bot_right = new Vect(br);
        }
    }
    class Solid_border : Border
    {
        public Solid_border(Vect a, Vect b, double abs=0) : base(a, b)
        {
            Absorbsion = abs;
        }
        private double absorbsion;
        public double Absorbsion
        {
            get { return absorbsion; }
            set {
                value = Math.Min(
                    Math.Max(value, 0.0),
                    100.0);
                absorbsion = value;
            }
        }
        public override void Process_update(List<Particle> particles, List<List<Vect>> updates)
        {
            Particle pick;
            Vect uR, uV;
            for(int i=0;i<particles.Count; i++) 
            {
                pick = particles[i];
                uR = updates[i][1];
                uV = updates[i][0];

                if (uR.x1 > top_left.x1 &&
                    uR.x1 < bot_right.x1 &&
                    uR.x2 > top_left.x2 &&
                    uR.x2 < bot_right.x2) 
                {
                    pick.Update(uR, uV);
                    continue;
                }
                else //possible bug
                {
                    pick.Update(
                        pick.r+uV.norm()*Math.Min(Math.Min(pick.r.x1 - top_left.x1,
                                                        bot_right.x1 - pick.r.x1),
                                                    Math.Min(pick.r.x2 - top_left.x2,
                                                        bot_right.x2 - pick.r.x2)),
                        pick.v
                        );
                }
                
                if (uR.x1<top_left.x1 || uR.x1>bot_right.x1)
                {
                    pick.Update(pick.r, new Vect(-uV.x1 * (100 - absorbsion) / 100.0, uV.x2));
                }
                if (uR.x2 < top_left.x2 || uR.x2 > bot_right.x2)
                {
                    pick.Update(pick.r, new Vect(uV.x1, -uV.x2 * (100 - absorbsion) / 100.0));
                }

                
            }
        }


    }
    class Loop_border : Border
    {
        public Loop_border(Vect a, Vect b) : base(a, b) { }
        public override void Process_update(List<Particle> particles, List<List<Vect>> updates)
        {
            Particle pick;
            Vect uR, uV;
            for (int i = 0; i < particles.Count; i++)
            {
                pick = particles[i];
                uR = updates[i][1];
                uV = updates[i][0];

                if (uR.x1 < top_left.x1)
                {
                    pick.Update(new Vect(bot_right.x1,uR.x2), uV);
                }
                if (uR.x1 > bot_right.x1)
                {
                    pick.Update(new Vect(top_left.x1, uR.x2), uV);
                }
                if (uR.x2 < top_left.x2)
                {
                    pick.Update(new Vect(uR.x1, bot_right.x2), uV);
                }
                if (uR.x2 > bot_right.x2)
                {
                    pick.Update(new Vect(uR.x1, top_left.x2), uV);
                }

                if (uR.x1 > top_left.x1 &&
                    uR.x1 < bot_right.x1 &&
                    uR.x2 > top_left.x2 &&
                    uR.x2 < bot_right.x2)
                {
                    pick.Update(uR, uV);
                }
            }
        }
    } 
   

}
