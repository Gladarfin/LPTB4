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
			//LinqBegin55°. Даны последовательности положительных целых чисел A и B; все числа в каждой последовательности различны. 
            //Найти левое внешнее объединение A и B(см.LinqBegin54), пары в котором должны удовлетворять следующему условию: оба элемента пары 
            //оканчиваются одной и той же цифрой.Представить найденное объединение в виде последовательности строк вида «EA: EB», где EA — число из A,
            //а EB — либо одно из соответствующих ему чисел из B, либо 0(если в B не содержится чисел, соответствующих EA).
            //Расположить элементы полученной последовательности по убыванию чисел EA, а при одинаковых числах EA — по возрастанию чисел EB. 

            Task("LinqBegin55");
            GetEnumerableInt().OrderByDescending(e=>e).GroupJoin(
                                                                 GetEnumerableInt().OrderBy(e=>e),
                                                                 first => first % 10,
                                                                 second => second % 10,
                                                                 (left, e) => e.DefaultIfEmpty().Select(right => left.ToString() + ':' + right.ToString()))
                              .SelectMany(e => e)
                              .Put();            
        }
    }

}
