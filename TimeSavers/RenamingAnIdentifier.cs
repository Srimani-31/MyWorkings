using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSavers
{
    class RenamingAnIdentifier
    {
    }

    public class Calculator
    {
        private readonly double num1;
        private readonly double num2;

        public Calculator(double num1, double num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }

        // Add two numbers
        public double Add()
        {
            return num1 + num2;
        }

        // Subtract two numbers
        public double Subtract()
        {
            return num1 - num2;
        }

        // Multiply two numbers
        public double Multiply()
        {
            return num1 * num2;
        }

        // Divide two numbers
        public double Divide()
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return num1 / num2;
        }
    }

}
