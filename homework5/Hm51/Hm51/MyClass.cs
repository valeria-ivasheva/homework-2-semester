using System;
using System.Collections.Generic;

namespace Hm51
{
    /// <summary>
    /// Мой класс
    /// </summary>
    public class MyClass
    {
        /// <summary>
        /// Возвращается список, полученный применением переданной функции к каждому элементу переданного списка
        /// </summary>
        /// <param name="list"> Список</param>
        /// <param name="function"> Функция, преобразующую элемент списка</param>
        /// <returns> Полученный список</returns>
        public static List<int> Map(List<int> list, Func <int, int> function)
        {
            var listResult = new List<int>();
            foreach (var element in list)
            {
                listResult.Add(function(element));
            }
            return listResult;
        }

        /// <summary>
        /// Возвращает список, составленный из тех элементов переданного списка, для которых переданная функция вернула true
        /// </summary>
        /// <param name="list"> Список</param>
        /// <param name="function"> Функцию, возвращающую булевое значение по элементу списка</param>
        /// <returns> Список, для которых функция верна</returns>
        public static List<int> Filter(List<int> list, Func<int, bool> function)
        {
            var listResult = new List<int>();
            foreach (var element in list)
            {
                if (function(element))
                {
                    listResult.Add(element);
                }
            }
            return listResult;
        }

        /// <summary>
        /// Возвращает накопленное значение, получившееся после всего прохода списка через функцию
        /// </summary>
        /// <param name="list"> Список</param>
        /// <param name="start"> Начальное значение</param>
        /// <param name="function"> Функция, которая берёт текущее накопленное значение и текущий элемент списка, и возвращает следующее накопленное значение</param>
        /// <returns> Накопленное значение</returns>
        public static int Fold(List<int> list, int start, Func <int, int, int> function)
        {
            foreach(var element in list)
            {
                start = function(start, element);
            }
            return start;
        }
    }
}
