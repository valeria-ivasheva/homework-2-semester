namespace kr1
{
    /// <summary>
    /// Генерик-очередь с приоритетами
    /// </summary>
    /// <typeparam name="T"> Тип значений очереди</typeparam>
    public class PriorityQueue<T>
    {
        private class ElementQueue
        {
            public int key;
            public T value;
            public ElementQueue next;

            public ElementQueue(T value, int key)
            {
                this.key = key;
                this.value = value;
            }
        }
        private ElementQueue head;
        private ElementQueue tail;
        private int size;

        /// <summary>
        /// Добавить значение с приоритетом в очердь
        /// </summary>
        /// <param name="newVaue"> Значение добавляемое</param>
        /// <param name="newKey"> Численный приоритет</param>
        public void Enqueue(T newVaue, int newKey)
        {
            var newElement = new ElementQueue(newVaue, newKey);
            if (size == 0)
            {
                head = newElement;
                tail = head;
                size++;
                return;
            }
            size++;
            var temp = head;
            if (head.key < newKey)
            {
                newElement.next = head;
                head = newElement;
                return;
            }
            if (tail.key >= newKey)
            {
                tail.next = newElement;
                tail = newElement;
                return;
            }
            while (temp.next.key >= newKey)
            {
                temp = temp.next;
            }
            newElement.next = temp.next;
            temp.next = newElement;
        }

        /// <summary>
        /// Удалить значение с высшим приоритетом
        /// </summary>
        /// <returns> Возвращает значение удаляемого элемента</returns>
        /// <exception cref="EmptyQueueException"> Если очередь пуста</exception>
        public T Dequeue()
        {
            if (size == 0)
            {
                throw new EmptyQueueException();
            }
            T result = head.value;
            if (size == 1)
            {
                head = null;
                size = 0;
                return result;
            }
            head = head.next;
            size--;
            return result;
        }

        /// <summary>
        /// Проверка на существование элемента в очереди
        /// </summary>
        /// <param name="value"> Проверяемый элемент</param>
        /// <returns> Если есть, то возвращает true</returns>
        public bool HasElement(T value)
        {
            var temp = head;
            for (int i = 0; i < size; i++)
            {
                if (Equals(temp.value, value))
                {
                    return true;
                }
                temp = temp.next;
            }
            return false;
        }
    }
}
