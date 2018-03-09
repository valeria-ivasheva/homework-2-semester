using System;
namespace Hm42
{
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
