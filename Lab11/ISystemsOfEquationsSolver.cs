using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    interface ISystemsOfEquationsSolver
    {
        delegate double EvaluateFunction(double[] x);
        public double[] Solve(List<EvaluateFunction> functions, double[] startValues);
    }
}
