using System;

namespace List
{
    class List
    {
        private class ListElement
        {
            public string value;
            public int index;
            public ListElement next;

            public ListElement(string value)
            {
                this.value = value;
            }
        }

        private ListElement head;
        private ListElement tail;
        private int size;

        public List()
        {
        }

        public List(string value)
        {
            var element = new ListElement(value);
            element.index = 1;
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
                newElement.index = 1;
                tail = head;
                size++;
                return;
            }
            newElement.index = tail.index + 1;
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

        public bool HasElement(string value)
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

        public void InsertIndex(string value, int index)
        {
            if (index > size + 1)
            {
                Console.WriteLine($"Index should not exceed {size + 1}");
                return;
            }
            var temp = head;
            var newElement = new ListElement(value);
            newElement.index = index;
            size++;
            if (index == 1)
            {
                if (head == null)
                {
                    tail = newElement;
                    head = newElement;
                    return;
                }
                newElement.next = head;
                head = newElement;
                FixIndex(head.next, index + 1);
                return;
            }
            for (int i = 1; i < index - 1; i++)
            {
                temp = temp.next;
            }
            if (index == size)
            {
                temp.next = newElement;
                tail = newElement;
                return;
            }
            newElement.next = temp.next;
            temp.next = newElement;
            FixIndex(newElement.next, index + 1);
        }

        private void FixIndex(ListElement element, int index)
        {
            for (int i = index; i <= size; i++)
            {
                element.index = i;
                element = element.next;
            }
        }

        public void DeleteElementIndex(int index)
        {
            var temp = head;
            if (temp == null)
            {
                return;
            }
            size--;
            if (index == 1)
            {
                head = temp.next;
                FixIndex(head, temp.index);
                if (temp == tail)
                {
                    tail = head;
                }
                return;
            }
            for (int i = 1; i < index - 1; i++)
            {
                temp = temp.next;
            }
            if (temp.next == tail)
            {
                tail = temp;
            }
            temp.next = temp.next.next;
            FixIndex(temp.next, index);
        }

        public void DeleteElement(string value)
        {
            var temp = head;
            if (temp == null)
            {
                return;
            }
            if (temp.value == value)
            {
                head = head.next;
                size--;
                if (temp == tail)
                {
                    tail = head;
                    size--;
                    return;
                }
                FixIndex(head, temp.index);
                return;
            }
            if (!HasElement(value))
            {
                Console.WriteLine($"This element does not exist {value}");
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
            size--;
            FixIndex(temp.next.next, temp.next.index);
            temp.next = temp.next.next;
        }
    }
}