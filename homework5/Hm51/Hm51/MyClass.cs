using System;
using System.Collections.Generic;

namespace Hm51
{
    public class MyClass
    {
        public static List<int> Map(List<int> list, Func <int, int> function)
        {
            var listResult = new List<int>();
            foreach (var element in list)
            {
                listResult.Add(function(element));
            }
            return listResult;
        }

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
