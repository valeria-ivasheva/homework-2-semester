using System;

namespace Hm41
{
    /// <summary>
    /// Класс, реализовывающий умножение
    /// </summary>
    class Multiplication : Operation
    {
        /// <summary>
        /// Умножение двух чисел
        /// </summary>
        /// <returns> Результат умножения</returns>
        public override int Calculate()
        {
            return RightNode * LeftNode;
        }

        /// <summary>
        /// Распечатать элемент
        /// </summary>
        public override void Print()
        {
            Console.Write("* ");
        }
    }
}
