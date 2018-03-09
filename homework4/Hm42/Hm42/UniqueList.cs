using System;

namespace Hm42
{
    public class UniqueList : List
    {
        public override void Insert(string value)
        {
            if (HasElement(value))
            {
                throw new RepeatingElementException("Этот элемент не уникальный");
            }
            base.Insert(value);
        }

        public override void InsertIndex(string value, int index)
        {
            if (HasElement(value))
            {
                throw new RepeatingElementException("Этот элемент не уникальный");
            }
            base.InsertIndex(value, index);
        }

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
