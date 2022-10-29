using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    class Vect
    {
        public double x1 { get; private set; }
        public double x2 { get; private set; }

        public Vect()
        {
            x1 = 0;
            x2 = 0;
        }

        public Vect(double a, double b)
        {
            x1 = a;
            x2 = b;
        }
        public Vect(Vect t)
        {
            x1 = t.x1;
            x2 = t.x2;
        }

        static public Vect operator+(Vect l, Vect r)
        {
            return new Vect(l.x1 + r.x1, l.x2 + r.x2);
        }
        static public Vect operator-(Vect a)
        {
            return new Vect(-a.x1, -a.x2);
        }
        static public Vect operator-(Vect l, Vect r)
        {
            return l +(-r);
        }
        static public Vect operator*(double a, Vect b)
        {
            return new Vect(b.x1 * a, b.x2 * a);
        }
        static public Vect operator*(Vect b, double a)
        {
            return a*b;
        }
        static public double operator*(Vect a, Vect b)
        {
            return a.x1 * b.x1 + a.x2 * b.x2;
        }

        static public double vector_length(double x1, double x2)
        {
            return Math.Sqrt(x1 * x1 + x2 * x2);
        }

        public double length()
        {
            return vector_length(x1, x2);
        }
        public Vect norm()
        {
            double l = length();
            if (l != 0)
                return this * (1 / l);
            else
                return new Vect();
        }
        public double[] get_arr()
        {
            return new double[2] { x1, x2 };
        }
    }
}
