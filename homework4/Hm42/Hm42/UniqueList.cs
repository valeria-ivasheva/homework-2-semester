using System;

namespace Hm42
{
    public class UniqueList : List
    {
        /// <summary>
        /// Добавляет элемент в список, если он уникальный.
        /// </summary>
        /// <exception cref="RepeatingElementException"> Если элемент повторяется</exception>
        /// <param name="value"> Добавляемый элемент</param>
        public override void Insert(string value)
        {
            if (HasElement(value))
            {
                throw new RepeatingElementException("Этот элемент не уникальный");
            }
            base.Insert(value);
        }

        /// <summary>
        /// Добавляет элемент в список под определенным индексом, если он уникальный
        /// </summary>
        /// <exception cref="RepeatingElementException"> Если элемент повторяется</exception>
        /// <param name="value"> Добавляемый элемент</param>
        /// <param name="index"> Индекс, куда нужно добавить</param>
        public override void InsertIndex(string value, int index)
        {
            if (HasElement(value))
            {
                throw new RepeatingElementException("Этот элемент не уникальный");
            }
            base.InsertIndex(value, index);
        }

        /// <summary>
        /// Удалить элемент из списка
        /// </summary>
        /// <exception cref="NonexistentException"> Если такого элемента нет в списке</exception>
        /// <param name="value"> Удаляемый элемент</param>
        public override void DeleteElement(string value)
        {
            if (!HasElement(value))
            {
                throw new NonexistentException("Нельзя удалить то, чего нет");
            }
            base.DeleteElement(value);
        }
    }
}
