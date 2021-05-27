using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class Dichotomy
    {
        public delegate double EvaluateFunction(double x);
        static public double Solve(EvaluateFunction func, double a, double b)
        {
            double ret = (a + b) / 2;
            double prev;
            do
            {
                prev = ret;
                var temp = func(ret);
                if (func(a) * temp > 0)
                {
                    a = ret;
                }
                else
                {
                    b = ret;
                }

                ret = (a + b) / 2;

            } while (Math.Abs(func(prev) - func(ret)) > 0.01);

            return ret;
        }

    }
}
