using System;

namespace Hm41
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
