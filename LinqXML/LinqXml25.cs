// File: "LinqXml25"
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
        //LinqXml25°. Дан XML-документ. Для всех элементов первого и второго уровня, 
        //имеющих более одного атрибута, удалить все их атрибуты. 
        public static void Solve()
        {
            Task("LinqXml25");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            doc.Root.Elements().Attributes().Where(e => e.Parent.Attributes().Count() > 1).Remove();
            doc.Root.Elements().Elements().Attributes().Where(e => e.Parent.Attributes().Count() > 1).Remove();
            doc.Save(fileName);
        }
    }
}
