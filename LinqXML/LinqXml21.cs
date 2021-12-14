// File: "LinqXml21"
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

        //LinqXml21∞. ƒан XML-документ и строка S.
        //¬ строке записано им€ одного из некорневых элементов исходного документа.
        //”далить из документа все элементы первого уровн€ с именем S. 
        public static void Solve()
        {
            Task("LinqXml21");
            var docName = GetString();
            var doc = XDocument.Load(docName);
            var s = GetString();
            doc.Root.Elements(s).Remove();
            doc.Save(docName);
            
        }
    }
}
