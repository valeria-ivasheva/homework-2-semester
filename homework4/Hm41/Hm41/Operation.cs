using System;

namespace Hm41
{
    /// <summary>
    /// Класс, описывающий оператора
    /// </summary>
    class Operation : ElementOfTree
    {
        protected int leftNode;
        protected int rightNode;

        /// <summary>
        /// Присваивает операнды для данного оператора
        /// </summary>
        /// <param name="left"> Левый операнд</param>
        /// <param name="right"> Правый операнд</param>
        public void InsertNumber(int left, int right)
        {
            leftNode = left;
            rightNode = right;
        }

        /// <summary>
        /// Напечатать 
        /// </summary>
        public override void Print()
        {
        }
        /// <summary>
        /// Считается в наследниках
        /// </summary>
        public override int Calculate()
        {
            throw new InputErrorException();
        }
    }
}
