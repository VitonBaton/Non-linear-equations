using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class SecantsMethod : IEquationSolver
    {
        public double Solve(IEquationSolver.FunctionEvaluate func, double xStart)
        {

            var prev = xStart;
            var cur = xStart + 0.1;
            double next;
            double temp;
            var count = 0;
            do
            {
                temp = func(cur);
                next = cur - temp*(cur - prev)/(temp - func(prev));
                temp = cur - prev;
                prev = cur;
                cur = next;
                count++;
            } while (Math.Abs(temp) > 0.001);
            Console.WriteLine(count);
            return cur;
        }
    }
}
