using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace Hm72
{
    /// <summary>
    /// Множество
    /// </summary>
    /// <typeparam name="T"> Тип, хранящийся в множестве</typeparam>
    public class Set<T> : ISet<T>
    {
        private SetElement head;

        private class SetElement
        {
            public T value;
            public SetElement next;

            public SetElement(T value)
            {
                this.value = value;
            }
        }

        /// <summary>
        /// Количество элементов в множестве
        /// </summary>
        public int Count { get; private set; }

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
            if (Contains(item))
            {
                return false;
            }
            var newElement = new SetElement(item);
            if (Count == 0)
            {
                head = newElement;
                Count++;
                return true;
            }
            var temp = head;
            head = newElement;
            newElement.next = temp;
            Count++;
            return true;
        }

        /// <summary>
        /// Удаляет все элементы из множества
        /// </summary>
        public void Clear()
        {
            head = null;
            Count = 0;
        }

        /// <summary>
        /// Определяет, содержит ли указанное значение
        /// </summary>
        /// <param name="item"> Проверяемое значение</param>
        /// <returns> true - если содержит, false - нет</returns>
        public bool Contains(T item)
        {
            if (Count == 0)
            {
                return false;
            }
            var temp = head;
            for (int i = 0; i < Count; i++)
            {
                if (Equals(item, temp.value))
                {
                    return true;
                }
                temp = temp.next;
            }
            return false;
        }

        /// <summary>
        /// Копирует элементы множества в массив, начиная с некоторого индекса
        /// </summary>
        /// <param name="array"> Массив, куда копируется множество</param>
        /// <param name="arrayIndex"> Индекс, с которого начинается копирование</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            var temp = head;
            for (int i = arrayIndex; arrayIndex + Count > i; i++)
            {
                array[i] = temp.value;
                temp = temp.next;
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
        /// Возвращает энумератор, выполняющий перебор элементов в множестве 
        /// </summary>
        /// <returns> Энумератор</returns>
        public IEnumerator<T> GetEnumerator() => new SetEnum(this);

        /// <summary>
        /// Изменяет текущий набор, чтобы он содержал только элементы, которые также имеются в заданной коллекции
        /// </summary>
        /// <param name="other"> Коллекция, с которой сравнивают</param>
        public void IntersectWith(IEnumerable<T> other)
        {
            var setNew = new Set<T>();
            foreach (var element in other)
            {
                if (Contains(element))
                {
                    setNew.Add(element);
                }
            }
            head = setNew.head;
            Count = setNew.Count;
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
            var setTemp = new Set<T>();
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
            int size = 0;
            foreach (var element in other)
            {
                size++;
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
            var setTemp = new Set<T>();
            setTemp.UnionWith(this);
            setTemp.IntersectWith(other);
            int size = 0;
            foreach (var element in other)
            {
                size++;
            }
            if (Count == setTemp.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Определяет, является ли текущий набор надмножеством заданной коллекции
        /// </summary>
        /// <param name="other"> Коллекция для сравнения с текущим набором</param>
        /// <returns> Значение true, если текущий набор является надмножеством объекта other; в противном случае — значение false.</returns>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            var setTemp = new Set<T>();
            setTemp.UnionWith(other);
            foreach (var element in setTemp)
            {
                if (!Contains(element))
                {
                    return false;
                }
            }
            if (setTemp.Count <= Count)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            if (setNew.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
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
            var temp = head;
            if (Equals(temp.value, item))
            {
                head = head.next;
                Count--;
                return true;
            }
            while (!Equals(temp.next.value, item))
            {
                temp = temp.next;
            }
            if (temp.next.next == null)
            {
                temp.next = null;
            }
            else
            {
                temp.next = temp.next.next;
            }
            Count--;
            return true;
        }

        /// <summary>
        /// Определяет, содержат ли текущий набор и указанная коллекция одни и те же элементы
        /// </summary>
        /// <param name="other"> Коллекция для сравнения с текущим набором</param>
        /// <returns> true - если текущий набор равен other; в противном случае — значение false</returns>
        public bool SetEquals(IEnumerable<T> other)
        {
            var setTemp = new Set<T>();
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
            var setTemp = new Set<T>();
            setTemp.UnionWith(setNew);
            setNew.UnionWith(other);
            setTemp.IntersectWith(other);
            setNew.ExceptWith(setTemp);
            head = setNew.head;
            Count = setNew.Count;
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
        /// Возвращает энумератор для контейнера
        /// </summary>
        /// <returns> Энумератор</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Реализует итератор множества
        /// </summary>
        public class SetEnum : IEnumerator<T>
        {
            private int position;
            private Set<T> set;

            public SetEnum(Set<T> set)
            {
                this.set = set;
                position = -1;
            }

            public T Current { get; private set; }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (position == set.Count - 1)
                {
                    return false;
                }
                position++;
                Current = Get(position);
                return true;
            }

            private T Get(int position)
            {
                var temp = set.head;
                for (int i = 0; i < position; i++)
                {
                    temp = temp.next;
                }
                return temp.value;
            }

            public void Reset()
            {
                Current = default(T);
                position = -1;
            }
        }
    }
}
