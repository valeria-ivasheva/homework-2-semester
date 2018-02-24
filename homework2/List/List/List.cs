using System;

namespace List
{
    class List
    {
        private class ListElement
        {
            public int value;
            public ListElement next;

            public ListElement(int value)
            {
                this.value = value;
            }
        }

        private ListElement head;
        private ListElement tail;
        private int size;

        public bool IsEmpty() => size == 0;

        public void Insert(int value)
        {
            var newElement = new ListElement(value);
            if (IsEmpty())
            {
                head = newElement;
                tail = head;
                size++;
                return;
            }
            tail.next = newElement;
            tail = newElement;
            size++;
        }

        public void PrintList()
        {
            var temp = head;
            if (temp == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            Console.WriteLine("List:");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(temp.value);
                temp = temp.next;
            }
        }

        public bool IsHaveElement(int value)
        {
            var temp = head;
            for (int i = 0; i < size; i++)
            {
                if (temp.value == value)
                {
                    return true;
                }
                temp = temp.next;
            }
            return false;
        }

        public void DeleteElement(int value)
        {
            var temp = head;
            if (temp.value == value)
            {
                head = head.next;
                if (temp == tail)
                {
                    tail = head;
                }
                size--;
                return;
            }
            if (!IsHaveElement(value))
            {
                Console.WriteLine("This element does not exist {0}", value);
                return;
            }
            while (temp.next.value != value)
            {
                temp = temp.next;
            }
            if (temp.next == tail)
            {
                tail = temp;
            }
            temp.next = temp.next.next;
            size--;
        }
    }
}
