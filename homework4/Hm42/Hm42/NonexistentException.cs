using System;
namespace Hm42
{
    /// <summary>
    /// Класс-исключение: Элемент не существует
    /// </summary>
    public class NonexistentException : Exception
    {
        public NonexistentException()
        {
        }

        public NonexistentException(string message) : base(message)
        {
        }
    }
}
