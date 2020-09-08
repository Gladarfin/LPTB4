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
            //LinqBegin8°. Дана целочисленная последовательность.Найти количество ее положительных двузначных элементов, 
            //а также их среднее арифметическое(как вещественное число). 
            //Если требуемые элементы отсутствуют, то дважды вывести 0(первый раз как целое, второй — как вещественное).

            Task("LinqBegin8");
            var i = GetEnumerableInt();
            Put(i.Count(e => e > 0 && e.ToString().Length == 2));
            Put(i.Where(e => e > 0 && e.ToString().Length == 2).DefaultIfEmpty(0).Average());
        }
    }

}