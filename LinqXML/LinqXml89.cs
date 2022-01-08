// File: "LinqXml89"
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

        //LinqXml89°. Дан XML-документ с информацией об оценках учащихся по различным предметам. 
        //Образец элемента первого уровня (смысл данных тот же, что и в LinqXml83, в качестве имен элементов 
        //первого уровня указываются фамилии и инициалы учащихся; при этом пробел между фамилией и инициалами заменяется 
        //символом подчеркивания):
            //<Петров_С.Н. class="11" subject="Физика">4</Петров_С.Н.>
        //Преобразовать документ, выполнив группировку данных по предметам, а для каждого предмета — по классам.
        //Изменить элементы первого уровня следующим образом:
            //<Физика>
            //  <class7 pupil-count= "0" mark-count= "0" />
            //  ...
            //  <class11 pupil-count= "3" mark-count= "5" />
            //</ Физика >
        //Имя элемента первого уровня совпадает с названием предмета, имя элемента второго уровня должно иметь префикс class, 
        //после которого указывается номер класса.Значение атрибута pupil-count равно количеству учащихся данного класса,
        //имеющих хотя бы одну оценку по данному предмету, значение атрибута mark-count равно количеству оценок по данному 
        //предмету в данном классе.Для каждого предмета должна быть выведена информация по каждому классу (от 7 до 11);
        //если в некотором классе по данному предмету не было опрошено ни одного учащегося, то атрибуты pupil-count и mark-count
        //должны быть равны 0. Элементы первого уровня должны быть отсортированы в алфавитном порядке названий предметов, 
        //а их дочерние элементы — по возрастанию номеров классов.

        public static void Solve()
        {
            Task("LinqXml89");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Elements().Select(el => new { 
                                                                name = el.Name.LocalName.Replace("_", " "),
                                                                cl = int.Parse(el.Attribute("class").Value),
                                                                subject = el.Attribute("subject").Value,
                                                                mark = int.Parse(el.Value)
                                                            }).OrderBy(s => s.subject);
            var cl = Enumerable.Range(7, 5);

            doc.Root.ReplaceNodes(data.GroupBy(s => s.subject,
                                   (s, ee) => new XElement(ns + s,
                                               cl.GroupJoin(ee, e1 => e1, e2 => e2.cl,
                                                 (e1, ee2) => new XElement(ns + ("class" + e1),
                                                               new XAttribute("pupil-count", ee2.Select(p => p.name).Distinct().Count()),
                                                               new XAttribute("mark-count", ee2.Select(m => m.mark).Count()))))));
            doc.Save(fileName);

        }
    }
}
