using System;

namespace Hm41
{
    /// <summary>
    /// Класс, реализовывающий сложение
    /// </summary>
    class Addition : Operation
    {
        /// <summary>
        /// Посчитать сумму 
        /// </summary>
        /// <returns> Сумма двух чисел</returns>
        public override int Calculate()
        {
            return leftNode+rightNode;
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
