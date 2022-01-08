// File: "LinqXml64"
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

        //LinqXml64∞. ƒан XML-документ с информацией о клиентах фитнес-центра.
        //ќбразец элемента первого уровн€ (смысл данных тот же, что и в LinqXml61):
            //<client id = "10" >
            //  < date > 2000 - 05 - 01T00:00:00</date>
            //  <time>PT5H13M</time>
            //</client>
            //
        //ѕреобразовать документ, сгруппировав данные по годам, а в пределах каждого года Ч по мес€цам.
        //»зменить элементы первого уровн€ следующим образом:
            //
            //<y2000>
            //  <m5>
            //    <client id = "10" time= "313" />
            //    ...
            //  </m5>
            //  ...
            //</y2000>
        //»м€ элемента первого уровн€ должно иметь префикс y, после которого указываетс€ номер года; 
        //им€ элемента второго уровн€ должно иметь префикс m, после которого указываетс€ номер мес€ца.
        //јтрибут time должен содержать продолжительность зан€тий в минутах.Ёлементы первого уровн€ должны 
        //быть отсортированы по убыванию номера года, их дочерние элементы Ч по возрастанию номера мес€ца. 
        //Ёлементы третьего уровн€, имеющие общего родител€, должны быть отсортированы по возрастанию кодов клиентов.
        public static void Solve()
        {
            Task("LinqXml64");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            //вспомогательна€ последовательность данных 
            var data = doc.Root.Elements().Select(el => new
            {
                year = ((DateTime)el.Element(ns + "date")).Year,
                month = ((DateTime)el.Element(ns + "date")).Month,
                time = ((TimeSpan)el.Element(ns + "time")).TotalMinutes,
                client = el.Attribute("id").Value
            }).OrderByDescending(e => e.year).ThenBy(e => e.month);

            doc.Root.ReplaceNodes(data.GroupBy(el => el.year,
                                               (y,m) => new XElement(ns + ("y" + y),
                                                                     m.GroupBy(e => e.month)
                                                                      .Select(elem => new XElement(ns + ("m" + elem.Key),
                                                                                                   elem.Select(mm =>
                                                                                                   new XElement(ns + "client",
                                                                                                                new XAttribute("id", mm.client),
                                                                                                                new XAttribute("time", mm.time)))
                                                                                                                .OrderBy(id => int.Parse(id.Attribute("id").Value))
                                                                                                  )))));
            doc.Save(fileName);
        }
    }
}
