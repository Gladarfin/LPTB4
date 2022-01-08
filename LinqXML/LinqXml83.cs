// File: "LinqXml83"
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

        //LinqXml83°. Дан XML-документ с информацией об оценках учащихся по различным предметам. Образец элемента первого уровня:
            //<record>
            //  <class>9</class>
            //  <name>Степанова Д.Б.</name>
            //  <subject>Физика</subject>
            //  <mark>4</mark>
            //</record>
        //Здесь class — номер класса(целое число от 7 до 11), name — фамилия и инициалы учащегося(инициалы не содержат пробелов
        //и отделяются от фамилии одним пробелом), subject — название предмета, не содержащее пробелов, mark — оценка(целое число 
        //в диапазоне от 2 до 5). Полных однофамильцев(с совпадающей фамилией и инициалами) среди учащихся нет.Преобразовать документ,
        //изменив элементы первого уровня следующим образом:
            //<mark subject = "Физика" >
            //  < name class="9">Степанова Д.Б.</name>
            //  <value>4</value>
            //</mark>
        // Порядок следования элементов первого уровня не изменять.
        public static void Solve()
        {
            Task("LinqXml83");
            var fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Elements().Select(el => new XElement(ns + "mark", 
                                                                                new XAttribute("subject", el.Element(ns + "subject").Value),
                                                                                new XElement(ns + "name",
                                                                                             new XAttribute("class", el.Element(ns + "class").Value),
                                                                                             el.Element(ns + "name").Value),
                                                                                new XElement(ns + "value", el.Element(ns + "mark").Value))));
            doc.Save(fileName);

        }
    }
}
