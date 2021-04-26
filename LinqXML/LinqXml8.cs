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
            Task("LinqXml8");
            //LinqXml8°. Даны имена существующего текстового файла и создаваемого XML-документа.
            //Каждая строка текстового файла содержит несколько(одно или более) слов, разделенных 
            //ровно одним пробелом. Создать XML-документ с корневым элементом root, элементами 
            //первого уровня line, элементами второго уровня word и элементами третьего уровня char.
            //Элементы line и word не содержат дочерних текстовых узлов. Элементы line соответствуют 
            //строкам исходного файла, элементы word каждого элемента line соответствуют словам из 
            //этой строки(слова располагаются в алфавитном порядке), элементы char каждого элемента 
            //word содержат по одному символу из соответствующего слова(символы располагаются в
            //порядке их следования в слове).

            var file = File.ReadAllLines(GetString(), Encoding.Default);
            var doc = new XDocument(new XDeclaration(null, "windows-1251", null),
                                    new XElement("root",
                                           file.Select(e => new XElement("line",
                                           e.Split(' ')
                                            .OrderBy(n => n)
                                            .Select(w => new XElement("word",
                                            w.ToCharArray().Select(l => new XElement("char", l))))))));
            doc.Save(GetString());
        }
    }
}
