// File: "LinqXml46"
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

        //LinqXml46°. Дан XML-документ. Для каждого элемента, имеющего дочерние элементы, 
        //добавить в конец его набора атрибутов атрибут с именем odd-node-count и логическим значением, 
        //равным true, если суммарное количество дочерних узлов у всех его дочерних элементов является нечетным,
        //и false в противном случае. 
        public static void Solve()
        {
            Task("LinqXml46");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);

            foreach (var e in doc.Descendants().Where(el => el.Descendants().Count() > 0))
            {
                e.Add(new XAttribute("odd-node-count", e.Elements()
                                                        .Nodes()
                                                        .Count() % 2 != 0));
            }

            doc.Save(fileName);
        }
    }
}
