// File: "LinqXml15"
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

        public static void Solve()
        {
            Task("LinqXml15");
            //LinqXml15 Дан XML-документ, содержащий хотя бы один элемент первого уровня. 
            //Для каждого элемента первого уровня найти количество его потомков, 
            //имеющих не менее двух атрибутов, и вывести имя элемента первого уровня 
            //и найденное количество его потомков. Элементы выводить в алфавитном порядке 
            //их имен, а при совпадении имен — в порядке возрастания найденного количества потомков. 

            var doc = XDocument.Load(GetString());
            var result = doc.Element("root").Elements()
                            .Select(e => new { elemName = e.Name.LocalName,
                                               count = e.Descendants()
                                                        .Where(attr => attr.Attributes().Count() >= 2).Count() })
                            .OrderBy(e => e.elemName)
                            .ThenBy(e => e.count);                          
            
            foreach (var e in result)
            {
                Put(e.elemName, e.count);
            }

        }
    }
}
