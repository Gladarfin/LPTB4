using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        // При решении задач группы LinqXml доступны следующие
        // дополнительные методы расширения, определенные в задачнике:
        //
        //   Show() и Show(cmt) - отладочная печать последовательности,
        //     cmt - строковый комментарий;
        //
        //   Show(e => r) и Show(cmt, e => r) - отладочная печать
        //     значений r, полученных из элементов e последовательности,
        //     cmt - строковый комментарий.

        public static void Solve()
        {
            Task("LinqXml11");
            //LinqXml11°. Дан XML-документ.Найти все различные имена его элементов и вывести каждое 
            //найденное имя вместе с числом его вхождений в документ.Имена элементов выводить
            //в порядке их первого вхождения.
            //Указание.Использовать метод GroupBy.

            var doc = XDocument.Load(GetString());
            var result = doc.Descendants()
                            .GroupBy(e => e.Name.LocalName)
                            .Select(j => new { elemName = j.Key, count = j.Count() });
            foreach (var elem in result)
                Put(elem.elemName, elem.count);                   
        }
    }
}
