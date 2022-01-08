// File: "LinqXml70"
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

        //LinqXml70°. Дан XML-документ с информацией о ценах автозаправочных станций на бензин. 
        //Образец элемента первого уровня (смысл данных тот же, что и в LinqXml68):
           //<station brand = "98" price="2850">
           //  <company>Лидер</company>
           //  <street>ул.Авиаторов</street>
           //</station>
        //Преобразовать документ, выполнив группировку данных по названиям компаний, 
        //а в пределах каждой компании — по маркам бензина.Изменить элементы первого уровня следующим образом:
            //<company name = "Лидер" >
            //  < brand value="98">
            //    <price street = "ул.Авиаторов" > 2850 </ price >
            //    ...
            //  </brand>
            //  ...
            //</company>
        //Элементы первого уровня должны быть отсортированы в алфавитном порядке названий компаний, 
        //а их дочерние элементы — по убыванию марок бензина.Элементы третьего уровня, имеющие общего родителя, 
        //должны быть отсортированы в алфавитном порядке названий улиц. 
        public static void Solve()
        {
            Task("LinqXml70");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Elements().Select(e => new { 
                                                               name = e.Element(ns + "company").Value,
                                                               brand = int.Parse(e.Attribute("brand").Value),
                                                               street = e.Element(ns + "street").Value,
                                                               price = e.Attribute("price").Value})
                                          .OrderBy(e => e.name).ThenByDescending(e => e.brand).ThenBy(e => e.street).Show();
            doc.Root.ReplaceNodes(data.GroupBy(e => e.name,
                                               (e, c) => new XElement(ns + "company", 
                                                             new XAttribute("name", e),
                                                             c.GroupBy(b => b.brand)
                                                              .Select(br => new XElement(ns + "brand",
                                                                                new XAttribute("value", br.Key),
                                                                                br.Select(el => new XElement(ns + "price",
                                                                                                          new XAttribute("street", el.street),
                                                                                                          el.price)))))));
            doc.Save(fileName);

        }
    }
}
