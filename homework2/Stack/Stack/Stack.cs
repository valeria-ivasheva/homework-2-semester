using System;

namespace Stack
{
    class Stack
    {
        private class StackElement
        {
            public int value;
            public StackElement next;

            public StackElement(int value)
            {
                this.value = value;
            }
        }

        private StackElement head;
        private int size;

        public bool IsEmpty() => size == 0;

        public void Push(int value)
        {
            var newElement = new StackElement(value);
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
                return temp.value;
            }
            Console.WriteLine("Error: stack is Empty");
            return -1;
        }
    }
}
