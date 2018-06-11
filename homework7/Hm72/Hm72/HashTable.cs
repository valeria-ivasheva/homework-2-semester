using System;
using System.Collections;
using System.Collections.Generic;

namespace Hm72
{
    /// <summary>
    /// Класс хэш-таблица
    /// </summary>
    public class HashTable<T> : IEnumerable
    {
        private const int HashTableSize = 100;
        private List<T>[] buckets;

        /// <summary>
        /// Количество элементов в хэш-таблице
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Создает хэш-таблицу 
        /// </summary>
        public HashTable()
        {
            buckets = new List<T>[HashTableSize];
            Count = 0;
            for (var i = 0; i < HashTableSize; ++i)
            {
                buckets[i] = new List<T>();
            }
        }

        private int hashFunction(T value)
        {
            return Math.Abs(value.GetHashCode()) % HashTableSize;
        }

        /// <summary>
        /// Вставляет элемент в хэш-таблицу
        /// </summary>
        /// <param name="value">Элемент для добавления в таблицу</param>
        public void InsertElement(T value)
        {
            int number = hashFunction(value);
            buckets[number].Add(value);
            Count++;
        }

        /// <summary>
        /// Удалить элемент из хэш-таблицы
        /// </summary>
        /// <param name="value">Удаляемый элемент</param>
        public void DeleteElement(T value)
        {
            int number = hashFunction(value);
            if (buckets[number] == null)
            {
                return;
            }
            buckets[number].Remove(value);
            Count--;
        }

        /// <summary>
        /// Проверка на существование элемента в хэш-таблице
        /// </summary>
        /// <param name="value">Проверяемый элемент</param>
        /// <returns>Возвращает true, если есть в этот таблице </returns>
        public bool HasElement(T value)
        {
            int number = hashFunction(value);
            if (buckets[number] == null)
            {
                return false;
            }
            return buckets[number].Contains(value);
        }

        public IEnumerator<T> GetEnumerator() => new HashEnum(this);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class HashEnum : IEnumerator<T>
        {
            private int position;
            private HashTable<T> hashtable;

            public HashEnum(HashTable<T> hashTable)
            {
                this.hashtable = hashTable;
                position = -1;
            }

            public T Current { get; private set; }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (position == hashtable.Count - 1)
                {
                    return false;
                }
                position++;
                Current = Get(position);
                return true;
            }

            /// До конца не дойдет, так как в функции которая вызывает есть проверка на конец
            private T Get(int position)
            {
                int i = 0;
                for (int j = 0; j < HashTableSize; j++)
                {
                    if (hashtable.buckets[j] != null)
                    {
                        foreach (var element in hashtable.buckets[j])
                        {
                            if (position == i)
                            {
                                return element;
                            }
                            i++;
                        }
                    }
                }
                throw new Exception();
            }

            public void Reset()
            {
                Current = default(T);
                position = -1;
            }
        }
    }
}
