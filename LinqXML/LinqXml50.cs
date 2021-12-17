// File: "LinqXml50"
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

        //LinqXml50∞. ƒан XML-документ. — каждым элементом документа св€зываетс€ некоторый промежуток времени 
        //(в дн€х, часах, минутах и секундах). Ётот промежуток либо €вно указываетс€ в атрибуте time данного элемента 
        //(в формате, прин€том в стандарте XML), либо, если данный атрибут отсутствует, считаетс€ равным одному дню. 
        //ƒобавить в начало набора дочерних узлов корневого элемента элемент total-time со значением, равным суммарному 
        //значению промежутков времени, св€занных со всеми элементами первого уровн€.

        //”казание.»спользовать приведение объекта XAttribute к Nullable-типу TimeSpan? и операцию ?? €зыка C#
        //(бинарную операцию If €зыка VB.NET). 
        public static void Solve()
        {
            Task("LinqXml50");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            doc.Root.AddFirst(new XElement("total-time", doc.Root.Elements().Select(e => (TimeSpan?)e.Attribute("time") ?? 
                                                                                          new TimeSpan(24, 0, 0))
                                                                            .Aggregate(TimeSpan.Zero, (a, e) => a + e)));
            doc.Save(fileName);
        }
    }
}
