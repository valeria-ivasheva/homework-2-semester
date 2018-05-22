using System;

namespace Hm41
{
    /// <summary>
    /// Класс, описывающий оператора
    /// </summary>
     class Operation : ElementOfTree
    {
        public int LeftNode { get; private set; }
        public int RightNode { get; private set; }

        /// <summary>
        /// Присваивает операнды для данного оператора
        /// </summary>
        /// <param name="left"> Левый операнд</param>
        /// <param name="right"> Правый операнд</param>
        public void InsertNumber(int left, int right)
        {
            LeftNode = left;
            RightNode = right;
        }

        /// <summary>
        /// Напечатать 
        /// </summary>
        public override void Print()
        {
        }

        public override int Calculate()
        {
            throw new InputErrorException();
        }
    }
}
