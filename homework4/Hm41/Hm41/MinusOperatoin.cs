using System;

namespace Hm41
{
    /// <summary>
    /// Класс, соответствующий операции вычитание
    /// </summary>
    class Subtraction : Operation
    {
        /// <summary>
        /// Считает разность 
        /// </summary>
        /// <returns> Результат операции вычитание</returns>
        public override int Calculate()
        {
            return LeftNode - RightNode;
        }

        /// <summary>
        /// Распечатать элемент
        /// </summary>
        public override void Print()
        {
            Console.Write("- ");
        }
    }
}
