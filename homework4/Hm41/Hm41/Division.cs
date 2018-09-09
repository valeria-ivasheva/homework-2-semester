using System;

namespace Hm41
{
    /// <summary>
    /// Класс, реализовывающий деление
    /// </summary>
    class Division : Operation
    {
        /// <summary>
        /// Значение при делении
        /// </summary>
        /// <exception cref="DivideByZeroException"> При делении на ноль</exception>
        /// <returns> Посчитанное значение</returns>
        public override int Calculate()
        {
            if (RightNode == 0)
            {
                throw new DivideByZeroException();
            }
            return LeftNode / RightNode;
        }

        /// <summary>
        /// Распечатать элемент
        /// </summary>
        public override void Print()
        {
            Console.Write("/ ");
        }
    }
}
