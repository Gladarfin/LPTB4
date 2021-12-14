// File: "LinqXml27"
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

        //LinqXml27∞. ƒан XML-документ. ƒл€ всех элементов второго уровн€ удалить все их дочерние узлы, кроме последнего. 
        public static void Solve()
        {
            Task("LinqXml27");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            doc.Root.Elements().Elements().Nodes().Where(e => e.NextNode != null).Remove();
            doc.Save(fileName);
        }
    }
}
