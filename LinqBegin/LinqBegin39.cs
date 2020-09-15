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
            //LinqBegin39°. Дана строковая последовательность A. Получить последовательность цифровых символов, входящих в строки последовательности A(символы могут повторяться). 
            //Порядок символов должен соответствовать порядку строк A и порядку следования символов в каждой строке. 
            //Указание.Использовать метод SelectMany с учетом того, что строка может интерпретироваться как последовательность символов. 

            Task("LinqBegin39");
            GetEnumerableString().SelectMany(n => n.Where(c => char.IsDigit(c))).Put();            
        }
    }

}
