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
            Console.WriteLine(Fib(n));
        }
        private static int Fib(int n) => n <= 2 ? 1 : Fib(n - 1) + Fib(n - 2);
        
    }
}
