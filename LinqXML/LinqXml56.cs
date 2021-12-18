// File: "LinqXml56"
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

        //LinqXml56°. Дан XML-документ. В корневом элементе документа определен единственный префикс пространства имен. 
        //Снабдить данным префиксом имена всех элементов первого уровня и удалить из этих элементов определения исходных
        //пространств имен (если такие определения имеются). 
        public static void Solve()
        {
            Task("LinqXml56");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Attributes().Last();
            foreach (var e in doc.Root.Elements())
            {
                e.Attributes("xmlns").Remove();
                e.Name = (XNamespace)ns.Value + e.Name.LocalName;
            }
            doc.Save(fileName);

        }
    }
}
