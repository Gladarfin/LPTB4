// File: "LinqXml85"
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

        //LinqXml85°. Дан XML-документ с информацией об оценках учащихся по различным предметам. 
        //Образец элемента первого уровня (смысл данных тот же, что и в LinqXml83):
            //<info class="9" name="Степанова Д.Б." subject="Физика" mark="4" />
        //Преобразовать документ, выполнив группировку данных по номеру класса, в пределах каждого класса — по учащимся,
        //а для каждого учащегося — по предметам.Изменить элементы первого уровня следующим образом:
            //<class number="9">
            //  <pupil name = "Степанова Д.Б." >
            //    < subject name="Физика">
            //      <mark>4</mark>
            //      ...
            //    </subject>
            //    ...
            //  </pupil>
            //  ...
            //</class>
        //Элементы первого уровня должны быть отсортированы по возрастанию номеров классов, 
        //а их дочерние элементы — в алфавитном порядке фамилий и инициалов учащихся.Элементы третьего уровня,
        //имеющие общего родителя, должны быть отсортированы в алфавитном порядке названий предметов, а элементы четвертого уровня, 
        //имеющие общего родителя, должны быть отсортированы по убыванию оценок.
        public static void Solve()
        {
            Task("LinqXml85");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Elements().Select(el => new { 
                                                                cl = int.Parse(el.Attribute("class").Value),
                                                                name = el.Attribute("name").Value,
                                                                subject = el.Attribute("subject").Value,
                                                                mark = el.Attribute("mark").Value
                                                             }).OrderBy(el => el.cl)
                                                               .ThenBy(el => el.name)
                                                               .ThenBy(el => el.subject)
                                                               .ThenByDescending(el => el.mark);
            doc.Root.ReplaceNodes(data.GroupBy(el => el.cl,
                                 (c, ee) => new XElement(ns + "class",
                                             new XAttribute("number", c),
                                             ee.GroupBy(p => p.name,
                                                       (p, pp) => new XElement(ns + "pupil",
                                                                   new XAttribute("name", p),
                                                                   pp.GroupBy(s => s.subject,
                                                                             (s, ss) => new XElement(ns + "subject",
                                                                                         new XAttribute("name", s),
                                                                                         ss.Select(e => new XElement(ns + "mark", e.mark)))))))));
            doc.Save(fileName);                                       
        }
    }
}
