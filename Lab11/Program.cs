using System;
using System.Collections.Generic;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lab11
            Console.WriteLine("\n\nLab 11");
            Console.WriteLine("Корни первого уравнения:");

            //var func1 = new Function1();
            Console.WriteLine(Dichotomy.Solve((x) => Math.Pow(0.5, x) + 1 - (x - 2) * (x - 2), 3, 3.2));
            Console.WriteLine(Dichotomy.Solve((x) => Math.Pow(0.5, x) + 1 - (x - 2) * (x - 2), 0.6, 0.8));
            Console.WriteLine(Dichotomy.Solve((x) => Math.Pow(0.5, x) + 1 - (x - 2) * (x - 2), -6, -5.8));
            Console.WriteLine("Корни второго уравнения:");
            Console.WriteLine(Dichotomy.Solve((x) => 2 * x * x * x - 9 * x * x - 60 * x + 1, -4.6, -3.4));
            Console.WriteLine(Dichotomy.Solve((x) => 2 * x * x * x - 9 * x * x - 60 * x + 1, -0.4, 0.8));
            Console.WriteLine(Dichotomy.Solve((x) => 2 * x * x * x - 9 * x * x - 60 * x + 1, 7.4, 8.6));


            // Lab12
            Console.WriteLine("\n\nLab 12");
            IEquationSolver.FunctionEvaluate funcForIterations = (x) =>
            {
                double temp = 5 * x - 1;
                var ret = Math.Pow(Math.Abs(5 * x - 1), 1 / 3f);
                return ret * Math.Sign(temp);
            };

            IEquationSolver solver = new SimpleIterations();            
            Console.WriteLine("Корни первого уравнения:");
            Console.WriteLine(solver.Solve(funcForIterations, -3));
            Console.WriteLine(solver.Solve(funcForIterations, 2));
            Console.WriteLine(solver.Solve((x) => (x * x * x + 1) / 5, 0.2));
            Console.WriteLine("Корни второго уравнения:");
            Console.WriteLine(solver.Solve((x) => (1 - Math.Cos(x)) / 3, 100));

            // Lab13
            Console.WriteLine("\n\nLab 13");
            solver = new NewtonMethod();
            Console.WriteLine("Корни первого уравнения");
            Console.WriteLine("Методом Ньютона:");
            Console.WriteLine(solver.Solve((x) => x - Math.Sin(x) - 0.25, 3));
            solver = new SecantsMethod();
            Console.WriteLine("Методом секущих:");
            Console.WriteLine(solver.Solve((x) => x - Math.Sin(x) - 0.25, 3));
            Console.WriteLine();
            solver = new NewtonMethod();
            Console.WriteLine("Корни второго уравнения");
            Console.WriteLine("Методом Ньютона:");
            Console.WriteLine(solver.Solve((x) => 2 * x - Math.Sin(2 * x) - 0.25, 2));
            solver = new SecantsMethod();
            Console.WriteLine("Методом секущих:");
            Console.WriteLine(solver.Solve((x) => 2 * x - Math.Sin(2 * x) - 0.25, 2));

            // Lab14
            Console.WriteLine("\n\nLab 14");
            //Iterations
            ISystemsOfEquationsSolver systemSolver = new SimpleIterationsForSystem();
            Console.WriteLine("Корни первого уравнения");
            Console.WriteLine("Методом простых итераций:");
            var result = systemSolver.Solve(new List<ISystemsOfEquationsSolver.EvaluateFunction>
            { (x) => 1 - Math.Sin(x[1]) / 2,
              (x) => 0.7 - Math.Cos(x[0] - 1)},
            new double[] {1, 5});
            foreach (var value in result)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();
            //Newton
            Console.WriteLine("Методом Ньютона:");
            systemSolver = new NewtonMethodForSystems();
            result = systemSolver.Solve(new List<ISystemsOfEquationsSolver.EvaluateFunction>
            { (x) => Math.Sin(x[1]) + 2 * x[0] - 2,
              (x) => Math.Cos(x[0] - 1) + x[1] - 0.7},
            new double[] { 1, 5 });

            foreach (var value in result)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();
        }
    }
}
