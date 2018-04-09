using System;

namespace Hm41
{
    /// <summary>
    /// Класс, соответствующий операции вычитание
    /// </summary>
    class Substraction : Operation
    {
        /// <summary>
        /// Считает разность 
        /// </summary>
        /// <returns> Результат операции вычитание</returns>
        public override int Calculate()
        {
            return leftNode - rightNode;
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
