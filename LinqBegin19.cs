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
            //LinqBegin19°. Дана цифра D(целое однозначное число) и целочисленная последовательность A. 
            //Извлечь из A все различные положительные числа, оканчивающиеся цифрой D(в исходном порядке).
            //При наличии повторяющихся элементов удалять все их вхождения, кроме последних.
            //Указание.Последовательно применить методы Reverse, Distinct, Reverse

            Task("LinqBegin19");
            var d = GetInt();
            var numbers = GetEnumerableInt().Where(e => e % 10 == d).Reverse().Distinct().Reverse();
            Put(numbers.Count(), numbers); 
        }
    }

}
