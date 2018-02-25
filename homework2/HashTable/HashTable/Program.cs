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
            Console.WriteLine(hash.HasElement("tr"));
            Console.WriteLine(hash.HasElement("uoi"));
            hash.DeleteElement("uoi");
            hash.DeleteElement("tr");
        }
    }
}
