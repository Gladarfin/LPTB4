// File: "LinqXml87"
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

        //LinqXml87°. Дан XML-документ с информацией об оценках учащихся по различным предметам. 
        //Образец элемента первого уровня (смысл данных тот же, что и в LinqXml83, данные сгруппированы по учащимся):
            //<pupil name = "Степанова Д.Б." class="9">
            //  <mark subject = "Физика" > 4 </ mark >
            //  ...
            //</pupil>
        //Преобразовать документ, выполнив группировку данных по названиям предметов и изменив элементы первого уровня следующим образом:
            //<Физика>
            //  <class9>
            //    <mark-count>4</mark-count>
            //    <avr-mark>4.1</avr-mark>
            //  </class9>
            //  ...
            //</Физика>
        //Имя элемента первого уровня совпадает с названием предмета, имя элемента второго уровня должно иметь префикс class, 
        //после которого указывается номер класса.Значение элемента mark-count равно количеству оценок по данному предмету,
        //выставленных в данном классе; значение элемента avr-mark равно среднему значению этих оценок, найденному по следующий формуле: 
        //10*«сумма оценок»/«количество оценок»*0.1 (символ «/» обозначает операцию целочисленного деления, полученное значение должно 
        //содержать не более одного дробного знака, незначащие нули не отображаются). 
        //Элементы первого уровня должны быть отсортированы в алфавитном порядке названий предметов, а их дочерние элементы — 
        //по возрастанию номеров классов.Для каждого предмета отображать только те классы, в которых выставлена хотя бы одна оценка
        //по этому предмету. 
        public static void Solve()
        {
            Task("LinqXml87");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Descendants(ns + "mark").Select(el => new { 
                                                                               subject = el.Attribute("subject").Value,
                                                                               mark = int.Parse(el.Value),
                                                                               cl = int.Parse(el.Parent.Attribute("class").Value)
                                                                            }).OrderBy(el => el.subject).ThenBy(el => el.cl);
            doc.Root.ReplaceNodes(data.GroupBy(s => s.subject,
                                        (s, es) => new XElement(ns + s,
                                                    es.GroupBy(c => c.cl,
                                                        (c, ec) => new XElement(ns + ("class" + c),
                                                                    new XElement(ns + "mark-count", 
                                                                                 ec.Select(e => e.mark).Count()),
                                                                    new XElement(ns + "avr-mark",
                                                                                 Math.Round(10 * ec.Select(e => e.mark).Sum() / ec.Select(e => e.mark).Count() * 0.1, 1)))))));
            doc.Save(fileName);                         
        }
    }
}
