// File: "LinqXml86"
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

        //LinqXml86°. Дан XML-документ с информацией об оценках учащихся по различным предметам. 
        //Образец элемента первого уровня (смысл данных тот же, что и в LinqXml83):
            //<pupil name = "Степанова Д.Б." class="9">
            //  <info mark = "4" subject="Физика" />
            //</pupil>
        //Преобразовать документ, выполнив группировку данных по учащимся и изменив элементы первого уровня следующим образом:
            //<Степанова_Д.Б. class="9">
            //  <mark4 subject = "Физика" />
            //  ...
            //</Степанова_Д.Б.>
        //Имя элемента первого уровня совпадает с фамилией и инициалами учащегося(пробел между фамилией и инициалами заменяется
        //символом подчеркивания), имя элемента второго уровня должно иметь префикс mark, после которого указывается оценка.
        //Элементы первого уровня должны быть отсортированы в алфавитном порядке фамилий и инициалов учащихся, их дочерние элементы 
        //— по убыванию оценок, а для одинаковых оценок — в алфавитном порядке названий предметов.
        public static void Solve()
        {
            Task("LinqXml86");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Elements().Select(el => new { 
                                                                name = el.Attribute("name").Value.Replace(" ","_"),
                                                                cl = int.Parse(el.Attribute("class").Value),
                                                                mark = el.Element(ns + "info").Attribute("mark").Value,
                                                                subject = el.Element(ns + "info").Attribute("subject").Value
                                                             })
                                .OrderBy(el => el.name).ThenByDescending(el => el.mark).ThenBy(el => el.subject);
            doc.Root.ReplaceNodes(data.GroupBy(n => n.name +" " + n.cl,
                                               (n, el) => new XElement(ns + n.Split(' ')[0],
                                                                       new XAttribute("class", n.Split(' ')[1]),
                                                                       el.Select(e => new XElement(ns + "mark" + e.mark,
                                                                                                   new XAttribute("subject", e.subject))))));
            doc.Save(fileName);
        }
    }
}
