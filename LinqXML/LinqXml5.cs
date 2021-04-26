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

        //LinqXml5∞. ƒаны имена существующего текстового файла и создаваемого XML-документа.
        // ажда€ строка текстового файла содержит несколько(одно или более) слов, 
        //разделенных ровно одним пробелом.—оздать XML-документ с корневым элементом root, 
        //элементами первого уровн€ line и элементами второго уровн€ word.
        //Ёлементы line соответствуют строкам исходного файла и не содержат дочерних текстовых узлов, 
        //элементы word каждого элемента line содержат по одному слову из соответствующей строки 
        //(слова располагаютс€ в пор€дке их следовани€ в исходной строке). Ёлемент line должен 
        //содержать атрибут num, равный пор€дковому номеру строки в исходном файле, элемент word 
        //должен содержать атрибут num, равный пор€дковому номеру слова в строке.

        public static void Solve()
        {
            Task("LinqXml5");
            var file = File.ReadAllLines(GetString(), Encoding.Default);
            var doc = new XDocument(new XDeclaration(null, "windows-1251", null),
                new XElement("root", 
                file.Select((e,i) => new XElement("line", new XAttribute("num",++i),
                    e.Split(' ')
                     .Select((w,j) => new XElement("word",new XAttribute("num",++j),w))))));
            doc.Save(GetString());
        }
    }
}
