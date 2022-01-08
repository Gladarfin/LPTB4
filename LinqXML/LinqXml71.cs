// File: "LinqXml71"
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

        //LinqXml71°. Дан XML-документ с информацией о ценах автозаправочных станций на бензин. 
        //Образец элемента первого уровня (смысл данных тот же, что и в LinqXml68):
              //<station street = "ул.Авиаторов" company="Лидер">
              //  <info brand = "98" price="2850" />
              //</station>
        //Преобразовать документ, выполнив группировку данных по маркам бензина, 
        //а в пределах каждой марки — по ценам 1 литра бензина.Изменить элементы первого уровня следующим образом:
            //<b98>
            //  <p2850>
            //    <info street = "ул.Авиаторов" company= "Лидер" />
            //    ...
            //  </p2850>
            //  ...
            //</b98>
        //Имя элемента первого уровня должно иметь префикс b, после которого указывается марка бензина;
        //имя элемента второго уровня должно иметь префикс p, после которого указывается цена 1 литра бензина.
        //Элементы первого уровня должны быть отсортированы по убыванию марок бензина, а их дочерние элементы — по убыванию цен.
        //Элементы третьего уровня, имеющие общего родителя, должны быть отсортированы в алфавитном порядке названий улиц,
        //а для одинаковых улиц — в алфавитном порядке названий компаний.
        public static void Solve()
        {
            Task("LinqXml71");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            //вспомогательная выборка данных + сортировка по всем критериям
            var data = doc.Root.Elements().Select(e => new
            {
                brand = int.Parse(e.Element(ns + "info").Attribute("brand").Value),
                price = int.Parse(e.Element(ns + "info").Attribute("price").Value),
                street = e.Attribute("street").Value,
                company = e.Attribute("company").Value
            }).OrderByDescending(e => e.brand)
              .ThenByDescending(e => e.price)
              .ThenBy(e => e.street)
              .ThenBy(e => e.company);

            doc.Root.ReplaceNodes(data.GroupBy(b => b.brand,
                                               (br, e) => new XElement(ns + ("b" + br),
                                                           e.GroupBy(p => p.price)
                                                            .Select(pr => new XElement(ns + ("p" + pr.Key),
                                                                          pr.Select(sc => new XElement(ns + "info",
                                                                                           new XAttribute("street",sc.street),
                                                                                           new XAttribute("company", sc.company))))))));
                                                                          
            doc.Save(fileName);
        }
    }
}
