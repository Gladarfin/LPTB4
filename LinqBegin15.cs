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
            //LinqBegin15°. Дано целое число N(0 ≤ N ≤ 15). Используя методы Range и Aggregate, найти факториал числа N: N! = 1·2·…·N при N ≥ 1; 0! = 1.
            //Чтобы избежать целочисленного переполнения, при вычислении факториала использовать вещественный числовой тип.

            Task("LinqBegin15");
            int n = GetInt();
            Put(Enumerable.Range(0, n).Aggregate(1.0, (num1, num2) => num1 + num1 * num2));
        }
    }

}
