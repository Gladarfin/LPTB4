// File: "LinqXml40"
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

        //LinqXml40°. Дан XML-документ. Изменить имена атрибутов всех элементов, 
        //добавив слева к исходному имени атрибута имя содержащего его элемента, дополненное символом «-» (дефис).
        //Указание.Так как свойство Name класса XAttribute доступно только для чтения, 
        //следует сформировать новую последовательность атрибутов с требуемыми именами и значениями
        //(применяя метод Select к последовательности Attributes), после чего указать ее в качестве параметра метода ReplaceAttributes.
        public static void Solve()
        {
            Task("LinqXml40");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);

            foreach (var e in doc.Descendants())
            {
                e.ReplaceAttributes(e.Attributes()
                                     .Select(attr => new XAttribute(e.Name.LocalName + "-" + attr.Name.LocalName, 
                                                                    attr.Value)));
            }
            doc.Save(fileName);
        }
    }
}
