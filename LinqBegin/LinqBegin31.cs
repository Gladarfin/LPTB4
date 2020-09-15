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
            //Дано целое число K(> 0) и последовательность непустых строк A.
            //Строки последовательности содержат только цифры и заглавные буквы латинского алфавита. 
            //Найти теоретико-множественное пересечение двух фрагментов A: первый содержит K начальных элементов, а второй — все элементы, 
            //расположенные после последнего элемента, оканчивающегося цифрой. 
            //Полученную последовательность(не содержащую одинаковых элементов) отсортировать по возрастанию длин строк, а строки одинаковой длины — в лексикографическом порядке по возрастанию.

            Task("LinqBegin31");
            int k = GetInt();
            var a = GetEnumerableString();
            var b = a.Take(k).Intersect(a.Reverse().
                    TakeWhile(c=> !char.IsDigit(c[c.Length-1])).Reverse())
                    .Distinct().OrderBy(s => s.Length).ThenBy(s=>s);
            Put(b.Count(), b);       
        }
    }

}
