// File: "LinqXml80"
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

        //LinqXml80°. Дан XML-документ с информацией о задолженности по оплате коммунальных услуг. 
        //Образец элемента первого уровня (смысл данных тот же, что и в LinqXml76, 
        //данные сгруппированы по номерам домов; в качестве элементов второго уровня указываются фамилии и инициалы жильцов,
        //фамилия отделяется от инициалов символом подчеркивания):
            //<house number = "12" >
            //  < Иванов_А.В.>
            //    < flat value="23" />
            //    <debt value = "1245.64" />
            //  </ Иванов_А.В.>
            //  ...
            //</house>
        //Преобразовать документ, сохранив группировку данных по номеру дома, выполнив в пределах каждого дома группировку 
        //по номеру подъезда и изменив элементы первого уровня следующим образом:
            //<house12>
            //  <entrance1 total-debt="2493.38" count="3">
            //    <flat23 name = "Иванов А.В." />
            //    ...
            //  </entrance1>
            //  ...
            //</house12>
        //Имя элемента первого уровня должно иметь префикс house, после которого указывается номер дома, 
        //имя элемента второго уровня должно иметь префикс entrance, после которого указывается номер подъезда, 
        //имя элемента третьего уровня должно иметь префикс flat, после которого указывается номер квартиры.
        //Атрибут total-debt равен суммарной задолженности жильцов данного подъезда (значение задолженности 
        //должно округляться до двух дробных знаков, незначащие нули не отображаются), атрибут count равен 
        //количеству задолжников в данном подъезде.Элементы первого уровня должны быть отсортированы по 
        //возрастанию номеров домов, а их дочерние элементы — по возрастанию номеров подъездов.
        //Элементы третьего уровня, имеющие общего родителя, должны быть отсортированы по возрастанию номеров квартир.
        //Подъезды, в которых отсутствуют задолжники, не отображаются. 
        public static void Solve()
        {
            Task("LinqXml80");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Descendants(ns + "flat").Select(el => new { 
                                                                               house = int.Parse(el.Parent.Parent.Attribute("number").Value),
                                                                               flat = int.Parse(el.Attribute("value").Value),
                                                                               entrance = (int.Parse(el.Attribute("value").Value) - 1) / 36 + 1,
                                                                               debt = (double)el.Parent.Element(ns + "debt").Attribute("value"),
                                                                               name = el.Parent.Name.LocalName.Replace("_"," ")
            }).OrderBy(el => el.house)
              .ThenBy(el => el.entrance)
              .ThenBy(el => el.flat);

            doc.Root.ReplaceNodes(
                data.GroupBy(hn => "house" + hn.house,
                     (h, ee) => new XElement(ns + h,
                                    ee.GroupBy(en => "entrance" + en.entrance,
                                              (e, ee2) => new XElement(ns + e,
                                                              new XAttribute("total-debt", Math.Round(ee2.Select(d => d.debt).Sum(),2)),
                                                              new XAttribute("count", ee2.Select(d => d.name).Count()),
                                                              ee2.Select(f => new XElement(ns + ("flat" + f.flat),
                                                                                  new XAttribute("name", f.name))))))));
            doc.Save(fileName);
        }
    }
}
