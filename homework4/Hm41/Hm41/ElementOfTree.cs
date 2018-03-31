namespace Hm41
{
    /// <summary>
    /// Абстрактный класс, представляющий элемент дерева
    /// </summary>
    abstract class ElementOfTree
    {
        /// <summary>
        /// Печать
        /// </summary>
        public abstract void Print();

        /// <summary>
        /// Посчитать
        /// </summary>
        /// <returns> Посчитанное значение</returns>
        public abstract int Calculate();
    }
}
