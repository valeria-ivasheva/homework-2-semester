﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace ListGeneric
{
    /// <summary>
    /// Список - генерик
    /// </summary>
    /// <typeparam name="T"> Тип, хранящийся в списке</typeparam>
    public class List<T> : IList<T>
    {
        private ListElement head;
        private ListElement tail;

        private class ListElement
        {
            public T value;
            public ListElement next;

            public ListElement(T value)
            {
                this.value = value;
            }
        }

        public T this[int index] { get => GetElement(index); set => SetElement(index, value); }

        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        public int Count { get; private set; }

        public bool IsReadOnly => false;

        /// <summary>
        /// Добавить элемент в список
        /// </summary>
        /// <param name="item"> Добавляемый элемент</param>
        public void Add(T item)
        {
            var newElement = new ListElement(item);
            if (IsEmpty())
            {
                head = newElement;
                tail = head;
                Count++;
                return;
            }
            tail.next = newElement;
            tail = newElement;
            Count++;
        }

        private void SetElement(int index, T value)
        {
            Insert(index, value);
            RemoveAt(index + 1);
        }

        private T GetElement(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            var temp = head;
            for (int i = 0; i < index; i++)
            {
                temp = temp.next;
            }
            return temp.value;
        }

        private bool IsEmpty() => Count == 0;

        /// <summary>
        /// Почистить список
        /// </summary>
        public void Clear()
        {
            Count = 0;
            head = null;
            tail = null;
        }

        /// <summary>
        /// Проверка, есть ли такой элемент в списке
        /// </summary>
        /// <param name="item"> Проверяемый элемент</param>
        /// <returns> True, если есть</returns>
        public bool Contains(T item)
        {
            var temp = head;
            for (int i = 0; i < Count; i++)
            {
                if (Equals(temp.value, item))
                {
                    return true;
                }
                temp = temp.next;
            }
            return false;
        }

        /// <summary>
        /// Копирует элементы списка в массив, начиная с некоторого индекса
        /// </summary>
        /// <param name="array"> Массив, куда копируется список</param>
        /// <param name="arrayIndex"> Индекс, с которого начинается копирование</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = arrayIndex; arrayIndex + Count > i; i++)
            {
                array[i] = this[i - arrayIndex];
            }
        }

        /// <summary>
        /// Определяет индекс заданного элемента в списке
        /// </summary>
        /// <param name="item"> Элемент, индекс которого нужно найти</param>
        /// <returns> Индекс элемента, -1 если такого нет</returns>
        public int IndexOf(T item)
        {
            var temp = head;
            for (int i = 0; i < Count; i++)
            {
                if (Equals(temp.value, item))
                {
                    return i;
                }
                temp = temp.next;
            }
            return -1;
        }

        /// <summary>
        /// Вставляет элемент в список по указанному индексу
        /// </summary>
        /// <param name="index"> Индекс, куда вставить</param>
        /// <param name="item"> Элемент</param>
        public void Insert(int index, T item)
        {
            if (index > Count + 1)
            {
                Console.WriteLine($"Index should not exceed {Count + 1}");
                throw new IndexOutOfRangeException();
            }
            var newElement = new ListElement(item);
            var temp = head;
            Count++;
            if (index == 0)
            {
                if (head == null)
                {
                    tail = newElement;
                    head = newElement;
                    return;
                }
                newElement.next = head;
                head = newElement;
                return;
            }
            for (int i = 0; i < index - 1; i++)
            {
                temp = temp.next;
            }
            if (index == Count)
            {
                tail = newElement;
                temp.next = newElement;
                return;
            }
            newElement.next = temp.next;
            temp.next = newElement;
        }

        /// <summary>
        /// Удаляет первое вхождение указанного объекта из списка
        /// </summary>
        /// <param name="item"> Удаляемый элемент</param>
        /// <returns> Возвращает true, если смогли удалить</returns>
        public bool Remove(T item)
        {
            var temp = head;
            if (Equals(item, temp.value))
            {
                head = head.next;
                if (temp == tail)
                {
                    tail = head;
                }
                Count--;
                return true;
            }
            if (!Contains(item))
            {
                Console.WriteLine($"This element does not exist {item}");
                return false;
            }
            while (!Equals(temp.next.value, item))
            {
                temp = temp.next;
            }
            if (temp.next == tail)
            {
                tail = temp;
            }
            temp.next = temp.next.next;
            Count--;
            return true;
        }

        /// <summary>
        /// Удаляет элемент по индексу
        /// </summary>
        /// <param name="index"> Индекс, по которому мы хотим удалить</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index > Count - 1 || Count == 0)
            {
                return;
            }
            Count--;
            var temp = head;
            if (index == 0)
            {
                head = temp.next;
                if (temp == tail)
                {
                    tail = null;
                }
                return;
            }
            for (int i = 0; i < index - 1; i++)
            {
                temp = temp.next;
            }
            if (temp.next == tail)
            {
                tail = temp;
            }
            temp.next = temp.next.next;
        }

        /// <summary>
        /// Возвращает перечислитель, выполняющий перебор элементов в коллекции
        /// </summary>
        /// <returns> Перечислитель, который можно использовать для итерации по коллекции</returns>
        public IEnumerator<T> GetEnumerator() => new ListEnum(this);

        /// <summary>
        /// Перечислитель, который можно использовать для итерации по коллекции
        /// </summary>
        public class ListEnum : IEnumerator<T>
        {
            private int position;
            private List<T> list;

            public ListEnum(List<T> list)
            {
                this.list = list;
                position = -1;
            }

            public T Current { get; private set; }

            object IEnumerator.Current => Current;

            void IDisposable.Dispose()
            {
            }

            bool IEnumerator.MoveNext()
            {
                if (position + 1 >= list.Count)
                {
                    return false;
                }
                position++;
                Current = list[position];
                return true;
            }

            void IEnumerator.Reset()
            {
                Current = default(T);
                position = -1;
            }
        }

        /// <summary>
        /// Возвращает энумератор для контейнера
        /// </summary>
        /// <returns> Энумератор</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
