using System;

namespace Stack
{
    class StackElement
    {
        public int value;
        public StackElement next;

        public StackElement()
        {
            value = 0;
            next = null;
        }

        public StackElement(int value)
        {
            this.value = value;
            next = null;
        }
    }

    class Stack
    {
        private StackElement head;
        private int size = 0;

        public Stack()
        {
            head = null;
        }
        
        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Push(int value)
        {
            StackElement newElement = new StackElement(value);
            if (IsEmpty())
            {
                head = newElement;
                size++;
                return;
            }
            newElement.next = head;
            head = newElement;
            size++;
        }

        public int Pop()
        {
            if (!IsEmpty())
            {
                size--;
                StackElement temp = head;
                head = temp.next;
                temp.next = null;
                return temp.value;
            }
            else
            {
                Console.WriteLine("Error: stack is Empty");
                return -1;
            }
        }
    }
}
