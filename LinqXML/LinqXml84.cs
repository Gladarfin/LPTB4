// File: "LinqXml84"
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

        //LinqXml84°. Дан XML-документ с информацией об оценках учащихся по различным предметам. 
        //Образец элемента первого уровня (смысл данных тот же, что и в LinqXml83):
            //<pupil class="9" name="Степанова Д.Б.">
            //  <subject>Физика</subject>
            //  <mark>4</mark>
            //</pupil>
        //Преобразовать документ, изменив элементы первого уровня следующим образом:
        //<class9 name = "Степанова Д.Б." subject="Физика">4</class9>
        //Имя элемента должно иметь префикс class, после которого указывается номер класса.Элементы должны быть отсортированы
        //по возрастанию номеров классов, для одинаковых номеров классов — в алфавитном порядке фамилий и инициалов учащихся,
        //для каждого учащегося — в алфавитном порядке названий предметов, а для одинаковых предметов — по возрастанию оценок.
        public static void Solve()
        {
            Task("LinqXml84");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Elements().Select(el => new { 
                                                                cl = int.Parse(el.Attribute("class").Value),
                                                                name = el.Attribute("name").Value,
                                                                subject = el.Element(ns + "subject").Value,
                                                                mark = el.Element(ns + "mark").Value
                                                             })
                                .OrderBy(el => el.cl).ThenBy(el => el.name).ThenBy(el => el.subject).ThenBy(el => el.mark);

            doc.Root.ReplaceNodes(data.Select(el => new XElement(ns + ("class" + el.cl),
                                                                 new XAttribute("name", el.name),
                                                                 new XAttribute("subject", el.subject),
                                                                 el.mark)));
            doc.Save(fileName);
        }
    }
}
