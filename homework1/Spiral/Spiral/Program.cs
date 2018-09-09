using System;

namespace Spiral
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива");
            int size = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = GetArray(size);
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

        private static void PrintMatrix(int [,] matrix)
        {
            int size = matrix.GetLength(0);
            int i = size / 2;
            int j = i;
            PrintElement(matrix[i, j]);
            for (int step = 1; step <= size / 2; step++)
            {
                j++;
                for (int k = 0; k < step * 2; k++)
                {
                    PrintElement(matrix[i - k, j]);
                }
                i = i - step * 2 + 1;
                j--;
                for (int k = 0; k < step * 2; k++)
                {
                    PrintElement(matrix[i, j - k]);
                }
                j = j - step * 2 + 1;
                i++;
                for (int k = 0; k < step * 2; k++)
                {
                    PrintElement(matrix[i + k, j]);
                }
                i = i + step * 2 - 1;
                j++;
                for (int k = 0; k < step * 2; k++)
                {
                    PrintElement(matrix[i, j + k]);
                }
                j = j + step * 2 - 1;
            }
        }

        private static void PrintElement(int val)
        {
            Console.Write(val);
            Console.Write(" ");
        }
    }
}
