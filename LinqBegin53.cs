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
            //LinqBegin53°. Даны целочисленные последовательности A и B. Получить последовательность всех различных сумм, 
            //в которых первое слагаемое берется из A, а второе из B. Упорядочить полученную последовательность по возрастанию.

            Task("LinqBegin53");
            var a = GetEnumerableInt();
            var b = GetEnumerableInt();
            a.SelectMany(e => b.Select(f => e + f)).Distinct().OrderBy(e => e).Put();            
        }
    }

}
