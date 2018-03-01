using System;

namespace Calculator
{
    public class Stack : IStack
    {
        private class StackElement
        {
            public double value;
            public StackElement next;

            public StackElement(double value)
            {
                this.value = value;
            }
        }

        private StackElement head;

        public double Pop()
        {
            double result;
            if (head != null)
            {
                result = head.value;
                head = head.next;
            }
            else
            {
                Console.WriteLine("Oops, stack is empty");
                result = -1;
            }
            return result;
        }

        public void Push(double value)
        {
            var temp = new StackElement(value);
            if (head == null)
            {
                head = temp;
                return;
            }
            temp.next = head;
            head = temp;
        }
        
        public bool IsEmpty() => head == null;
    }
}
