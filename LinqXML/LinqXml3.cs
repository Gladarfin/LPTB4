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
        // При решении задач группы LinqXml доступны следующие
        // дополнительные методы расширения, определенные в задачнике:
        //
        //   Show() и Show(cmt) - отладочная печать последовательности,
        //     cmt - строковый комментарий;
        //
        //   Show(e => r) и Show(cmt, e => r) - отладочная печать
        //     значений r, полученных из элементов e последовательности,
        //     cmt - строковый комментарий.

        public static void Solve()
        {
            Task("LinqXml3");
            //LinqXml3°. Даны имена существующего текстового файла и создаваемого XML-документа.
            //Создать XML - документ с корневым элементом root и элементами первого уровня line, 
            //каждый из которых содержит одну строку из исходного файла.
            //Элемент, содержащий строку с порядковым номером N(1, 2, …), должен иметь атрибут num 
            //со значением, равным N.
            var file = File.ReadAllLines(GetString(), Encoding.Default);
            var doc = new XDocument(
                new XDeclaration(null, "windows-1251", null),
                new XElement("root",
                file.Select((e, i) => new XElement("line", new XAttribute("num", ++i), e))));
            doc.Save(GetString());

        }
    }
}
