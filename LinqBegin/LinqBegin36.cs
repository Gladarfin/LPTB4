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
            //LinqBegin36°. Дана последовательность непустых строк. Получить последовательность символов, которая определяется следующим образом: 
            //если соответствующая строка исходной последовательности имеет нечетную длину, то в качестве символа берется первый символ этой строки; 
            //в противном случае берется последний символ строки.Отсортировать полученные символы по убыванию их кодов.

            Task("LinqBegin36");
            GetEnumerableString().Select(s => s.Length % 2 == 1 ? s[0] : s[s.Length - 1]).OrderByDescending(s=>s).Put();            
        }
    }

}
