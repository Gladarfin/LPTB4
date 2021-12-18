// File: "LinqXml57"
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

        //LinqXml57°. Дан XML-документ и строки S1 и S2, содержащие различные пространства имен.
        //Удалить в документе определения исходных пространств имен и определить в корневом элементе 
        //два префикса пространств имен: префикс x, связанный с S1, и префикс y, связанный с S2. 
        //Снабдить префиксом x элементы нулевого и первого уровня, а префиксом y — элементы последующих уровней. 
        public static void Solve()
        {
            Task("LinqXml57");
            string fileName = GetString();
            string s1 = GetString();
            string s2 = GetString();
            var doc = XDocument.Load(fileName);
            doc.Root.Add(new XAttribute(XNamespace.Xmlns + "x", s1),
                         new XAttribute(XNamespace.Xmlns + "y", s2));
            foreach (var e in doc.Descendants())
            {
                XNamespace newNamespace = e.Ancestors().Count() <= 1 ? s1 : s2;
                e.Name = newNamespace + e.Name.LocalName;
            }
            doc.Descendants().Attributes("xmlns").Remove();
            doc.Save(fileName);

        }
    }
}
