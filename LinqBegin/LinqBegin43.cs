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
            //LinqBegin43°. Дано целое число K(> 0) и последовательность непустых строк A.
            //Получить последовательность символов, которая определяется следующим образом: для первых K элементов последовательности A в новую 
            //последовательность заносятся символы, стоящие на нечетных позициях данной строки(1, 3, …), 
            //а для остальных элементов A — символы на четных позициях(2, 4, …). 
            //В полученной последовательности поменять порядок элементов на обратный. 

            Task("LinqBegin43");
            int k = GetInt();
            GetEnumerableString().SelectMany((s, i) => (i + 1)<=k ?
                                 s.Where((c, j) => (j + 1)%2 == 1) :
                                 s.Where((c, j) => (j + 1)%2 == 0))
                                 .Reverse().Put();            
        }
    }

}
