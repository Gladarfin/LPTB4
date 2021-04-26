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
            Task("LinqXml10");
            //LinqXml10°. Даны имена существующего текстового файла и создаваемого XML-документа.
            //Создать XML - документ с корневым элементом root, элементами первого уровня line и 
            //инструкциями обработки(инструкции обработки являются дочерними узлами корневого элемента).
            //Если строка текстового файла начинается с текста «data:», то она(без текста «data:») 
            //добавляется в XML - документ в качестве данных к очередной инструкции обработки с именем 
            //instr, в противном случае строка добавляется в качестве дочернего текстового узла в 
            //очередной элемент line.

            var file = File.ReadAllLines(GetString(), Encoding.Default);
            var doc = new XDocument(new XDeclaration(null, "windows-1251", null),
                                    new XElement("root",
                                    file.Select(e => e.StartsWith("data:") ?
                                                     new XProcessingInstruction("instr", e.Substring(5)) :
                                                     new XElement("line", e) as XNode)));
            doc.Save(GetString());
        }
    }
}
