using System;

namespace Calculator
{
    /// <summary>
    /// Класс-исключение: Неправильно введенны данные
    /// </summary>
    public class InputErrorException : Exception
    {
        public InputErrorException()
        {
        }
 
        public InputErrorException(string message) : base(message)
        {
        }
    }
}
