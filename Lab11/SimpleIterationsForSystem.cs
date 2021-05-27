using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class SimpleIterationsForSystem : ISystemsOfEquationsSolver
    {
        public double[] Solve(List<ISystemsOfEquationsSolver.EvaluateFunction> functions, double[] startValues)
        {
            var prev = startValues;
            var size = functions.Count;

            double[] cur = (double[])prev.Clone();

            double temp;
            int count = 0;
            do
            {
                temp = 0;
                for (int i = 0; i < size; i++)
                {
                    cur[i] = functions[i](prev);
                    temp = Math.Max(temp, Math.Abs(cur[i] - prev[i]));
                }
                prev = (double[])cur.Clone();
                count++;
            } while (temp >= 0.0001);

            Console.WriteLine(count);
            return cur;
        }
    }
}
