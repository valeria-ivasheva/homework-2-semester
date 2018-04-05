using System;

namespace Hm41
{
    /// <summary>
    /// Класс, описывающий оператора
    /// </summary>
    class Operation : ElementOfTree
    {
        private string arithmeticOperator;
        private int leftNode;
        private int rightNode;

        public Operation(string str)
        {
            arithmeticOperator = str;
        }

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
        /// Посчитать значение
        /// </summary>
        /// <exception cref="DivideByZeroException"> При делении на ноль</exception>
        /// <exception cref="InputErrorException"> При некорректном вводе</exception>
        /// <returns> Посчитанное значение</returns>
        public override int Calculate()
        {
            switch (arithmeticOperator)
            {
                case "+":
                    {
                        return leftNode + rightNode;
                    }
                case "-":
                    {
                        return leftNode - rightNode;
                    }
                case "*":
                    {
                        return leftNode * rightNode;
                    }
                case "/":
                    {
                        if (rightNode == 0)
                        {
                            throw new DivideByZeroException("Division by zero");
                        }
                        return leftNode / rightNode;
                    }
                default:
                    throw new InputErrorException("It isn't operator");
            }
        }

        /// <summary>
        /// Распечатать элемент
        /// </summary>
        public override void Print()
        {
            Console.Write(arithmeticOperator, " ");
        }
    }
}
