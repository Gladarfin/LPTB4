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
            //LinqBegin44°. Даны целые числа K1 и K2 и целочисленные последовательности A и B. Получить последовательность, 
            //содержащую все числа из A, большие K1, и все числа из B, меньшие K2. Отсортировать полученную последовательность по возрастанию.

            Task("LinqBegin44");
            int k1 = GetInt();
            int k2 = GetInt();
            GetEnumerableInt().Where(a => a > k1).Concat(GetEnumerableInt().Where(b => b < k2)).OrderBy(e => e).Put();            
        }
    }

}
