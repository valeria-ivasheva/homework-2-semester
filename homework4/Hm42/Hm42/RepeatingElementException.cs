using System;

namespace Hm42
{
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
