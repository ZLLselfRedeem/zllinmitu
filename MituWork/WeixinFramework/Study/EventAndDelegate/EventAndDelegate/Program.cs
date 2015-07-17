using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventAndDelegate
{
    public delegate T PerformCalc<T>(T x, T y);

    class Calculator 
    {
        PerformCalc<int> perfCalc;

        public Calculator() 
        {
            perfCalc = CalculateProduct;
        }

        public PerformCalc<int> CalcDelegate
        {
            get { return perfCalc; }
        }

        private int CalculateProduct(int num1, int num2) 
        {
            return num1 * num2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            PerformCalc<int> del = calc.CalcDelegate;
            int result = del(10, 20);
            Console.WriteLine(result);
        }
    }
}
