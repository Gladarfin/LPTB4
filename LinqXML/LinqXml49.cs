// File: "LinqXml49"
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
        // ѕри решении задач группы LinqXml доступны следующие
        // дополнительные методы расширени€, определенные в задачнике:
        //
        //   Show() и Show(cmt) - отладочна€ печать последовательности,
        //     cmt - строковый комментарий;
        //
        //   Show(e => r) и Show(cmt, e => r) - отладочна€ печать
        //     значений r, полученных из элементов e последовательности,
        //     cmt - строковый комментарий.

        //LinqXml49∞. ƒан XML-документ и строка S. ¬ строке записано им€ одного из атрибутов исходного документа;
        //известно, что все атрибуты с указанным именем содержат представление некоторого промежутка времени 
        //(в дн€х, часах, минутах и секундах) в формате, прин€том в стандарте XML. ƒобавить в корневой элемент 
        //атрибут total-time, равный суммарному значению промежутков времени, указанных во всех атрибутах S исходного документа.

        //”казание.»спользовать приведение объекта XAttribute к типу TimeSpan.ƒл€ суммировани€ полученных промежутков времени 
        //использовать метод Aggregate и операцию Ђ+ї дл€ типа TimeSpan.
        public static void Solve()
        {
            Task("LinqXml49");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            string s = GetString();
            doc.Root.Add(new XAttribute("total-time", doc.Descendants().Attributes(s)
                                                                       .Select(e => (TimeSpan)e)
                                                                       .Aggregate(TimeSpan.Zero, (a, e) => a + e)));
            doc.Save(fileName);
        }
    }
}
