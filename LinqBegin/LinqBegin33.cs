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
            //LinqBegin33°. Дана целочисленная последовательность.Обрабатывая только положительные числа, 
            //получить последовательность их последних цифр и удалить в полученной последовательности все вхождения одинаковых цифр, кроме первого. 
            //Порядок полученных цифр должен соответствовать порядку исходных чисел. 

            Task("LinqBegin33");
            GetEnumerableInt().Where(s => s >= 0).Select(n => n % 10).Distinct().Put();            
        }
    }

}
