// File: "LinqXml24"
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

        //LinqXml24°. Дан XML-документ. Удалить из документа все комментарии, 
        //являющиеся узлами первого или второго уровня (т. е. имеющие своим 
        //родительским элементом корневой элемент или элемент первого уровня). 
        public static void Solve()
        {
            Task("LinqXml24");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            doc.Root.Nodes().OfType<XComment>().Remove();
            doc.Root.Elements().Nodes().OfType<XComment>().Remove();
            doc.Save(fileName);

        }
    }
}
