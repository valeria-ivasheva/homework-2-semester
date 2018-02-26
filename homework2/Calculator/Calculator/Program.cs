using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Console.WriteLine("Choose arrayStack (0) or stack (1)");
            int i = int.Parse(Console.ReadLine());
            if (i == 0)
            {
               var calculatorArray = new StackCalculator(str, new StackArray());
                calculatorArray.Calculate();
                return;
            }
            var calculator = new StackCalculator(str, new Stack());
            calculator.Calculate();
        }
    }
}