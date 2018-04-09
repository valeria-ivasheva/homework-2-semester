using System;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            stack.Push(22);
            stack.Push(12);
            while (!stack.IsEmpty())
            {
                Console.WriteLine("Element of stack {0}", stack.Pop());
            }
        }
    }

}
