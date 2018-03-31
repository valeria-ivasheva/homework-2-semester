using System;

namespace Hm41
{
    /// <summary>
    /// Класс, описывающий оператора
    /// </summary>
    class Operand : ElementOfTree
    {
        private int number;

        public Operand(string str)
        {
            number = Int32.Parse(str);
        }

        /// <summary>
        /// Посчитать значение
        /// </summary>
        /// <returns> Само значение</returns>
        public override int Calculate()
        {
            return number;
        }

        /// <summary>
        /// Распечатать элемент
        /// </summary>
        public override void Print()
        {
            Console.Write($"{number} ");
        }
    }
}
