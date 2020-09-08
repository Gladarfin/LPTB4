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
            //LinqBegin41°. Дано целое число K(> 0) и строковая последовательность A. 
            //Каждый элемент последовательности представляет собой несколько слов из заглавных латинских букв, разделенных символами «.» (точка).
            //Получить последовательность строк, содержащую все слова длины K из элементов A в лексикографическом порядке по возрастанию(слова могут повторяться). 

            Task("LinqBegin41");
            int k = GetInt();
            GetEnumerableString().SelectMany(n => n.Split('.')).Where(s => s.Length == k).OrderBy(s => s).Put();            
        }
    }

}
