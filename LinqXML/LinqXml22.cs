// File: "LinqXml22"
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
        //LinqXml22∞. ƒан XML-документ и строка S.
        //¬ строке записано им€ одного из некорневых элементов исходного документа.”далить из документа все элементы с именем S. 
        public static void Solve()
        {
            Task("LinqXml22");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            string s = GetString();
            doc.Root.Descendants(s).Remove();
            doc.Save(fileName);
        }
    }
}
