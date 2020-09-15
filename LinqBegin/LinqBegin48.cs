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
            //LinqBegin48°. Даны строковые последовательности A и B; все строки в каждой последовательности различны, имеют ненулевую длину и 
            //содержат только цифры и заглавные буквы латинского алфавита.Найти внутреннее объединение A и B(см.LinqBegin46), каждая пара которого 
            //должна содержать строки одинаковой длины. Представить найденное объединение в виде последовательности строк, содержащих первый и 
            //второй элементы пары, разделенные двоеточием, например, «AB: CD». Порядок следования пар должен определяться лексикографическим 
            //порядком первых элементов пар(по возрастанию), а для равных первых элементов — лексикографическим порядком вторых элементов пар(по убыванию).

            Task("LinqBegin48");
            var a = GetEnumerableString().OrderBy(e => e);
            var b = GetEnumerableString().OrderByDescending(e => e);
            a.Join(b,
                   x => x.Length-1,
                   y => y.Length-1,
                   (x,y) => string.Format("{0}:{1}",x,y))
             .Put();            
        }
    }

}
