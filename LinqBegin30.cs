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
            //LinqBegin30°. Дано целое число K(> 0) и целочисленная последовательность A. 
            //Найти теоретико-множественную разность двух фрагментов A: первый содержит все четные числа, а второй — все числа с порядковыми номерами, большими K. 
            //В полученной последовательности(не содержащей одинаковых элементов) поменять порядок элементов на обратный.

            Task("LinqBegin30");
            int k = GetInt();
            var a = GetEnumerableInt();
            var b = a.Where(e => e % 2 == 0).Except(a.Skip(k)).Distinct().Reverse();
            Put(b.Count(), b);            
        }
    }

}
