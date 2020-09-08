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
            //LinqBegin52°. Даны строковые последовательности A и B; все строки в каждой последовательности различны, имеют ненулевую 
            //длину и содержат только цифры и заглавные буквы латинского алфавита.Получить последовательность всевозможных комбинаций 
            //вида «EA = EB», где EA — некоторый элемент из A, EB — некоторый элемент из B, причем оба элемента оканчиваются цифрой
            //(например, «AF3= D78»). Упорядочить полученную последовательность в лексикографическом порядке по возрастанию элементов EA,
            //а при одинаковых элементах EA — в лексикографическом порядке по убыванию элементов EB.
            //Указание.Для перебора комбинаций использовать методы SelectMany и Select. 

            Task("LinqBegin52");
            var a = GetEnumerableString().Where(e => char.IsDigit(e[e.Length-1])).OrderBy(e=>e);
            var b = GetEnumerableString().Where(e => char.IsDigit(e[e.Length-1])).OrderByDescending(e => e);
            a.SelectMany(e => b.Select(g => e + '='+g)).Put();            
        }
    }

}
