using System;

namespace Hm41
{
    /// <summary>
    /// Класс дерево разбора 
    /// </summary>
    public class ParsTree
    {
        /// <summary>
        /// Элемент дерева разбора
        /// </summary>
        private class Node
        {
            public ElementOfTree value;
            public Node leftChild;
            public Node rightChild;
        }
        
        private Node root;

        /// <summary>
        /// Дерво разбора
        /// </summary>
        /// <param name="str"> Выражение, для которого пишется дерево разбора</param>
        public ParsTree(string str)
        {
            root = DoTree(ref str);
        }

        /// <summary>
        /// Проверка, является ли символ оператором
        /// </summary>
        /// <param name="symbol"> Проверяемый символ</param>
        /// <returns> True, если это оператор</returns>
        private bool IsOperation(char symbol)
        {
            return (symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/');
        }

        /// <summary>
        /// Создает для арифметической строки дерево разбора
        /// </summary>
        /// <param name="str"> Арифметическое выражение(строка)</param>
        /// <exception cref="InputErrorException"> Неправильный ввод</exception>
        /// <returns> Дерево разбора</returns>
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

        /// <summary>
        /// Печатает дерево
        /// </summary>
        public void Print()
        {
            PrintNode(ref root);
        }

        /// <summary>
        /// Печатает элемент дерева
        /// </summary>
        /// <param name="node"> Элемент дерева для печати</param>
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

        /// <summary>
        /// Возвращает результат для данного дерева
        /// </summary>
        /// <returns> Результат арифметического выражения для данного дерева</returns>
        public int ResultArithmetic()
        {
            return root.value.Calculate();
        }
    }
}
