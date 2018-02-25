using System;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List();
            list.Insert("ljj");
            list.Insert("pop");
            list.Insert("op");
            list.InsertIndex("hk", 1);
            list.PrintList();
            list.DeleteElement("ljj");
            list.DeleteElement("l");
            list.DeleteElement("op");
            list.Insert("uy");
            list.DeleteElement("hk");
            list.PrintList();
            list.DeleteElementIndex(2);
            list.PrintList();
        }
    }
}
