// File: "LinqXml75"
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

        //LinqXml75°. Дан XML-документ с информацией о ценах автозаправочных станций на бензин. 
        //Образец элемента первого уровня (смысл данных тот же, что и в LinqXml68, названия компании и улицы, 
        //разделенные символом подчеркивания, указываются в качестве имен элементов первого уровня):
            //<Лидер_ул.Чехова>
            //  <brand>92</brand>
            //  <price>2200</price>
            //</Лидер_ул.Чехова>
        //Преобразовать документ, сгруппировав данные по названиям улиц и изменив элементы первого уровня следующим образом:
            //<ул.Чехова>
            //  <brand98 station-count="0">0</brand98>
            //  <brand95 station-count="0">0</brand95>
            //  <brand92 station-count="3">2255</brand92>
            //</ул.Чехова>
        //Имя элемента первого уровня совпадает с названием улицы, имя элемента второго уровня имеет префикс brand,
        //после которого указывается марка бензина.Атрибут station-count равен количеству АЗС, 
        //расположенных на данной улице и предлагающих бензин данной марки; значением элемента 
        //второго уровня является средняя цена 1 литра бензина данной марки по всем АЗС, расположенным на данной улице.
        //Средняя цена находится по следующей формуле: «суммарная цена по всем станциям»/«число станций», 
        //где операция «/» обозначает целочисленное деление. Если на данной улице отсутствуют АЗС, предлагающие бензин данной марки,
        //то значение соответствующего элемента второго уровня и значение его атрибута station-count должны быть равны 0. 
        //Элементы первого уровня должны быть отсортированы в алфавитном порядке названий улиц, а их дочерние элементы 
        //— по убыванию марок бензина. 
        public static void Solve()
        {
            Task("LinqXml75");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            //вспомогательные последовательности
            var data = doc.Root.Elements().Select(el =>
            {
                string[] s = el.Name.LocalName.Split('_');
                return new
                {
                    company = s[0],
                    street = s[1],
                    //если здесь выбирать как в других заданиях этой группы элементы по namespace + имени - работать не будет
                    brand = "brand" + el.Element("brand").Value,
                    price = int.Parse(el.Element("price").Value)

                };
            }).OrderBy(e => e.street);
            var brands = new string[] { "brand98", "brand95", "brand92" };

            doc.Root.ReplaceNodes(data.GroupBy(st => st.street,
                                 (s, ee) => new XElement(ns + s,
                                                brands.GroupJoin(ee, e1 => e1, e2 => e2.brand,
                                                (e1, e3) => new XElement(ns + e1,
                                                                new XAttribute("station-count", e3.Select(el => el.company).Count()),
                                                                e3.Select(el => el.company).Count() == 0 ? 0 :
                                                                e3.Select(el => el.price).Sum() / e3.Select(el => el.company).Count()
                                                                )))));
            doc.Save(fileName);
        }
    }
}
