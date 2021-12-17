// File: "LinqXml48"
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

        //LinqXml48°. Дан XML-документ. Для каждого элемента, имеющего не менее двух дочерних узлов, 
        //добавить дочерний элемент с именем has-instructions и логическим значением, равным true, 
        //если данный элемент содержит в числе своих дочерних узлов одну или более инструкций обработки, 
        //и false в противном случае. Новый элемент добавить перед последним имеющимся дочерним узлом. 
        public static void Solve()
        {
            Task("LinqXml48");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);

            foreach (var e in doc.Descendants().Where(desc => desc.Nodes().Count() > 1))
            {
                e.LastNode.AddBeforeSelf(new XElement("has-instructions", e.Nodes()
                                                                           .OfType<XProcessingInstruction>()
                                                                           .Count() > 0));
            }
            doc.Save(fileName);
        }
    }
}
