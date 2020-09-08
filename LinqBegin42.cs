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
            //LinqBegin42°. Дана последовательность непустых строк. Получить последовательность символов, которая определяется следующим образом: 
            //для строк с нечетными порядковыми номерами(1, 3, …) в последовательность символов включаются все прописные латинские буквы, содержащиеся в этих строках, 
            //а для строк с четными номерами(2, 4, …) — все их строчные латинские буквы.
            //В полученной последовательности символов сохранить их исходный порядок следования.

            Task("LinqBegin42");
            GetEnumerableString().SelectMany((s, i) => (i+1) % 2 == 1 ? 
                                  s.Select(t => t).Where(k => char.IsUpper(k)) :
                                  s.Select(t => t).Where(k => char.IsLower(k)))
                                  .Put();            
        }
    }

}
