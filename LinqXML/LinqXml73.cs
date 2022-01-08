// File: "LinqXml73"
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

        //LinqXml73°. Дан XML-документ с информацией о ценах автозаправочных станций на бензин. 
        //Образец элемента первого уровня (смысл данных тот же, что и в LinqXml68, данные сгруппированы по названиям улиц; 
        //названия улиц указываются в качестве имен элементов первого уровня):
            //<ул.Чехова>
            //  <company name = "Лидер" >
            //    < brand > 92 </ brand >
            //    < price > 2200 </ price >
            //  </ company >
            //  ...
            //</ул.Чехова>
        //Преобразовать документ, сгруппировав данные по названиям компаний и названиям улиц и оставив сведения только о тех АЗС,
        //на которых предлагаются не менее двух марок бензина.Изменить элементы первого уровня следующим образом:
            //<Лидер_ул.Чехова brand-count="2">
            //  <b92 price = "2200" />
            //  < b95 price="2450" />
            //</Лидер_ул.Чехова>
        //Имя элемента первого уровня содержит название компании, после которого следует символ подчеркивания и название улицы; 
        //имя элемента второго уровня должно иметь префикс b, после которого указывается марка бензина.Атрибут brand-count должен
        //содержать количество марок бензина, предлагаемых на данной АЗС. Элементы первого уровня должны быть отсортированы в алфавитном
        //порядке названий компаний, а для одинаковых названий компаний — в алфавитном порядке названий улиц; их дочерние элементы должны
        //быть отсортированы по возрастанию марок бензина.

        public static void Solve()
        {
            Task("LinqXml73");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Descendants(ns + "company")
                                          .OrderBy(el => el.Attribute("name").Value)
                                          .ThenBy(el => el.Parent.Name.LocalName)
                                          .GroupBy(cs => (cs.Attribute("name").Value + "_" + cs.Parent.Name.LocalName))
                                          .Where(gc => gc.Count() > 1)
                                          .Select(el => new XElement(ns + el.Key,
                                                            new XAttribute("brand-count", el.Count()),
                                                            el.Select(b => new XElement(ns + ("b" + b.Element(ns + "brand").Value),
                                                                               new XAttribute("price", b.Element(ns + "price").Value)))
                                                              .OrderBy(pr => pr.Attribute("price").Value))));

            doc.Save(fileName);

        }
    }
}
