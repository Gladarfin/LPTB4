// File: "LinqXml76"
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

        //LinqXml76°. Дан XML-документ с информацией о задолженности по оплате коммунальных услуг. Образец элемента первого уровня:
            //<record>
            //  <house>12</house>
            //  <flat>129</flat>
            //  <name>Сергеев Т.М.</name>
            //  <debt>1833.32</debt>
            //</record>
        //Здесь house — номер дома (целое число), flat — номер квартиры (целое число), 
        //name — фамилия и инициалы жильца (инициалы не содержат пробелов и отделяются от фамилии одним пробелом), 
        //debt — размер задолженности в виде дробного числа: целая часть — рубли, дробная часть — копейки(незначащие нули не указываются). 
        //Все дома являются 144-квартирными, имеют 9 этажей и 4 подъезда; на каждом этаже в каждом подъезде располагаются по 4 квартиры.
        //Преобразовать документ, изменив элементы первого уровня следующим образом:
            //<debt house = "12" flat="129">
            //  <name>Сергеев Т.М.</name>
            //  <value>1833.32</value>
            //</debt>
        //Порядок следования элементов первого уровня не изменять.
        public static void Solve()
        {
            Task("LinqXml76");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Elements().Select(e => new XElement(ns + "debt",
                                                                               new XAttribute("house", e.Element(ns + "house").Value),
                                                                               new XAttribute("flat", e.Element(ns + "flat").Value),
                                                                               new XElement(ns + "name", e.Element(ns + "name").Value),
                                                                               new XElement(ns + "value", e.Element(ns + "debt").Value))));
            doc.Save(fileName);
        }
    }
}
