using System;

namespace HashTable3
{
    class Program
    {
        static void Main(string[] args)
        {
            var hash = new HashTable(new HashFunction());
            hash.InsertElement("uoi");
            hash.InsertElement("gnhng");
            Console.WriteLine(hash.HasElement("tr"));
            Console.WriteLine(hash.HasElement("uoi"));
            hash.DeleteElement("uoi");
            hash.DeleteElement("tr");
        }
    }
}

