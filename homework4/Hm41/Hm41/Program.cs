using System;

namespace Hm41
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new ParsTree("(- 2 (+ 23 9 ))");
            int result = tree.ResultArithmetic();
            Console.WriteLine(result);
            tree.Print();
        }
    }
}
