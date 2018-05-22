using System;
using System.Collections.Generic;

namespace Kr2
{
    /// <summary>
    /// Класс, реализующий сортировку пузырьком
    /// </summary>
    /// <typeparam name="T">Тип сортируемых значений</typeparam>
    public static class BubbleSortGeneric<T>
    {
        /// <summary>
        /// Generic метод пузырьковой сортировки
        /// </summary>
        /// <param name="list"> Список, сортируемых объектов</param>
        /// <param name="func"> Объект, позволяющий их сравнивать</param>
        /// <returns> Отсортированнный список</returns>
        public static List<T> BubbleSort(List<T> list, Func<T, T, bool> func)
        {
            bool flag = true;
            int i = 0;
            while ((i<list.Count) && flag)
            {
                flag = false;
                for (int j = 1; j<= list.Count - i - 1; ++j)
                {
                    if (func(list[j],list[j -1]))
                    {
                        T temp = list[j];
                        list[j] = list[j - 1];
                        list[j - 1] = temp;
                        flag = true;
                    }
                }
                ++i;
            }
            return list;
        }
    }
}
