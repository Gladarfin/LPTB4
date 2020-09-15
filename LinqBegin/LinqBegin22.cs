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
            //LinqBegin22°. Дано целое число K(> 0) и строковая последовательность A. 
            //Строки последовательности содержат только цифры и заглавные буквы латинского алфавита. 
            //Извлечь из A все строки длины K, оканчивающиеся цифрой, отсортировав их в лексикографическом порядке по возрастанию. 

            Task("LinqBegin22");
            int k = GetInt();
            var a = GetEnumerableString().Where(e => e.Length == k && e[e.Length - 1] >= '0' && e[e.Length - 1] <= '9').OrderBy(s => s);
            Put(a.Count(), a);
        }
    }

}
