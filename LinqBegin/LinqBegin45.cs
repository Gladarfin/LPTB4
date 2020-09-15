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
            //LinqBegin45°. Даны целые положительные числа L1 и L2 и строковые последовательности A и B.
            //Строки последовательностей содержат только цифры и заглавные буквы латинского алфавита. Получить последовательность, 
            //содержащую все строки из A длины L1 и все строки из B длины L2.Отсортировать полученную последовательность в лексикографическом порядке по убыванию. 

            Task("LinqBegin45");
            int l1 = GetInt();
            int l2 = GetInt();
            GetEnumerableString().Where(a => a.Length == l1)
                                 .Concat(GetEnumerableString().Where(b => b.Length == l2))
                                 .OrderByDescending(s => s).Put();            
        }
    }

}
