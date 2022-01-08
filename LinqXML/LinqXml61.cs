// File: "LinqXml61"
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

        //LinqXml61°. Дан XML-документ с информацией о клиентах фитнес-центра. Образец элемента первого уровня:
        //<record>
        //  <id>10</id>
        //  <date>2000-05-01T00:00:00</date>
        //  <time>PT5H13M</time>
        //</record>
        //
        //Здесь id — код клиента(целое число), date — дата с информацией о годе и месяце, 
        //time — продолжительность занятий(в часах и минутах) данного клиента в течение указанного месяца.
        //Преобразовать документ, изменив элементы первого уровня следующим образом:
        //<time id = "10" year= "2000" month= "5" > PT5H13M </ time >
        //
        //Порядок следования элементов первого уровня не изменять. 

        public static void Solve()
        {
            Task("LinqXml61");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Elements().Select(el => new XElement(ns + "time",
                                                                   new XAttribute("id", el.Element(ns + "id").Value),
                                                                   new XAttribute("year", ((DateTime)el.Element(ns + "date")).Year),
                                                                   new XAttribute("month", ((DateTime)el.Element(ns + "date")).Month),
                                                                   el.Element(ns + "time").Value)));
            doc.Save(fileName);
        }
    }
}
