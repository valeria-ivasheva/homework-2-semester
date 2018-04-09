using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            var inputString = Console.ReadLine();
            int n = int.Parse(inputString);
            Console.Write("Число Фибоначчи = ");
            Console.WriteLine(FibonacciNumber(n));
        }

        private static int FibonacciNumber(int n)
        {
            if (n <= 2) return 1;
            int temp = 1;
            int result = 1;
            while (n > 2)
            {
                int tempValue = temp + result;
                temp = result;
                result = tempValue;
                n -= 1;
            }
            return result;
        }

        
    }
}
