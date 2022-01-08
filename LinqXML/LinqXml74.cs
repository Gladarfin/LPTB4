// File: "LinqXml74"
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

        //LinqXml74°. Дан XML-документ с информацией о ценах автозаправочных станций на бензин. 
        //Образец элемента первого уровня (смысл данных тот же, что и в LinqXml68, марки бензина, 
        //снабженные префиксом brand, указываются в качестве имен элементов первого уровня; 
        //атрибут station содержит названия улицы и компании, разделенные символом подчеркивания):
            //<brand92 station = "ул.Чехова_Лидер" price="2200" />
        //Преобразовать документ, сгруппировав данные по названиям компаний и изменив элементы первого уровня следующим образом:
            //<Лидер>
            //  <ул.Садовая brand92 = "0" brand95="0" brand98="0" />
            //  <ул.Чехова brand92 = "2200" brand95="2450" brand98="0" />
            //  ...
            //</Лидер>
        //Имя элемента первого уровня совпадает с названием компании, имя элемента второго уровня совпадает с названием улицы.
        //Атрибуты элементов второго уровня имеют префикс brand, после которого указывается марка бензина; их значением является
        //цена 1 литра бензина указанной марки или число 0, если на данной АЗС бензин указанной марки не предлагается.
        //Для каждой компании должна выводиться информация по каждой улице, имеющейся в исходном документе, 
        //даже если на этой улице отсутствует АЗС данной компании (в этом случае значения всех атрибутов brand должны быть равны 0). 
        //Элементы первого уровня должны быть отсортированы в алфавитном порядке названий компаний,
        //а их дочерние элементы — в алфавитном порядке названий улиц.

        public static void Solve()
        {
            Task("LinqXml74");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Descendants(ns + "company")
                               .Select(el => { string[] s = el.Attribute("station").Value.Split('_');
                                                 return new
                                                 {
                                                     company = s[1],
                                                     street = s[0],
                                                     brand = el.Parent.Name.LocalName,
                                                     price = int.Parse(el.Attribute("price").Value)
                                                 };
                                             }).OrderBy(el => el.company);
            var brands = new string[] { "brand92", "brand95", "brand98"};
            var streets = doc.Root.Descendants(ns + "company").Select(el => el.Attribute("station").Value.Split('_')[0]).Distinct().OrderBy(e => e);
            doc.Root.ReplaceNodes(data.GroupBy(cn => cn.company,
                                               (c, el) => new XElement(ns + c,
                                               streets.GroupJoin(el, e1 => e1, e2 => e2.street,
                                               (e1, ee2) => new XElement(ns + e1,
                                                                         brands.GroupJoin(ee2, ee1 => ee1, e2 => e2.brand,
                                                                         (ee1, e3) => new XAttribute(ee1, e3.Select(l => l.price).Sum())))))));
            doc.Save(fileName);
        }
    }
}
