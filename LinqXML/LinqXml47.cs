// File: "LinqXml47"
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

        //LinqXml47°. Дан XML-документ. Для каждого элемента, имеющего хотя бы один дочерний элемент, 
        //добавить дочерний элемент с именем has-comments и логическим значением, равным true,
        //если данный элемент содержит в числе своих узлов-потомков один или более комментариев, 
        //и false в противном случае. Новый элемент добавить после первого имеющегося дочернего элемента. 
        public static void Solve()
        {
            Task("LinqXml47");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);

            foreach (var e in doc.Descendants().Where(el => el.Descendants().Count() > 0))
            {
                e.FirstNode.AddAfterSelf(new XElement("has-comments", e.DescendantNodes()
                                                                        .OfType<XComment>().Count() > 0));
            }
            doc.Save(fileName);
        }
    }
}
