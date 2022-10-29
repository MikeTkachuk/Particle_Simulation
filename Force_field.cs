using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
   

    class Force_field // contains values of potentials of the field
    { 
        const double G = 6.674 * 10E-11;
        const double k = 8.9876 * 10E9;
        public int type; // 0 - matrix, 1 - function
        public int nature; // -1 - raw force, 0 - gravity, 1 - electrostatic
        public double[,,] values_m;
        public delegate Vect F_func(Vect r);
        public F_func func;

        public Force_field()
        {
            type = 0;
            nature = -1;
            values_m = null;
            func = null;
        }

        public Force_field(int Nature, F_func f) : this()
        {
            type = 1;
            nature = Nature;
            func = f;
        }
        public Force_field(int Nature, double[,,] vm) : this()
        {
            nature = Nature;
            values_m = vm;
        }

        public Vect get(Vect r0)
        {
            if (func != null)
            {
                return func(r0);
            }
            else if (values_m != null)
            {
                Vect f = new Vect(
                    values_m[Convert.ToInt32(Math.Round(r0.x1)), Convert.ToInt32(Math.Round(r0.x2)), 0],
                    values_m[Convert.ToInt32(Math.Round(r0.x1)), Convert.ToInt32(Math.Round(r0.x2)), 1]);

                return f;
            }
            else
            {
                return new Vect();
            }
        }
        static public F_func Gravity_Func(double m, Vect r0)
        {
            F_func output = delegate (Vect r) {

                double l = Math.Max((r - r0).length(), Math.Max(Math.Log(m) + 1, 7));
                double f = m / Math.Pow(l, 2)*G;

                return (r0-r).norm()*f;
            };

            return output;
        }
      
    }


}
