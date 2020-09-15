using PT4;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Schema;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        // При решении задач группы LinqBegin доступны следующие
        // дополнительные методы, определенные в задачнике:
        //
        //   GetEnumerableInt() - ввод числовой последовательности;
        //
        //   GetEnumerableString() - ввод строковой последовательности;
        //
        //   Put() (метод расширения) - вывод последовательности;
        //
        //   Show() и Show(cmt) (методы расширения) - отладочная печать
        //     последовательности, cmt - строковый комментарий;
        //
        //   Show(e => r) и Show(cmt, e => r) (методы расширения) -
        //     отладочная печать значений r, полученных из элементов e
        //     последовательности, cmt - строковый комментарий.

        public static void Solve()
        {
            //LinqBegin26°. Даны целые числа K1 и K2 и последовательность непустых строк A; 1 < K1 < K2 ≤ N, 
            //где N — размер последовательности A.Найти среднее арифметическое длин всех элементов последовательности, 
            //кроме элементов с порядковыми номерами от K1 до K2 включительно, и вывести его как вещественное число.

            Task("LinqBegin26");
            int k1 = GetInt();
            int k2 = GetInt();
            var a = GetEnumerableString();
            Put(a.Take(k1-1).Union(a.Skip(k2).Take(a.Count()-k2)).Select(e=>e.Length).Average()); 
        }
    }

}
