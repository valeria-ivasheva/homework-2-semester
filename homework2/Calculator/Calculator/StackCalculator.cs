using System;

namespace Calculator
{
    class StackCalculator
    {
        private IStack stack;
        string str;

        public StackCalculator(string str, IStack choosenStack)
        {
            this.str = str;
            stack = choosenStack;
        }

        public  void Calculate()
        {
            string[] elements = str.Split(' ');
            for (int i = 0; i < elements.Length; i++)
            {
                bool isDigit = Int32.TryParse(elements[i], out int digit);
                if (isDigit)
                {
                    stack.Push(digit);
                }
                else
                {
                    double a = 0;
                    double b = 0;
                    if (!stack.IsEmpty())
                    {
                        b = stack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("Error input");
                        return;
                    }
                    if (!stack.IsEmpty())
                    {
                        a = stack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("Error input");
                        return;
                    }
                    if (elements[i] == "/" && Math.Abs(b) < 0.00001)
                    {
                        Console.WriteLine("Division by zero");
                        return;
                    }
                    stack.Push(ApplyArithmeticOperator(elements[i], a, b));
                }
            }
            Console.WriteLine($" = {stack.Pop()}");
        }

        private static double ApplyArithmeticOperator(string symbol, double a, double b)
        {
            double result = 0;
            switch (symbol)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    result = a / b;
                    break;
                default:
                    Console.WriteLine("Error input");
                    return -1;
            }
            return result;
        }
    }
}
