using System;

namespace Hm41
{
    public class ParsTree
    {
        private class Node
        {
            public ElementOfTree value;
            public Node leftChild;
            public Node rightChild;
        }
        
        private Node root;

        public ParsTree(string str)
        {
            root = DoTree(ref str);
        }

        private bool IsOperation(char symbol)
        {
            return (symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/');
        }

        private Node DoTree(ref string str)
        {
            Node node = new Node();
            if (str[0] != '(')
            {
                throw new InputErrorException();
            }
            if (!(IsOperation(str[1]) && str[2] == ' '))
            {
                throw new InputErrorException(" Error input");
            }
            var temp = new Operation(str.Substring(1, 1));
            str = str.Substring(3, str.Length - 3);
            for (int j = 0; j < 2; j++)
            {
                var strTemp = str.Substring(0, str.IndexOf(' '));
                if (strTemp[0] == '(')
                {
                    if (node.leftChild == null)
                    {
                        node.leftChild = DoTree(ref str);
                    }
                    else
                    {
                        node.rightChild = DoTree(ref str);
                    }
                }
                else if (Int32.TryParse(strTemp, out int number))
                {
                    Node tempNode = new Node
                    {
                        value = new Operand(strTemp)
                    };
                    if (node.leftChild == null)
                    {
                        node.leftChild = tempNode;
                    }
                    else
                    {
                        node.rightChild = tempNode;
                    }
                }
                else
                {
                    throw new InputErrorException();
                }
                str = str.Substring(str.IndexOf(' ') + 1);
            }
            temp.InsertNumber(node.leftChild.value.Calculate(), node.rightChild.value.Calculate());
            node.value = temp;
            if (str == "" || str[0] != ')')
            {
                throw new InputErrorException();
            }
            return node;
        }

        public void Print()
        {
            PrintNode(ref root);
        }

        private void PrintNode(ref Node node)
        {
            if (node == null)
            {
                return;
            }
            if (node.leftChild != null && node.rightChild != null)
            {
                Console.Write("(");
            }
            node.value.Print();
            PrintNode(ref node.leftChild);
            PrintNode(ref node.rightChild);
            if (node.leftChild != null && node.rightChild != null)
            {
                Console.Write(")");
            }
        }

        public int ResultArithmetic()
        {
            return root.value.Calculate();
        }
    }
}
