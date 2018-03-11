using System;

namespace Hm41
{
    class Operation : ElementOfTree
    {
        private string arithmeticOperator;
        private int leftNode;
        private int rightNode;

        public Operation(string str)
        {
            arithmeticOperator = str;
        }

        public void InsertNumber(int left, int right)
        {
            leftNode = left;
            rightNode = right;
        }

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

        public override void Print()
        {
            Console.Write(arithmeticOperator, " ");
        }
    }
}
