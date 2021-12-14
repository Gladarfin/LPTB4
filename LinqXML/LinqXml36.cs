// File: "LinqXml36"
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

        //LinqXml36°. Дан XML-документ.
        //Для каждого элемента второго уровня, имеющего потомков, добавить в конец списка его атрибутов 
        //атрибут node-count со значением, равным количеству узлов-потомков этого элемента(всех уровней). 
        public static void Solve()
        {
            Task("LinqXml36");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            foreach (var e in doc.Root.Elements().Elements().Where(el => el.DescendantNodes().Count() > 0))
            {
                e.Add(new XAttribute("node-count", e.DescendantNodes().Count()));
            }
            doc.Save(fileName);
        }
    }
}
