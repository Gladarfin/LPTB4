// File: "LinqXml14"
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

        public static void Solve()
        {
            //LinqXml14 ƒан XML-документ. Ќайти элементы второго уровн€, 
            //имеющие дочерний текстовый узел, и вывести количество найденных элементов, 
            //а также им€ каждого найденного элемента и значение его дочернего текстового узла. 
            //ѕор€док вывода элементов должен соответствовать пор€дку их следовани€ в документе. 

            Task("LinqXml14");
            var doc = XDocument.Load(GetString());
            var result = doc.Root.Elements().Elements()
                            .Nodes()
                            .OfType<XText>()
                            .Where(e => e.Value != "");
            Put(result.Count());
            foreach(var e in result)
            {
                Put(e.Parent.Name.LocalName, e.Value);
            }

        }
    }
}
