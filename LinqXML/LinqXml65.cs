// File: "LinqXml65"
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

        //LinqXml65°. Дан XML-документ с информацией о клиентах фитнес-центра. 
        //Образец элемента первого уровня (смысл данных тот же, что и в LinqXml61, 
        //данные сгруппированы по кодам клиентов; коды клиентов, снабженные префиксом id, 
        //указываются в качестве имен элементов первого уровня):
            //<id10>
            //  <info>
            //    <date>2000-05-01T00:00:00</date>
            //    <time>PT5H13M</time>
            //  </info>
            //  ...
            //</id10>
        //Преобразовать документ, сгруппировав данные по годам и изменив элементы первого уровня следующим образом:
            //<year value = "2000" >
            //  < total - time id="10">860</total-time>
            //  ...
            //</year>
        //Значение элемента второго уровня должно быть равно общей продолжительности занятий(в минутах) 
        //клиента с указанным кодом в течение указанного года.Элементы первого уровня должны быть
        //отсортированы по возрастанию номера года, их дочерние элементы — по возрастанию кодов клиентов. 

        public static void Solve()
        {
            Task("LinqXml65");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Descendants(ns + "date")
                                          .GroupBy(d => ((DateTime)d).Year)
                                          .Select(e => new XElement(ns + "year",
                                                                    new XAttribute("value", e.Key),
                                                                    e.Select(tt => new { 
                                                                                        id = tt.Parent.Parent.Name.LocalName.Substring(2),
                                                                                        time = ((TimeSpan)tt.Parent.Element(ns + "time")).TotalMinutes})
                                                                    .GroupBy(aid => aid.id)
                                                                    .Select(el => new XElement(ns + "total-time",
                                                                                               new XAttribute("id", el.Key),
                                                                                               el.Select(ek => ek.time).Sum()))
                                                                    .OrderBy(t => int.Parse(t.Attribute("id").Value))))
                                          .OrderBy(el => el.Attribute("value").Value));            
            doc.Save(fileName);
        }
    }
}
