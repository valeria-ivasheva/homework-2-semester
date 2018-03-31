using System;

namespace Hm42
{
    /// <summary>
    /// Класс-исключение: повторяющийся элемент
    /// </summary>
    public class RepeatingElementException : Exception
    {
        public RepeatingElementException()
        {
        }

        public RepeatingElementException(string message) : base(message)
        {
        }
    }
}
