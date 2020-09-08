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
            //LinqBegin3°. Дано целое число L(> 0) и строковая последовательность A. Вывести последнюю строку из A, 
            //начинающуюся с цифры и имеющую длину L.Если требуемых строк в последовательности A нет, то вывести строку «Not found».
            //Указание.Для обработки ситуации, связанной с отсутствием требуемых строк, использовать операцию ??.

            Task("LinqBegin3");
            int l = GetInt();
            var a = GetEnumerableString();
            Put(a.LastOrDefault(s => s.Length!=0 && s[0] >= '0' && s[0] <= '9' && s.Length == l) ?? "Not found");
        }
    }

}
