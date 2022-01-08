// File: "LinqXml68"
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

        //LinqXml68°. Дан XML-документ с информацией о ценах автозаправочных станций на бензин. Образец элемента первого уровня:
            //<record>
            //  <company>Лидер</company>
            //  <street>ул.Чехова</street>
            //  <brand>92</brand>
            //  <price>2200</price>
            //</record>
        //Здесь street — название улицы, company — название компании(названия улиц и компаний не содержат пробелов
        //и являются допустимыми именами XML), brand — марка бензина(числа 92, 95 или 98), price — цена 1 литра бензина
        //в копейках(целое число). Каждая компания имеет не более одной АЗС на каждой улице, цены на разных АЗС одной и
        //той же компании могут различаться.Преобразовать документ, изменив элементы первого уровня следующим образом:
            //<station company = "Лидер" street= "ул.Чехова" >
             //< info >
             // < brand > 92 </ brand >
             // < price > 2200 </ price >
             //</ info >
            //</ station >
        //Порядок следования элементов первого уровня не изменять. 
        public static void Solve()
        {
            Task("LinqXml68");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Elements().Select(el => new XElement(ns + "station",
                                                                      new XAttribute("company", el.Element(ns + "company").Value),
                                                                      new XAttribute("street", el.Element(ns + "street").Value),
                                                                      new XElement(ns + "info",
                                                                          new XElement(ns + "brand", el.Element(ns + "brand").Value),
                                                                          new XElement(ns + "price", el.Element(ns + "price").Value)))));
            doc.Save(fileName);
        }
    }
}
