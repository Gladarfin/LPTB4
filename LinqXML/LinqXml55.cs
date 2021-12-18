// File: "LinqXml55"
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

        //LinqXml55∞. ƒан XML-документ. ѕреобразовать имена всех элементов второго уровн€, 
        //удалив из них пространства имен (дл€ элементов других уровней пространства имен не измен€ть). 

        public static void Solve()
        {
            Task("LinqXml55");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            foreach (var e in doc.Root.Descendants().Where(el => el.Ancestors().Count() == 2))
            {
                e.Attributes("xmlns").Remove();
                e.Name = e.Name.LocalName;     
            }

            doc.Save(fileName);

        }
    }
}
