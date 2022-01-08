// File: "LinqXml72"
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

        //LinqXml72°. Дан XML-документ с информацией о ценах автозаправочных станций на бензин. 
        //Образец элемента первого уровня (смысл данных тот же, что и в LinqXml68,
        //данные сгруппированы по названиям компаний; названия компаний указываются в качестве имен элементов первого уровня):
            //<Лидер>
            //  <price street = "ул.Чехова" brand="92">2200</price>
            //  ...
            //</Лидер>
        //Преобразовать документ, выполнив группировку данных по названиям улиц, 
        //а в пределах каждой улицы — по маркам бензина.Изменить элементы первого уровня следующим образом:
            //<ул.Чехова>
            //  <b92>
            //    <min-price company = "Премьер-нефть" > 2050 </ min - price >
            //    ...
            //  </b92>
            //  ...
            //</ул.Чехова>
        //Имя элемента первого уровня совпадает с названием улицы, имя элемента второго уровня должно иметь префикс b,
        //после которого указывается марка бензина.Значение элемента третьего уровня равно минимальной цене бензина 
        //данной марки на данной улице, его атрибут company содержит название компании, на АЗС которой предлагается минимальная цена.
        //Элементы первого уровня должны быть отсортированы в алфавитном порядке названий улиц, 
        //а их дочерние элементы — по возрастанию марок бензина. Если имеется несколько элементов третьего уровня, 
        //имеющих общего родителя (это означает, что на одной улице имеется несколько АЗС, 
        //на которых бензин данной марки имеет минимальную цену), то эти элементы должны быть отсортированы
        //в алфавитном порядке названий компаний.
        public static void Solve()
        {
            Task("LinqXml72");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Descendants(ns + "price")
                                          .OrderBy(sn => sn.Attribute("street").Value)
                                     .GroupBy(st => st.Attribute("street").Value,
                                              (s, el) => new XElement(ns + s,
                                                          el.OrderBy(eb => eb.Attribute("brand").Value)
                                                            .GroupBy(br => br.Attribute("brand").Value,
                                                                     (b, co) => new XElement(ns + ("b" + b),
                                                                     co.Select(p => new XElement(ns + "min-price",
                                                                                     new XAttribute("company", p.Parent.Name.LocalName),
                                                                                     p.Value))
                                                                       .Where(l => l.Value == co.Min(pm => pm.Value))
                                                                       .OrderBy(pr => pr.Value)
                                                                       .ThenBy(cn => cn.Attribute("company").Value))))));
            doc.Save(fileName);
        }
    }
}
