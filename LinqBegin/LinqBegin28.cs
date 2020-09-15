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
            //LinqBegin28°. Дано целое число L(> 0) и последовательность непустых строк A.
            //Строки последовательности содержат только цифры и заглавные буквы латинского алфавита. 
            //Из элементов A, предшествующих первому элементу, длина которого превышает L, извлечь строки, оканчивающиеся буквой. 
            //Полученную последовательность отсортировать по убыванию длин строк, а строки одинаковой длины — в лексикографическом порядке по возрастанию.

            Task("LinqBegin28");
            int l = GetInt();
            var a = GetEnumerableString().TakeWhile(e => e.Length <= l)
										 .Where(c => c[c.Length - 1] >= 'A' && c[c.Length - 1] <= 'Z')
									     .OrderByDescending(s => s.Length)
										 .ThenBy(s => s);
            Put(a.Count(), a);
        }
    }

}
