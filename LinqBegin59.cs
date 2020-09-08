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
            //LinqBegin59°. Дана последовательность непустых строк, содержащих только заглавные буквы латинского алфавита.
            //Среди всех строк одинаковой длины выбрать первую в лексикографическом порядке(по возрастанию). 
            //Полученную последовательность строк упорядочить по убыванию их длин. 

            Task("LinqBegin59");
            GetEnumerableString().GroupBy(c => c.Length,
                                          (a,s) => s.OrderBy(e => e).First())
                                 .OrderByDescending(e => e.Length)
                                 .Put();            
        }
    }

}
