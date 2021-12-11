// File: "LinqXml16"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace PT4Tasks
{
    public class MyTask : PT
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

        //LinqXml16°. Дан XML-документ, содержащий хотя бы один элемент первого уровня. 
        //Для каждого элемента первого уровня найти суммарное количество атрибутов у его элементов-потомков второго уровня 
        //(т. е. элементов, являющихся дочерними элементами его дочерних элементов) и вывести найденное количество атрибутов и имя элемента. 
        //Элементы выводить в порядке убывания найденного количества атрибутов, а при совпадении количества атрибутов — в алфавитном порядке имен. 

        public static void Solve()
        {
            Task("LinqXml16");
            var doc = XDocument.Load(GetString());
            var result = doc.Root.Elements()
                            .Select(elem => new
                            {
                                attrCount = elem.Elements().Descendants().Attributes().Count(),
                                elemName = elem.Name.LocalName
                            }).OrderByDescending(e => e.attrCount).ThenBy(e => e.elemName);

            foreach (var e in result)
            {
                Put(e.attrCount, e.elemName);
            }
        }
    }
}
