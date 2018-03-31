using System;

namespace Hm41
{
    /// <summary>
    /// Класс-исключение: неправильный ввод
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
