using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Hm72
{
    public class HashSet<T> : ISet<T>
    {
        private HashTable<T> hashtable;

        /// <summary>
        /// Создает хэш-таблицу 
        /// </summary>
        public HashSet()
        {
            hashtable = new HashTable<T>();
        }

        /// <summary>
        /// Количество элементов в множестве
        /// </summary>
        public int Count => hashtable.Count;

        /// <summary>
        /// Указывает доступен ли объект для чтения
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Добавляет элемент в текущий набор 
        /// </summary>
        /// <param name="item"> Добавляемый элемент</param>
        /// <returns> Возвращает значение, указывающее, что элемент был добавлен успешно</returns>
        public bool Add(T item)
        {
            if (hashtable.HasElement(item))
            {
                return false;
            }
            hashtable.InsertElement(item);
            return true;
        }

        /// <summary>
        /// Удаляет все элементы из множества
        /// </summary>
        public void Clear()
        {
            hashtable = new HashTable<T>();
        }

        /// <summary>
        /// Определяет, содержит ли указанное значение
        /// </summary>
        /// <param name="item"> Проверяемое значение</param>
        /// <returns> true - если содержит, false - нет</returns>
        public bool Contains(T item)
        {
            return hashtable.HasElement(item);
        }

        /// <summary>
        /// Копирует элементы множества в массив, начиная с некоторого индекса
        /// </summary>
        /// <param name="array"> Массив, куда копируется множество</param>
        /// <param name="arrayIndex"> Индекс, с которого начинается копирование</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length < Count)
            {
                return;
            }
            foreach (var element in hashtable)
            {
                array[arrayIndex] = element;
                arrayIndex++;
            }
        }

        /// <summary>
        /// Удаляет все элементы указанной коллекции из текущего набора
        /// </summary>
        /// <param name="other"> Коллекция элементов, которые нужно удалить</param>
        public void ExceptWith(IEnumerable<T> other)
        {
            foreach (var element in other)
            {
                if (Contains(element))
                {
                    Remove(element);
                }
            }
        }

        /// <summary>
        /// Изменяет текущий набор, чтобы он содержал только элементы, которые также имеются в заданной коллекции
        /// </summary>
        /// <param name="other"> Коллекция, с которой сравнивают</param>
        public void IntersectWith(IEnumerable<T> other)
        {
            var hashNew = new HashSet<T>();
            foreach (var element in other)
            {
                if (Contains(element))
                {
                    hashNew.Add(element);
                }
            }
            hashtable = hashNew.hashtable;
        }

        /// <summary>
        /// Определяет, является ли текущий набор должным (строгим) подмножеством заданной коллекции
        /// </summary>
        /// <param name="other"> Коллекция для сравнения с текущим набором</param>
        /// <returns></returns>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            if (Count == 0)
            {
                return true;
            }
            var setTemp = new HashSet<T>();
            setTemp.UnionWith(this);
            setTemp.IntersectWith(other);
            int size = other.Count();
            if (size == Count)
            {
                return false;
            }
            return Count == setTemp.Count;
        }

        /// <summary>
        /// Определяет, является ли текущий набор должным (строгим) подмножеством заданной коллекции
        /// </summary>
        /// <param name="other"> Коллекция для сравнения с текущим набором</param>
        /// <returns></returns>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            int size = other.Count();
            foreach (var element in other)
            {
                if (!Contains(element))
                {
                    return false;
                }
            }
            return (size < Count || size == 0 && Count == 0);
        }

        /// <summary>
        /// Определяет, является ли набор подмножеством заданной коллекции
        /// </summary>
        /// <param name="other"> Коллекция для сравнения с текущим набором</param>
        /// <returns></returns>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (Count == 0)
            {
                return true;
            }
            var setTemp = new HashSet<T>();
            setTemp.UnionWith(this);
            setTemp.IntersectWith(other);
            int size = other.Count();
            return Count == setTemp.Count;
        }

        /// <summary>
        /// Определяет, является ли текущий набор надмножеством заданной коллекции
        /// </summary>
        /// <param name="other"> Коллекция для сравнения с текущим набором</param>
        /// <returns> Значение true, если текущий набор является надмножеством объекта other; в противном случае — значение false.</returns>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            var setTemp = new HashSet<T>();
            setTemp.UnionWith(other);
            foreach (var element in setTemp)
            {
                if (!Contains(element))
                {
                    return false;
                }
            }
            return (setTemp.Count <= Count);
        }

        /// <summary>
        /// Определяет, пересекаются ли текущий набор и указанная коллекция
        /// </summary>
        /// <param name="other"> Коллекция для сравнения с текущим набором</param>
        /// <returns> Значение true, если в текущем множестве и объекте other есть хотя бы один общий элемент; в противном случае — значение false</returns>
        public bool Overlaps(IEnumerable<T> other)
        {
            var setNew = this;
            setNew.IntersectWith(other);
            return (setNew.Count != 0);
        }

        /// <summary>
        /// Удаляет первое вхождение указанного объекта из множества
        /// </summary>
        /// <param name="item"> Объект, который необходимо удалить из множества</param>
        /// <returns> Значение true, если объект item успешно удален из множества; 
        /// в противном случае и если значение item не найдено — значение false </returns>
        public bool Remove(T item)
        {
            if (!Contains(item))
            {
                return false;
            }
            hashtable.DeleteElement(item);
            return true;
        }

        /// <summary>
        /// Определяет, содержат ли текущий набор и указанная коллекция одни и те же элементы
        /// </summary>
        /// <param name="other"> Коллекция для сравнения с текущим набором</param>
        /// <returns> true - если текущий набор равен other; в противном случае — значение false</returns>
        public bool SetEquals(IEnumerable<T> other)
        {
            var setTemp = new HashSet<T>();
            setTemp.UnionWith(this);
            var set = new Set<T>();
            set.UnionWith(this);
            return (set.IsSubsetOf(other) && setTemp.IsSupersetOf(other));
        }

        /// <summary>
        /// Изменяет текущий набор таким образом, чтобы он содержал только элементы, которые есть либо в нем, либо в указанной коллекции, но не одновременно там и там
        /// </summary>
        /// <param name="other"> Коллекция для сравнения с текущим набором</param>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            var setNew = this;
            var setTemp = new HashSet<T>();
            setTemp.UnionWith(setNew);
            setNew.UnionWith(other);
            setTemp.IntersectWith(other);
            setNew.ExceptWith(setTemp);
            hashtable = setNew.hashtable;
        }

        /// <summary>
        /// Изменяет текущий набор так, чтобы он содержал все элементы, которые имеются в текущем наборе, в указанной коллекции либо в них обоих
        /// </summary>
        /// <param name="other"> Коллекция для сравнения с текущим набором</param>
        public void UnionWith(IEnumerable<T> other)
        {
            foreach (var element in other)
            {
                Add(element);
            }
        }

        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        /// <summary>
        /// Возвращает энумератор, выполняющий перебор элементов в множестве 
        /// </summary>
        /// <returns> Энумератор</returns>
        public IEnumerator<T> GetEnumerator() => hashtable.GetEnumerator();

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
