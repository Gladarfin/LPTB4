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
            //LinqBegin35°. Дана целочисленная последовательность.Получить последовательность чисел, 
            //каждый элемент которой равен произведению соответствующего элемента исходной последовательности на его порядковый номер(1, 2, …).
            //В полученной последовательности удалить все элементы, не являющиеся двузначными, и поменять порядок оставшихся элементов на обратный.

            Task("LinqBegin35");
            int i = 1;
            GetEnumerableInt().Select(n => n*(i++)).Where(n => Math.Abs(n) >= 10 && Math.Abs(n)<=99).Reverse().Put();           
        }
    }

}
