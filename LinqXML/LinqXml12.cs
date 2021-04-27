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
            Task("LinqXml12");
            //LinqXml12°. Дан XML-документ, содержащий хотя бы один элемент первого уровня.
            //Найти все различные имена элементов первого уровня и вывести каждое найденное 
            //имя вместе с числом его вхождений в документ в качестве имени элемента первого уровня.
            //Имена элементов выводить в алфавитном порядке. 
            var doc = XDocument.Load(GetString());
            var result = doc.Element("root").Elements()
                                            .GroupBy(e => e.Name.LocalName)
                                            .Select(e => new { elemName = e.Key, count = e.Count() }).OrderBy(elem => elem.elemName);
            foreach (var elem in result)
                Put(elem.elemName, elem.count);
        }
    }
}
