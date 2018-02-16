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

        private static int FibonacciNumber(int n) => n <= 2 ? 1 : FibonacciNumber(n - 1) + FibonacciNumber(n - 2);
        
    }
}
