using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace PT4Tasks
{
    public class MyTask: PT
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
            Task("LinqXml2");
            //LinqXml2∞. ƒаны имена существующего текстового файла и создаваемого XML-документа.
            //—оздать XML - документ с корневым элементом root и элементами первого уровн€, 
            //каждый из которых содержит одну строку из исходного файла и имеет им€ line с 
            //приписанным к нему пор€дковым номером строки(line1, line2 и т.д.).
            var file = File.ReadAllLines(GetString(), Encoding.Default);
            var doc = new XDocument(
                new XDeclaration(null, "windows-1251", null),
                new XElement("root",
                file.Select((e, index) => new XElement("line" + (++index).ToString(), e))));           
            doc.Save(GetString());
        }
    }
}
