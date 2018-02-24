using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var hash = new HashTable();
            hash.InsertElement("uoi");
            hash.InsertElement("gnhng");
            Console.WriteLine(hash.IsHaveElement("tr"));
            Console.WriteLine(hash.IsHaveElement("uoi"));
            hash.DeleteElement("uoi");
            hash.DeleteElement("tr");
        }
    }
}
