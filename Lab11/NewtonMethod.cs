using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class NewtonMethod : IEquationSolver
    {
        public double Solve(IEquationSolver.FunctionEvaluate func, double xStart)
        {
            var prev = xStart;
            double temp;
            double ret;
            var count = 0;
            do
            {
                ret = prev - func(prev)/Derivate(func,prev);
                temp = ret - prev;
                prev = ret;
                count++;
            } while (Math.Abs(temp) > 0.001);
            Console.WriteLine(count);
            return ret;
        }

        private double Derivate(IEquationSolver.FunctionEvaluate func, double x)
        {
            var accuracy = 0.00001;
            var ret = (func(x + accuracy) - func(x - accuracy)) / (2 * accuracy);
            return ret;
        }

    }
}
