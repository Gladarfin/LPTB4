// File: "LinqXml79"
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

        //LinqXml79°. Дан XML-документ с информацией о задолженности по оплате коммунальных услуг.
        //Образец элемента первого уровня (смысл данных тот же, что и в LinqXml76):
            //<house value = "12" >
            //  < flat value="129" />
            //  <name value = "Сергеев Т.М." />
            //  < debt value="1833.32" />
            //</house>
        //Преобразовать документ, выполнив группировку данных по номеру дома, а в пределах каждого дома — по номеру этажа.
        //Изменить элементы первого уровня следующим образом:
            //<house12>
            //  <floor6>
            //    <Сергеев_Т.М.flat="129" debt="1833.32" />
            //    ...
            //  </floor6>
            //  ...
            //</house12>
        //Имя элемента первого уровня должно иметь префикс house, после которого указывается номер дома;
        //имя элемента второго уровня должно иметь префикс floor, после которого указывается номер этажа.
        //Имя элемента третьего уровня совпадает с фамилией и инициалами жильца; 
        //фамилия отделяется от инициалов символом подчеркивания.
        //Элементы первого уровня должны быть отсортированы по возрастанию номеров домов, 
        //а их дочерние элементы — по убыванию номеров этажей. Элементы третьего уровня, 
        //имеющие общего родителя, должны быть отсортированы в алфавитном порядке фамилий и инициалов жильцов.
        //Этажи, в которых отсутствуют задолжники, не отображаются. 
        public static void Solve()
        {
            Task("LinqXml79");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Elements().Select(e => new{
                                                              house = int.Parse(e.Attribute("value").Value),
                                                              flat = int.Parse(e.Element(ns + "flat").Attribute("value").Value),
                                                              floor = (int.Parse(e.Element(ns + "flat").Attribute("value").Value) - 1) % 36 / 4 + 1,
                                                              name = e.Element(ns + "name").Attribute("value").Value.Replace(" ", "_"),
                                                              debt = e.Element(ns + "debt").Attribute("value").Value
                                                          })
                                          .OrderBy(h => h.house).ThenByDescending(f => f.floor).ThenBy(n => n.name);

            doc.Root.ReplaceNodes(data.GroupBy(h => h.house,
                                              (h, e) => new XElement(ns + ("house" + h),
                                                            e.GroupBy(f => f.floor,
                                                              (f, ee) => new XElement(ns + ("floor" + f),
                                                                             ee.Select(el => new XElement(ns + el.name,
                                                                                                 new XAttribute("flat", el.flat),
                                                                                                 new XAttribute("debt", el.debt))))))));
            doc.Save(fileName);                               
        }
    }
}
