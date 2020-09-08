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
            //LinqBegin56°. Дана целочисленная последовательность A. Сгруппировать элементы последовательности A, 
            //оканчивающиеся одной и той же цифрой, и на основе этой группировки получить последовательность строк вида «D: S», 
            //где D — ключ группировки(т.е.некоторая цифра, которой оканчивается хотя бы одно из чисел последовательности A), 
            //а S — сумма всех чисел из A, которые оканчиваются цифрой D. Полученную последовательность упорядочить по возрастанию ключей.
            //Указание.Использовать метод GroupBy.

            Task("LinqBegin56");
            GetEnumerableInt().GroupBy(
                                       d => Math.Abs(d % 10),
                                       s => s,
                                       (d,s) => string.Format("{0}:{1}", d, s.Sum()))
                              .OrderBy(e=>e)
                              .Put();            
        }
    }

}
