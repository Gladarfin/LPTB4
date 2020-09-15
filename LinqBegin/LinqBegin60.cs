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
            //LinqBegin60°. Дана последовательность непустых строк A, содержащих только заглавные буквы латинского алфавита.
            //Для всех строк, начинающихся с одной и той же буквы, определить их суммарную длину и получить последовательность строк вида «S - C», 
            //где S — суммарная длина всех строк из A, которые начинаются с буквы С. Полученную последовательность упорядочить по убыванию числовых значений сумм, 
            //а при равных значениях сумм — по возрастанию кодов символов C.

            Task("LinqBegin60");
            GetEnumerableString().GroupBy(c => c[0],
                                          (c,s) => new { a = s.Select(e => e.Length).Sum(), c })
                .OrderByDescending(e => e.a)
                .ThenBy(e => e.c).Select(e => e.a.ToString() + '-'+e.c)
                .Put();            
        }
    }

}
