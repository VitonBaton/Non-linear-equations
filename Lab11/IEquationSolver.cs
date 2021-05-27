using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    interface IEquationSolver
    {
        delegate double FunctionEvaluate(double x);
        public double Solve(FunctionEvaluate func, double xStart);
    }
}
