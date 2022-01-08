// File: "LinqXml62"
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

        //LinqXml62∞. ƒан XML-документ с информацией о клиентах фитнес-центра.
        //ќбразец элемента первого уровн€ (смысл данных тот же, что и в LinqXml61):
        //<time year = "2000" month="5" id="10">PT5H13M</time>
        //ѕреобразовать документ, изменив элементы первого уровн€ следующим образом:
        //<id10 date = "2000-05-01T00:00:00" > 313 </ id10 >
        //
        //»м€ элемента должно иметь префикс id, после которого указываетс€ код клиента; 
        //в значении атрибута date день должен быть равен 1, а врем€ должно быть нулевым.«начение элемента равно 
        //продолжительности зан€тий клиента в данном мес€це, переведенной в минуты.Ёлементы должны быть отсортированы
        //по возрастанию кода клиента, а дл€ одинаковых значений кода Ч по возрастанию даты.
        public static void Solve()
        {
            Task("LinqXml62");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Elements().Select(el => new XElement(ns + "id" + el.Attribute("id").Value,
                                                                                new XAttribute("date", DateTime.Parse(string.Format("{0}-{1}-01",
                                                                                                                                    el.Attribute("year").Value,
                                                                                                                                    el.Attribute("month").Value))),
                                                                                ((TimeSpan)el).TotalMinutes))
                                                     .OrderBy(el => int.Parse(el.Name.LocalName.Remove(0,2)))
                                                     .ThenBy(el => el.Attribute("date").Value));
            doc.Save(fileName);


        }
    }
}
