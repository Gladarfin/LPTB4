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
            Task("LinqXml6");
            //LinqXml6∞. ƒаны имена существующего текстового файла и создаваемого XML-документа.
            // ажда€ строка текстового файла содержит несколько(одно или более) целых чисел, 
            //разделенных ровно одним пробелом.—оздать XML-документ с корневым элементом root, 
            //элементами первого уровн€ line и элементами второго уровн€ number. 
            //Ёлементы line соответствуют строкам исходного файла и не содержат дочерних текстовых 
            //узлов, элементы number каждого элемента line содержат по одному числу из соответствующей
            //строки(числа располагаютс€ в пор€дке убывани€).Ёлемент line должен содержать атрибут sum,
            //равный сумме всех чисел из соответствующей строки.
            var file = File.ReadAllLines(GetString(), Encoding.Default);
            var doc = new XDocument(new XDeclaration(null, "windows-1251", null),
                                    new XElement("root", 
                                    file.Select(e => new XElement("line", 
                                                           new XAttribute("sum", e.Split(' ')
                                                                                              .Select(j => Int32.Parse(j)).Sum()),
                                                           e.Split(' ')
                                                            .OrderByDescending(j => Int32.Parse(j))
                                                            .Select(n => new XElement("number",n))))));
            doc.Save(GetString());
            
        }
    }
}
