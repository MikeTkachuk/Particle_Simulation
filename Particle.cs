using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    class Particle
    {
        public Vect r { get; private set; }
        public Vect v { get; private set; }
        public double m { get; private set; }
        public List<Force_field> field;
        public bool gravity { get; private set; }

        public Particle()
        {
            r = new Vect();v = new Vect(); m = 1;
            Force_field.F_func func = delegate (Vect r0) { return new Vect(); };
            field = new List<Force_field> { new Force_field(0, func), new Force_field(1, func) };
            gravity = false;
        }

        public Particle(double X, double Y) : this()
        {
            r = new Vect(X, Y);
        }
        public Particle(double X, double Y, double M) : this()
        {
            r = new Vect(X, Y);
            m = M;
        }
        public Particle(double X, double Y, double Vx, double Vy, double M) : this()
        {
            r = new Vect(X, Y);
            v = new Vect(Vx, Vy);
            m = M;
        }
        public Particle(double X, double Y, double Vx, double Vy, double M,
            int Nature, Force_field.F_func func) : this()
        {
            r = new Vect(X, Y);
            v = new Vect(Vx, Vy);
            m = M;
            field[Nature].func = func;
            if (Nature == 0)
                gravity = true;
        }
        public Particle(double X, double Y, double Vx, double Vy, double M,
            Force_field.F_func func1, Force_field.F_func func2) : this()
        {
            r = new Vect(X, Y);
            v = new Vect(Vx, Vy);
            m = M;
            field[0].func = func1;
            field[1].func = func2;
            gravity = true;
        }
        
        private void set(Vect R, Vect V)
        {
            r = new Vect(R);
            v = new Vect(V);
        }

        public void Enable_Gravity()
        {
            field[0].func = Force_field.Gravity_Func(m, r);
            gravity = true;
        }

        public void Disable_Gravity()
        {
            field[0].func = delegate (Vect r0) {
                return new Vect();
            };
            gravity = false;
        }
        public Vect Compute_F(Force_field field)
        {
            Vect f = new Vect();
            if (field.nature == -1)
            {
                return field.get(r);
            }
            else if (field.nature == 0 && gravity)
            {
                f = field.get(r);
                f *= m;
            }

            return f;
        }
        public Vect Influence(Particle P)
        {
            Vect f = new Vect(), output;
            foreach (Force_field field in P.field)
            {
                output = Compute_F(field);
                f += output;
            }
            return f;
        }



        /// <summary>
        /// Computes new location/velosity based on dtime and force applied
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="force"></param>
        /// <returns>list of {velocity, location}</returns>
        public List<Vect> Compute_update(double dt, Vect force)
        {
            List<Vect> output = new List<Vect> { };
            output.Add(v + force * (dt / m));
            output.Add(r + output[0] * dt);
            return output;
        }



        /// <summary>
        /// Change location based on the applied force
        /// </summary>
        public void Update(double dt, Vect force)

        {
            List<Vect> update = Compute_update(dt, force);
            v = update[0];
            r = update[1];
            if (gravity)
            {
                field[0].func = Force_field.Gravity_Func(m, r);

            }
        } 



        /// <summary>
        /// Update location and velocity in a proper way
        /// </summary>
        public void Update(Vect R, Vect V)

        {
            set(R, V);
            if (gravity)
            {
                field[0].func = Force_field.Gravity_Func(m, r);

            }
        }
    }
}
