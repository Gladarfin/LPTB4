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
            //LinqBegin29°. Даны целые числа D и K(K > 0) и целочисленная последовательность A. 
            //Найти теоретико-множественное объединение двух фрагментов A: первый содержит все элементы до первого элемента, 
            //большего D(не включая его), а второй — все элементы, начиная с элемента с порядковым номером K. 
            //Полученную последовательность(не содержащую одинаковых элементов) отсортировать по убыванию.

            Task("LinqBegin29");
            int d = GetInt();
            int k = GetInt();
            var a = GetEnumerableInt();
            var b = a.TakeWhile(e => e < d).Union(a.Skip(k - 1)).Distinct().OrderByDescending(e => e);
            Put(b.Count(), b); 
        }
    }

}
