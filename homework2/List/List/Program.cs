using System;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List();
            list.Insert(12);
            list.Insert(313);
            list.Insert(-21);
            list.Insert(0);
            list.PrintList();
            list.DeleteElement(-1);
            list.DeleteElement(12);
            list.DeleteElement(0);
            list.Insert(732);
            list.DeleteElement(-21);
            list.PrintList();
        }
    }
}
