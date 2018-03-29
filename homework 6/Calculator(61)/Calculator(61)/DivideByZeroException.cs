using System;

namespace Calculator_61_
{
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