using System;

namespace Calculator
{
    public class StackArray : IStack
    {
        private double[] stack = new double[100];
        int i = -1;

        public double Pop()
        {
            if (i == -1)
            {
                Console.WriteLine("Oops, stack is empty");
                return -1;
            }
            var value = stack[i];
            i--;
            return value;
        }

        public void Push(double value)
        {
            if (i > 98)
            {
                Console.WriteLine("Oops, input error");
                return;
            }
            i++;
            stack[i] = value;
        }

        public bool IsEmpty() => i == -1;
    }
}
