using System;

namespace Hm41
{
    class Operand : ElementOfTree
    {
        private int number;

        public Operand(string str)
        {
            number = Int32.Parse(str);
        }

        public override int Calculate()
        {
            return number;
        }

        public override void Print()
        {
            Console.Write($"{number} ");
        }
    }
}
