// File: "LinqXml77"
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

        //LinqXml77°. Дан XML-документ с информацией о задолженности по оплате коммунальных услуг. 
        //Образец элемента первого уровня (смысл данных тот же, что и в LinqXml76):
            //<debt house = "12" flat="129" name="Сергеев Т.М.">1833.32</debt>
        //Преобразовать документ, изменив элементы первого уровня следующим образом:
            //<address12-129 name="Сергеев Т.М." debt="1833.32" />
        //Имя элемента должно иметь префикс address, после которого указывается номер дома и, через дефис, номер квартиры.
        //Элементы представляются комбинированными тегами и должны быть отсортированы по возрастанию номеров домов, 
        //а для одинаковых номеров домов — по возрастанию номеров квартир.

        public static void Solve()
        {
            Task("LinqXml77");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Elements().Select(el => new { 
                                                                house = int.Parse(el.Attribute("house").Value),
                                                                flat = int.Parse(el.Attribute("flat").Value),
                                                                name = el.Attribute("name").Value,
                                                                debt = el.Value
                                                             })
                                          .OrderBy(h => h.house).ThenBy(f => f.flat);

            doc.Root.ReplaceNodes(data.Select(el => new XElement(ns + ("address" + el.house +"-"+ el.flat),
                                                                 new XAttribute("name", el.name),
                                                                 new XAttribute("debt", el.debt))));
            doc.Save(fileName);
        }
    }
}
