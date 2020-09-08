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
            //LinqBegin50°. Даны строковые последовательности A и B; все строки в каждой последовательности различны и имеют ненулевую длину. 
            //Получить последовательность строк вида «E: N», где E обозначает один из элементов последовательности A, а N — количество элементов из B, 
            //начинающихся с того же символа, что и элемент E(например, «abc: 4»); количество N может быть равно 0.
            //Порядок элементов полученной последовательности должен определяться исходным порядком элементов последовательности A.
            //Указание.Использовать метод GroupJoin.

            Task("LinqBegin50");
            GetEnumerableString().GroupJoin(GetEnumerableString(),
                        x => x[0],
                        y => y[0],
                        (x, y) => string.Format("{0}:{1}", x, y.Count()))
             .Put();            
        }
    }

}
