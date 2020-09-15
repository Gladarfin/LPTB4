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
            //LinqBegin10°. Дано целое число L(> 0) и строковая последовательность A. Строки последовательности A содержат только заглавные буквы латинского алфавита.
            //Среди всех строк из A, имеющих длину L, найти наибольшую(в смысле лексикографического порядка). 
            //Вывести эту строку или пустую строку, если последовательность не содержит строк длины L. 

            Task("LinqBegin10");
            int l = GetInt();
            var a = GetEnumerableString();
            Put(a.Where(s => s.Length==l).DefaultIfEmpty("").Max());

        }
    }

}
