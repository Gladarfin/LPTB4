// File: "LinqXml67"
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

        //LinqXml67∞. ƒан XML-документ с информацией о клиентах фитнес-центра. 
        //ќбразец элемента первого уровн€ (смысл данных тот же, что и в LinqXml61):
            //<client id = "10" time="PT5H13M">
            //  <year>2000</year>
            //  <month>5</month>
            //</client>
        //ѕреобразовать документ, сгруппировав данные по годам и мес€цам и изменив элементы первого уровн€ следующим образом:
            //<y2000>
            //  <m1 total-time="0" client-count="0" />
            //  ...
            //  <m5 total-time="956" client-count="3" />
            //  ...
            //</y2000>
        //»м€ элемента первого уровн€ должно иметь префикс y, после которого указываетс€ номер года;
        //им€ элемента второго уровн€ должно иметь префикс m, после которого указываетс€ номер мес€ца.
        //јтрибут total-time должен содержать суммарную продолжительность зан€тий (в минутах) всех клиентов в данном мес€це, 
        //атрибут client-count Ч количество клиентов, занимавшихс€ в этом мес€це. 
        // аждый элемент первого уровн€ должен содержать элементы второго уровн€, соответствующие всем мес€цам года; 
        //если в каком-либо мес€це зан€ти€ не проводились, то атрибуты дл€ этого мес€ца должны иметь нулевые значени€.
        //Ёлементы первого уровн€ должны быть отсортированы по возрастанию номера года, их дочерние элементы Ч по возрастанию 
        //номера мес€ца.

        //”казание.ƒл€ эффективного формировани€ последовательностей, св€занных со всеми мес€цами, 
        //использовать вспомогательную последовательность Enumerable.Range(1, 12) и метод GroupJoin.
        public static void Solve()
        {
            Task("LinqXml67");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var months = Enumerable.Range(1, 12);
            var data = doc.Root.Descendants(ns + "client").Select(e => 
                new
                {
                    year = int.Parse(e.Element(ns + "year").Value),
                    month = int.Parse(e.Element(ns + "month").Value),
                    time = ((TimeSpan)e.Attribute("time")).TotalMinutes
                });
            doc.Root.ReplaceNodes(data.OrderBy(y => y.year)
                                      .GroupBy(y => y.year,
                                               (e, el) => new XElement(ns + ("y" + e),
                                                           months.GroupJoin(el, e1 => e1, e2 => e2.month,
                                                                            (e1, ee2) => new XElement(ns + ("m" + e1),
                                                                                          new XAttribute("total-time", ee2.Sum(e3 => e3.time)),
                                                                                             new XAttribute("client-count", ee2.Count()))))));

            doc.Save(fileName);
        }
    }
}
