// File: "LinqXml66"
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

        //LinqXml66∞. ƒан XML-документ с информацией о клиентах фитнес-центра. 
        //ќбразец элемента первого уровн€ (смысл данных тот же, что и в LinqXml61, данные сгруппированы по кодам клиентов):
            //<client id = "10" >
            //  < info date="2000-05-01T00:00:00" time="PT5H13M" />
            //  ...
            //</client>
        //ѕреобразовать документ, сгруппировав данные по годам и мес€цам и оставив сведени€ только о тех мес€цах, 
        //в которых посещали зан€ти€ не менее трех клиентов.»зменить элементы первого уровн€ следующим образом:
        //<d2000-5 total-time="956" client-count="3">
        //  <id10 time = "313" />
        //  ...
        //</d2000-5>
        //»м€ элемента первого уровн€ должно иметь префикс d, после которого указываетс€ номер года и, через дефис, 
        //номер мес€ца(незначащие нули не отображаютс€). »м€ элемента второго уровн€ должно иметь префикс id, 
        //после которого указываетс€ код клиента.јтрибут total-time должен содержать суммарную продолжительность зан€тий (в минутах)
        //всех клиентов в данном мес€це, атрибут client-count Ч количество клиентов, занимавшихс€ в этом мес€це. 
        //јтрибут time дл€ элементов второго уровн€ должен содержать продолжительность зан€тий (в минутах) клиента с указанным кодом
        //в данном мес€це. Ёлементы первого уровн€ должны быть отсортированы по возрастанию номера года, а дл€ одинаковых номеров года
        //Ч по возрастанию номера мес€ца; их дочерние элементы должны быть отсортированы по возрастанию кодов клиентов.

        public static void Solve()
        {
            Task("LinqXml66");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Descendants(ns + "info")
                                          .OrderBy(el => ((DateTime)el.Attribute("date")).Year)
                                          .ThenBy(el => ((DateTime)el.Attribute("date")).Month)
                                          .GroupBy(ym => ("d" + ((DateTime)ym.Attribute("date")).Year + "-" + ((DateTime)ym.Attribute("date")).Month))
                                          .Where(ge => ge.Count() > 2)
                                          .Select(e => new XElement(ns + e.Key,
                                                                    new XAttribute("total-time",
                                                                                   e.Select(tt => ((TimeSpan)tt.Attribute("time")).TotalMinutes)
                                                                                    .Sum()),
                                                                    new XAttribute("client-count",
                                                                                   e.Where(cc => int.Parse(e.Key.Substring(6)) == ((DateTime)cc.Attribute("date")).Month)
                                                                                    .Select(cl => cl.Parent.Attribute("id"))
                                                                                    .Count()),
                                                                    e.OrderBy(id => int.Parse(id.Parent.Attribute("id").Value))
                                                                     .Select(id => new XElement(ns + "id" + id.Parent.Attribute("id").Value,
                                                                                                new XAttribute("time", ((TimeSpan)id.Attribute("time")).TotalMinutes)))
                                                                     )));
            doc.Save(fileName);

        }
    }
}
