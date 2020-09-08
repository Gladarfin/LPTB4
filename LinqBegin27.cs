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
            //LinqBegin27°. Дано целое число D и целочисленная последовательность A. Начиная с первого элемента A, большего D, 
            //извлечь из A все нечетные положительные числа, поменяв порядок извлеченных чисел на обратный.

            Task("LinqBegin27");
            int d = GetInt();
            var a = GetEnumerableInt().SkipWhile(e => e < d).Where(n => n % 2 == 1 && n > 0).Reverse();
            Put(a.Count(), a); 
        }
    }

}
