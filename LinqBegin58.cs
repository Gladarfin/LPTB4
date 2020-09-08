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
            //LinqBegin58°. Дана последовательность непустых строк. Среди всех строк, начинающихся с одного и того же символа, 
            //выбрать наиболее длинную.Если таких строк несколько, то выбрать первую по порядку их следования в исходной последовательности.
            //Полученную последовательность строк упорядочить по возрастанию кодов их начальных символов. 

            Task("LinqBegin58");
            GetEnumerableString().GroupBy(c => c[0],
                                          (a, s) => s.OrderByDescending(e => e.Length).First())
                                 .OrderBy(c => c[0])
                                 .Put();            
        }
    }

}
