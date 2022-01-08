// File: "LinqXml78"
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

        //LinqXml78°. Дан XML-документ с информацией о задолженности по оплате коммунальных услуг. 
        //Образец элемента первого уровня (смысл данных тот же, что и в LinqXml76):
        //<debt house = "12" flat="23">
        //  <name>Иванов А.В.</name>
        //  <value>1245.64</value>
        //</debt>
        //Преобразовать документ, выполнив группировку данных по номеру дома, 
        //а в пределах каждого дома — по номеру подъезда.Изменить элементы первого уровня следующим образом:
        //<house number = "12" >
        //  < entrance number= "1" >
        //    < debt name= "Иванов А.В." flat= "23" > 1245.64 </ debt >
        //    ...
        //  </entrance>
        //  ...
        //</house>
        //Элементы первого уровня должны быть отсортированы по возрастанию номеров домов, 
        //а их дочерние элементы — по возрастанию номеров подъездов. Элементы третьего уровня, 
        //имеющие общего родителя, должны быть отсортированы по убыванию размера задолженности 
        //(предполагается, что размеры всех задолженностей являются различными). Подъезды, в которых отсутствуют задолжники, 
        //не отображаются.
        public static void Solve()
        {
            Task("LinqXml78");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Elements().Select(el => new {
                house = int.Parse(el.Attribute("house").Value),
                flat = int.Parse(el.Attribute("flat").Value),
                entrance = (int.Parse(el.Attribute("flat").Value) - 1) / 36 + 1,
                name = el.Element(ns + "name").Value,
                debt = el.Element(ns + "value").Value
            }).OrderBy(n => n.house).ThenBy(e => e.entrance).Show();
            doc.Root.ReplaceNodes(data.GroupBy(hn => hn.house,
                                               (e, h) => new XElement(ns + "house",
                                                             new XAttribute("number", e),
                                                             h.GroupBy(en => en.entrance,
                                                                       (n, ed) => new XElement(ns + "entrance",
                                                                                      new XAttribute("number", n),
                                                                                      ed.Select(d => new XElement(ns + "debt",
                                                                                                         new XAttribute("name", d.name),
                                                                                                         new XAttribute("flat", d.flat),
                                                                                                         d.debt))
                                                                                        .OrderByDescending(d => (double)d))))));
            doc.Save(fileName);                              
        }
    }
}
