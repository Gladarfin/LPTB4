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
            //LinqBegin51°. Даны последовательности положительных целых чисел A и B; все числа в последовательности A различны. 
            //Получить последовательность строк вида «S: E», где S обозначает сумму тех чисел из B, которые оканчиваются на ту же цифру, 
            //что и число E — один из элементов последовательности A(например, «74:23»); если для числа E не найдено ни одного подходящего 
            //числа из последовательности B, то в качестве S указать 0.Расположить элементы полученной последовательности по возрастанию значений найденных сумм, 
            //а при равных суммах — по убыванию значений элементов A.

            Task("LinqBegin51");
            GetEnumerableInt().GroupJoin(GetEnumerableInt(),
                        x => x % 10,
                        y => y % 10,
                        (x, y) => new { x, y = y.Sum() })
             .OrderBy(e => e.y)
             .ThenByDescending(e => e.x)
             .Select(e => e.y.ToString() + ':' + e.x.ToString()).Put();            
        }
    }

}
