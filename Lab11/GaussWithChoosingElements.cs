using System;
using LinearSystemSolver;

namespace Lab11
{
    class GaussWithChoosingElements : ISystemSolver
    {
        public double[] Solve(int rank, double[][] elements, double[] column)
        {
            // k - current row 
            for (int k = 0; k < rank; k++)
            {

                // finding max element in current column
                var maxIndex = 0;

                for (int i = 0; i < rank; i++)
                {
                    if (Math.Abs(elements[k][i]) > Math.Abs(elements[k][maxIndex]))
                        maxIndex = i;
                }

                // swap rows
                if (maxIndex != k)
                {
                    (elements[k], elements[maxIndex]) = (elements[maxIndex], elements[k]);
                    (column[k], column[maxIndex]) = (column[maxIndex], column[k]);
                }

                // common Gauss Method
                for (int j = k + 1; j < rank; j++)
                {
                    var coeff = (elements[j][k]) / elements[k][k];
                    for (int i = k; i < rank; i++)
                    {
                        elements[j][i] -= coeff * elements[k][i];
                    }
                    column[j] -= coeff * column[k];
                }
            }


            double[] x = new double[rank];          // x - vector of answers
            for (int i = rank - 1; i >= 0; i--)
            {
                double coeff = 0;
                for (int j = i + 1; j < rank; j++)
                {
                    coeff += elements[i][j] * x[j];
                }
                x[i] = ((column[i] - coeff)) / elements[i][i];
            }
            return x;
        }

        private int FindMax(double[] array)
        {
            var max = 0;
            for (int i = 1; i < array.Length; i++)
                if (Math.Abs(array[max]) < Math.Abs(array[i]))
                    max = i;
            return max;
        }

    }
}
