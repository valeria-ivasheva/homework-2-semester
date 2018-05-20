using System;

namespace ListGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            for (int i = 1; i <= 3; i++)
            {
                list.Add(i);
            }
            list.Add(34);
            list.Remove(34);
            var arrayTemp = new int[3];
            list.CopyTo(arrayTemp, 0);
            for (int i = 1; i <= 3; i++)
            {
                Console.Write(list[i]);
                Console.Write(" ");
            }
        }
    }
}
