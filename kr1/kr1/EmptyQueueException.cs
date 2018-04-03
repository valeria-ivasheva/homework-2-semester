using System;

namespace kr1
{
    /// <summary>
    /// Класс-исключение. Пустая очередь
    /// </summary>
    public class EmptyQueueException : Exception
    {
        public EmptyQueueException()
        {
        }

        public EmptyQueueException(string message) : base(message)
        {
        }
    }
}
