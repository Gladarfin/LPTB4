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
            //LinqBegin4°. Дан символ С и строковая последовательность A.Если A содержит единственный элемент, 
            //оканчивающийся символом C, то вывести этот элемент; если требуемых строк в A нет, то вывести пустую строку; 
            //если требуемых строк больше одной, то вывести строку «Error».
            //Указание.Использовать try-блок для перехвата возможного исключения. 

            Task("LinqBegin4");
            char c = GetChar();
            var a = GetEnumerableString();
            try
            {
                Put(a.SingleOrDefault(s => s.Length != 0 && s[s.Length - 1] == c) ?? "");
            }
            catch
            {
                Put("Error");
            }
        }
    }

}
