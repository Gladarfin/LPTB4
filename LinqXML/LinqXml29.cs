// File: "LinqXml29"
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
        // ѕри решении задач группы LinqXml доступны следующие
        // дополнительные методы расширени€, определенные в задачнике:
        //
        //   Show() и Show(cmt) - отладочна€ печать последовательности,
        //     cmt - строковый комментарий;
        //
        //   Show(e => r) и Show(cmt, e => r) - отладочна€ печать
        //     значений r, полученных из элементов e последовательности,
        //     cmt - строковый комментарий.

        //LinqXml29∞. ƒан XML-документ. ”далить из документа все элементы первого и второго уровн€, не содержащие дочерних узлов. 
        public static void Solve()
        {
            Task("LinqXml29");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            doc.Root.Elements().Elements().Where(e => e.Nodes().Count() == 0).Remove();
            doc.Root.Elements().Where(e => e.Nodes().Count() == 0).Remove();
            doc.Save(fileName);
        }
    }
}
