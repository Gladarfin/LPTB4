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
            Task("LinqXml7");
            //LinqXml7∞. ƒаны имена существующего текстового файла и создаваемого XML-документа.
            // ажда€ строка текстового файла содержит несколько(одно или более) целых чисел, 
            //разделенных ровно одним пробелом.—оздать XML-документ с корневым элементом root, 
            //элементами первого уровн€ line и элементами второго уровн€ sum-positive и 
            //number-negative.Ёлементы line соответствуют строкам исходного файла и не 
            //содержат дочерних текстовых узлов, элемент sum-positive €вл€етс€ первым дочерним
            //элементом каждого элемента line и содержит сумму всех положительных чисел из 
            //соответствующей строки, элементы number - negative содержат по одному отрицательному 
            //числу из соответствующей строки(числа располагаютс€ в пор€дке, обратном пор€дку 
            //их следовани€ в исходной строке). 

            var file = File.ReadAllLines(GetString(), Encoding.Default);
            var doc = new XDocument(new XDeclaration(null, "windows-1251", null),
                                    new XElement("root",
                                    file.Select(e => new XElement("line",
                                    new XElement("sum-positive", e.Split(' ')
                                                                              .Select(j => Int32.Parse(j))
                                                                              .Where(jj=> jj>=0).Sum()),
                                    e.Split(' ')
                                     .Reverse()
                                     .Where(n => Int32.Parse(n) < 0)
                                     .Select(nn => new XElement("number-negative", Int32.Parse(nn)))))));
            doc.Save(GetString());          
        }
    }
}
