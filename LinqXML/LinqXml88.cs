// File: "LinqXml88"
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

        //LinqXml88°. Дан XML-документ с информацией об оценках учащихся по различным предметам. 
        //Образец элемента первого уровня (смысл данных тот же, что и в LinqXml83, данные сгруппированы по классам):
            //<class number="9">
            //  <pupil name="Степанова Д.Б." subject="Физика" mark="4" />
            //  ...
            //</class>
        //Преобразовать документ, выполнив группировку данных по предметам и оставив сведения только о тех учащихся, 
        //которые получили по данному предмету более двух оценок. Изменить элементы первого уровня следующим образом:
            //<subject name="Физика">
            //  <pupil class="9" name="Степанова Д.Б." m1="4" m2="3" m3="3" />
            //  ...
            //</subject>
        //Оценки каждого учащегося по данному предмету указываются в атрибутах, имеющих префикс m, после которого следует порядковый номер оценки.
        //Элементы первого уровня должны быть отсортированы в алфавитном порядке названий предметов, их дочерние элементы — по возрастанию
        //номеров классов, а для одинаковых классов — в алфавитном порядке фамилий и инициалов учащихся. Оценки для каждого учащегося
        //должны располагаться в порядке убывания. Если для некоторого предмета не найдены учащиеся, имеющие по нему более двух оценок,
        //то соответствующий элемент первого уровня должен быть представлен комбинированным тегом, например:
            //<subject name="Химия" />

        public static void Solve()
        {
            Task("LinqXml88");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Descendants(ns + "pupil").Select(el => new { 
                                                                                cl = int.Parse(el.Parent.Attribute("number").Value),
                                                                                name = el.Attribute("name").Value,
                                                                                subject = el.Attribute("subject").Value,
                                                                                mark = int.Parse(el.Attribute("mark").Value)
                                                                            })
                               .OrderBy(el => el.subject).ThenBy(c => c.cl).ThenBy(n => n.name).ThenByDescending(m => m.mark);

            doc.Root.ReplaceNodes(data.GroupBy(s => s.subject,
                                       (s, ee) => new XElement(ns + "subject",
                                                   new XAttribute("name", s),
                                                   ee.GroupBy(n => n.name).Where(mc => mc.Select(m => m.mark).Count() > 2)
                                                   .Select(e => new XElement(ns + "pupil",
                                                                 new XAttribute("class", e.Select(ec => ec.cl).First()),
                                                                 new XAttribute("name", e.Key),
                                                                 e.Select((el, i) => new XAttribute("m" + (i + 1), el.mark)))))));
            doc.Save(fileName);
        }
    }
}
