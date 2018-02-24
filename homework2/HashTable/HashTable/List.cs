using System;

namespace ListSpace
{
    class List
    {
        private class ListElement
        {
            public string value;
            public ListElement next;

            public ListElement(string value)
            {
                this.value = value;
            }
        }

        private ListElement head;
        private ListElement tail;
        private int size;

        public List(string value)
        {
            var element = new ListElement(value);
            head = element;
            tail = head;
            size++;
        }

        public bool IsEmpty() => size == 0;

        public void Insert(string value)
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

        public bool IsHaveElement(string value)
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

        public void DeleteElement(string value)
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
