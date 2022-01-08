// File: "LinqXml63"
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

        //LinqXml63∞. ƒан XML-документ с информацией о клиентах фитнес-центра. 
        //ќбразец элемента первого уровн€ (смысл данных тот же, что и в LinqXml61):
            //<record date = "2000-05-01T00:00:00" id="10" time="PT5H13M" />
        //ѕреобразовать документ, выполнив группировку данных по кодам клиентов и изменив элементы первого уровн€ следующим образом:
            //<client id = "10" >
            //  < time year="2000" month="5">PT5H13M</time>
            //   ...
            //</client>
        //Ёлементы первого уровн€ должны быть отсортированы по возрастанию кода клиента, 
        //их дочерние элементы Ч по возрастанию номера года, а дл€ одинаковых значений года Ч по возрастанию номера мес€ца.
        public static void Solve()
        {
            Task("LinqXml63");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Elements().GroupBy(el => el.Attribute("id").Value).Select(
                                                              elem => new XElement(ns + "client",
                                                                     new XAttribute("id", elem.Key),
                                                                     elem.Select(el =>
                                                                     new XElement(ns + "time",
                                                                                  new XAttribute("year", ((DateTime)el.Attribute("date")).Year),
                                                                                  new XAttribute("month", ((DateTime)el.Attribute("date")).Month),
                                                                                  el.Attribute("time").Value))
                                                                                  .OrderBy(elemYear => int.Parse(elemYear.Attribute("year").Value))
                                                                                  .ThenBy(elemMonth => int.Parse(elemMonth.Attribute("month").Value))))
                                                     .OrderBy(elemId => int.Parse(elemId.Attribute("id").Value)));
            doc.Save(fileName);
        }
    }
}
