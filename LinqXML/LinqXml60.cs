// File: "LinqXml60"
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

        //LinqXml60°. Дан XML-документ, корневой элемент которого содержит определения двух префиксов пространств имен с именами x и y. 
        //Эти префиксы используются далее в именах некоторых элементов (у атрибутов префиксы отсутствуют). 
        //Удалить определение префикса y и для всех элементов, снабженных этим префиксом, заменить его на префикс x, 
        //а для всех элементов, снабженных префиксом x, заменить его на префикс xml пространства имен XML. 
        public static void Solve()
        {
            Task("LinqXml60");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var x = doc.Root.Attributes().Last().PreviousAttribute;
            var y = doc.Root.Attributes().Last();
            doc.Root.Attributes().Last().Remove();
            foreach (var e in doc.Root.Descendants().Where(el => el.Name.Namespace == y.Value || el.Name.Namespace == x.Value))
            {
                    e.Name = e.Name.Namespace == y.Value ? 
                                                          (XNamespace)x.Value + e.Name.LocalName : 
                                                           XNamespace.Xml + e.Name.LocalName;
            }

            doc.Save(fileName);
        }
    }
}
