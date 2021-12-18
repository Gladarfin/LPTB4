// File: "LinqXml58"
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

        //LinqXml58°. Дан XML-документ и строка S, содержащая некоторое пространство имен. 
        //Определить в корневом элементе префикс node, связанный с пространством имен, заданным в строке S,
        //и добавить в каждый элемент первого уровня два атрибута: атрибут node:count со значением, 
        //равным количеству потомков-узлов для данного элемента, и атрибут xml:count со значением, 
        //равным количеству потомков-элементов для данного элемента (xml — префикс пространства имен XML).

        //Указание.Использовать свойство Xml класса XNamespace.
        public static void Solve()
        {
            Task("LinqXml58");
            string fileName = GetString();
            string s = GetString();
            var doc = XDocument.Load(fileName);
            doc.Root.Add(new XAttribute(XNamespace.Xmlns + "node", s));
            foreach (var e in doc.Root.Elements())
            {
                e.Add(new XAttribute((XNamespace)s + "count", e.DescendantNodes().Count()),
                      new XAttribute(XNamespace.Xml + "count", e.Descendants().Count()));
            }
            doc.Save(fileName);
        }
    }
}
