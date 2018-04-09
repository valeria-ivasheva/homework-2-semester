using System;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var myArray = GetArray();
            QuickSort(myArray, 0, myArray.Length - 1);
            PrintArray(myArray);
        }

        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                Console.Write(" ");
            }
        }

        private static int[] GetArray()
        {
            Console.WriteLine("Введите массив");
            var input = Console.ReadLine().Split(' ');
            var myArray = new int[input.Length];
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = Convert.ToInt32(input[i]);
            }
            return myArray;
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            int numberMiddle = (right + left) / 2;
            int middle = array[numberMiddle];
            int leftNow = left;
            int rightNow = right;
            while (leftNow <= rightNow)
            {
                while (array[leftNow] < array[numberMiddle]) leftNow++;
                while (array[rightNow] > array[numberMiddle]) rightNow--;
                if (leftNow <= rightNow)
                {
                    Swap(ref array[leftNow], ref array[rightNow]);
                    leftNow++;
                    rightNow--;
                }
            }
            if (rightNow > left)
            {
                QuickSort(array, left, rightNow);
            }
            if (leftNow < right)
            {
                QuickSort(array, leftNow, right);
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
