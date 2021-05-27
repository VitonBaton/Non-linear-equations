using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class SimpleIterations : IEquationSolver
    {
        public double Solve(IEquationSolver.FunctionEvaluate func, double xStart)
        {
            var prev = xStart;
            double temp;
            double ret;
            int count = 0;
            do
            {
                ret = func(prev);
                temp = ret - prev;
                prev = ret;
                count++;
            } while (Math.Abs(temp) > 0.001);
            Console.WriteLine(count);
            return ret;
        }
    }
}
