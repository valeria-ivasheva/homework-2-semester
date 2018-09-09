using System;

namespace SortMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива");
            int size = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = GetArray(size);
            QuickSort(matrix, 0, size - 1);
            PrintMatrix(matrix);
        }

        private static int[,] GetArray(int size)
        {
            int[,] myArray = new int[size, size];
            Console.WriteLine("Введите массив");
            for (int i = 0; i < size; i++)
            {
                var input = Console.ReadLine().Split(' ');
                for (int j = 0; j < size; j++)
                {
                    myArray[i, j] = Convert.ToInt32(input[j]);
                }
            }
            return myArray;
        }

        private static void QuickSort(int[,] array, int left, int right)
        {
            int numberMiddle = (right + left) / 2;
            int middle = array[0, numberMiddle];
            int leftNow = left;
            int rightNow = right;
            while (leftNow <= rightNow)
            {
                while (array[0, leftNow] < array[0, numberMiddle]) leftNow++;
                while (array[0, rightNow] > array[0, numberMiddle]) rightNow--;
                if (leftNow <= rightNow)
                {
                    Swap(ref array, leftNow, rightNow);
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

        private static void Swap(ref int [,] array, int left, int right)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int temp = array[i, left];
                array[i, left] = array[i, right];
                array[i, right] = temp;
            }
        }

        private static void PrintMatrix(int [,] array)
        {
            Console.WriteLine("Ваш отсортированный массив");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    Console.Write(array[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}

