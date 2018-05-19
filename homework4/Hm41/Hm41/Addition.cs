using System;

namespace Hm41
{
    /// <summary>
    /// Класс, реализующий сложение
    /// </summary>
    class Addition : Operation
    {
        /// <summary>
        /// Посчитать сумму 
        /// </summary>
        /// <returns> Сумма двух чисел</returns>
        public override int Calculate()
        {
            return LeftNode + RightNode;
        }

        /// <summary>
        /// Распечатать элемент
        /// </summary>
        public override void Print()
        {
            Console.Write("+ ");
        }
    }
}
