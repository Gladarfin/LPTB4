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
            //LinqBegin14°. Даны целые числа A и B(A<B). Используя методы Range и Average, найти среднее арифметическое квадратов всех 
            //целых чисел от A до B включительно: (A2 + (A + 1)2 + … +B2)/ (B − A + 1) (как вещественное число). 

            Task("LinqBegin14");
            int a = GetInt();
            int b = GetInt();
            Put(Enumerable.Range(a, b - a + 1).Average(x => x * x));           
        }
    }

}
