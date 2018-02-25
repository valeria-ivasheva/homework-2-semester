using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            double result = StackCalculator(str);
            Console.WriteLine($"(stackArray) = {result}");
        }

        private static double StackCalculator(string str)
        {
            var stackArray = new StackArray();
            var stack = new Stack();
            int count = CountSpace(str) + 1;
            for (int i = 0; i < count; i++)
            {
                int pos = str.IndexOf(' ');
                string temp;
                if (pos != -1)
                {
                    temp = str.Substring(0, pos);
                }
                else
                {
                    temp = str;
                }
                bool isDigit = Int32.TryParse(temp, out int digit);
                if (isDigit)
                {
                    stackArray.Push(digit);
                    stack.Push(digit);
                }
                else
                {
                    double aArray = 0;
                    double aStack = 0;
                    double bArray = 0;
                    double bStack = 0;
                    if (!stackArray.IsEmpty() || !stack.IsEmpty())
                    {
                        if (!stackArray.IsEmpty())
                        {
                            bArray = stackArray.Pop();
                        }
                        if (!stack.IsEmpty())
                        {
                            bStack = stack.Pop();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error input");
                        return -1;
                    }
                    if (!stackArray.IsEmpty() || !stack.IsEmpty())
                    {
                        if (!stackArray.IsEmpty())
                        {
                            aArray = stackArray.Pop();
                        }
                        if (!stack.IsEmpty())
                        {
                            aStack = stack.Pop();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error input");
                        return -1;
                    }
                    if (temp == "/" && (bArray == 0 || bStack == 0))
                    {
                        Console.WriteLine("Division by zero");
                        return -1;
                    }
                    stackArray.Push(Arithmetic(temp, aArray, bArray));
                    stack.Push(Arithmetic(temp, aStack, bStack));
                }
                str = str.Substring(pos + 1, str.Length - pos - 1);
            }
            Console.WriteLine($"(stack) = {stack.Pop()}");
            return stackArray.Pop();
        }

        private static double Arithmetic(string symbol, double a, double b)
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

        private static int CountSpace(string str)
        {
            int result = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    result++;
                }
            }
            return result;
        }
    }
}
