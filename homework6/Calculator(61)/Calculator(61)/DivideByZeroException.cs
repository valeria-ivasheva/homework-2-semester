using System;

namespace Calculator_61_
{
    /// <summary>
    /// Класс-исключение: Деление на ноль
    /// </summary>
    public class DivideByZeroException : Exception
    {
        public DivideByZeroException()
        {
        }

        public DivideByZeroException(string message) : base(message)
        {
        }
    }
}