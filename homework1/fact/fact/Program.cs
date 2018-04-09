using System;

namespace Fact
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Его факториал = {0}", Factorial(n));
        }
        private static int Factorial(int n) => n <= 1 ? 1 : n * Factorial(n - 1);
    }
}
