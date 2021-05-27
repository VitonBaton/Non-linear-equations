using System;
using System.Collections.Generic;
using LinearSystemSolver;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class NewtonMethodForSystems : ISystemsOfEquationsSolver
    {
        public double[] Solve(List<ISystemsOfEquationsSolver.EvaluateFunction> functions, double[] startValues)
        {
            double[] temp = new double[functions.Count];
            var cur = startValues;
            double max;
            int count = 0;
            do
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = functions[i](cur);
                }
                temp = temp.UnaryMinus();
                var system = new LinearSystem(FindJacobiMatrix(functions, cur), temp, functions.Count);
                double[] delta = system.Solve(new GaussWithChoosingElements());
                cur = delta.Add(cur);
                max = 0;
                foreach (var val in delta)
                {
                    if (Math.Abs(val) > max)
                    {
                        max = Math.Abs(val);
                    }
                }
                count++;
            } while (Math.Abs(max) > 0.001);
            Console.WriteLine(count);
            return cur;
        }

        private double Derivate(ISystemsOfEquationsSolver.EvaluateFunction func, double[] x, int currentElement)
        {
            var accuracy = 0.00001;
            var temp = (double[])x.Clone();
            var temp2 = (double[])x.Clone();
            temp[currentElement] += accuracy;
            temp2[currentElement] -= accuracy;
            var ret = (func(temp) - func(temp2)) / (2 * accuracy);
            return ret;
        }

        private double[][] FindJacobiMatrix(List<ISystemsOfEquationsSolver.EvaluateFunction> functions, double[] currentValues)
        {
            int size = functions.Count;
            double[][] elements = new double[size][];
            for (int i = 0; i < size; i++)
            {
                elements[i] = new double[size];
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    elements[i][j] = Derivate(functions[i], currentValues, j);
                }
            }
            return elements;
        }
    }



    static class DoubleArrayExtension
    {
        public static double[] UnaryMinus (this double[] array)
        {
            var ret = (double[])array.Clone();
            for (int i = 0; i < array.Length; i++)
            {
                ret[i] = -ret[i];
            }
            return ret;
        }

        public static double[] Add(this double[] array, double[] addend)
        {
            var ret = (double[])array.Clone();
            for (int i = 0; i < array.Length; i++)
            {
                ret[i] += addend[i];
            }
            return ret;
        }
    }
}
