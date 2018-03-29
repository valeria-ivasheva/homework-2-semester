using System;

namespace Calculator_61_
{
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
