// File: "LinqXml23"
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
        // При решении задач группы LinqXml доступны следующие
        // дополнительные методы расширения, определенные в задачнике:
        //
        //   Show() и Show(cmt) - отладочная печать последовательности,
        //     cmt - строковый комментарий;
        //
        //   Show(e => r) и Show(cmt, e => r) - отладочная печать
        //     значений r, полученных из элементов e последовательности,
        //     cmt - строковый комментарий.
        //LinqXml23°. Дан XML-документ. Удалить из документа все инструкции обработки.
        //Указание.Для получения последовательности всех инструкций обработки воспользоваться методом OfType<XProcessingInstruction>.
        public static void Solve()
        {
            Task("LinqXml23");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            doc.Root.DescendantNodes().OfType<XProcessingInstruction>().Remove();
            doc.Save(fileName);
        }
    }
}
