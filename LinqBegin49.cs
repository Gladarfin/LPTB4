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
            //LinqBegin49°. Даны строковые последовательности A, B и С; все строки в каждой последовательности различны, 
            //имеют ненулевую длину и содержат только цифры и заглавные буквы латинского алфавита.
            //Найти внутреннее объединение A, B и С(см.LinqBegin46), каждая тройка которого должна содержать строки, начинающиеся с одного и того же
            //символа. Представить найденное объединение в виде последовательности строк вида «EA = EB = EC», где EA, EB, EC — элементы из A, B, C 
            //соответственно. Для различных элементов EA сохраняется исходный порядок их следования, для равных элементов EA порядок троек 
            //определяется лексикографическим порядком элементов EB(по возрастанию), 
            //а для равных элементов EA и EB — лексикографическим порядком элементов EC(по убыванию). 

            Task("LinqBegin49");
            var a = GetEnumerableString();
            var b = GetEnumerableString().OrderBy(e => e);
            var c = GetEnumerableString().OrderByDescending(e => e);

            a.Join(b
                    .Join(c,
                          x => x[0],
                          y => y[0],
                         (x, y) => string.Format("{0}={1}", x, y)),
                   f => f[0],
                   g => g[0],
                   (f, g) => string.Format("{0}={1}", f, g)).Put();            
        }
    }

}
