// File: "LinqXml69"
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

        //LinqXml69°. Дан XML-документ с информацией о ценах автозаправочных станций на бензин. 
        //Образец элемента первого уровня (смысл данных тот же, что и в LinqXml68):
            //<station company = "Лидер" >
            //  < info street="ул.Чехова">
            //    <brand>92</brand>
            //    <price>2200</price>
            //  </info>
            //</station>
        //Преобразовать документ, изменив элементы первого уровня следующим образом:
            //<b92 company = "Лидер" street="ул.Чехова" price="2200" />
        //Имя элемента должно иметь префикс b, после которого указывается марка бензина.
        //Элементы представляются комбинированными тегами и должны быть отсортированы по возрастанию марок бензина, 
        //для одинаковых марок — в алфавитном порядке названий компании, а для одинаковых компаний — в алфавитном порядке названий улиц.
        public static void Solve()
        {
            Task("LinqXml69");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Elements().OrderBy(e => e.Descendants(ns + "brand").First().Value)
                                                     .ThenBy(e => e.Attribute("company").Value)
                                                     .ThenBy(e => e.Descendants(ns + "info").First().Attribute("street").Value)
                                     .Select(el => new XElement(ns + ("b" + el.Descendants(ns + "brand").First().Value),
                                                                       new XAttribute("company", el.Attribute("company").Value),
                                                                       new XAttribute("street", el.Descendants(ns + "info").First().Attribute("street").Value),
                                                                       new XAttribute("price", el.Descendants(ns + "price").First().Value))));
            doc.Save(fileName);
        }
    }
}
