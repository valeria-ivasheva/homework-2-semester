using System;

namespace HashTable3
{
    /// <summary>
    /// Класс хэш-таблца
    /// </summary>
    public class HashTable
    {
        private const int HashTableSize = 100;
        private List[] buckets;

        private IHashFunction hashFunction;

        /// <summary>
        /// Создает хэш-таблицу с хэш-функцией hashFunction
        /// </summary>
        /// <param name="hashFunction">Хэш-функция</param>
        public HashTable(IHashFunction hashFunction)
        {
            this.hashFunction = hashFunction;
            buckets = new List[HashTableSize];
            for (var i = 0; i < HashTableSize; ++i)
            {
                buckets[i] = new List();
            }
        }

        private class StandartHashFunction : IHashFunction
        {
            public int GetHash(string value)
            {
                return Math.Abs(value.GetHashCode());
            }
        }

        /// <summary>
        /// Создает хэш-таблицу со стандартной хэш-функцией 
        /// </summary>
        public HashTable()
        {
            this.hashFunction = new StandartHashFunction();
            buckets = new List[HashTableSize];
            for (var i = 0; i < HashTableSize; ++i)
            {
                buckets[i] = new List();
            }
        }

        /// <summary>
        /// Вставляет элемент в хэш-таблицу
        /// </summary>
        /// <param name="value">Элемент для добавления в таблицу</param>
        public void InsertElement(string value)
        {
            int number = Math.Abs(hashFunction.GetHash(value)) % HashTableSize;
            buckets[number].Insert(value);
        }

        /// <summary>
        /// Удалить элемент из хэш-таблицы
        /// </summary>
        /// <param name="value">Удаляемый элемент</param>
        public void DeleteElement(string value)
        {
            int number = Math.Abs(hashFunction.GetHash(value)) % HashTableSize;
            if (buckets[number] == null)
            {
                return;
            }
            buckets[number].DeleteElement(value);
        }

        /// <summary>
        /// Проверка на существование элемента в хэш-таблице
        /// </summary>
        /// <param name="value">Проверяемый элемент</param>
        /// <returns>Возвращает true, если есть в этот таблице </returns>
        public bool HasElement(string value)
        {
            int number = Math.Abs(hashFunction.GetHash(value)) % HashTableSize;
            if (buckets[number] == null)
            {
                return false;
            }
            return buckets[number].HasElement(value);
        }
    }
}
