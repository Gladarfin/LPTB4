// File: "LinqXml81"
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

        //LinqXml81°. Дан XML-документ с информацией о задолженности по оплате коммунальных услуг. 
        //Образец элемента первого уровня (смысл данных тот же, что и в LinqXml76, данные сгруппированы по номерам домов; 
        //в качестве имен элементов первого уровня указываются номера домов, снабженные префиксом house,
        //а в качестве имен элементов второго уровня — номера квартир, снабженные префиксом flat):
            //<house12>
            //  <flat23 name = "Иванов А.В." debt="1245.64" />
            //  ...
            //</house12>
        //Преобразовать документ, сохранив группировку данных по номеру дома, выполнив в пределах каждого дома
        //группировку по номеру подъезда и оставив сведения только о тех жильцах, 
        //размер задолженности которых не меньше среднего размера задолженности по данному подъезду.
        //Изменить элементы первого уровня следующим образом:
            //<house number = "12" >
            //  < entrance number= "1" count= "4" avr-debt= "1136" >
            //    < debt flat= "23" name= "Иванов А.В." > 1245.64 </ debt >
            //    < debt flat= "28" name= "Сидоров П.К." > 1383.27 </ debt >
            //  </ entrance >
            //  ...
            //</house>
        //Атрибут count равен количеству задолжников в данном подъезде, атрибут avr-debt определяет среднюю задолженность
        //по данному подъезду в рублях (целое число), вычисленную по следующей формуле: 
        //«суммарная задолженность в копейках»/(«количество задолжников»*100) (символ «/» обозначает операцию целочисленного деления). 
        //Элементы третьего уровня содержат сведения о тех жильцах, размер задолженности которых не меньше величины avr-debt для данного 
        //подъезда.Элементы первого уровня должны быть отсортированы по возрастанию номеров домов, а их дочерние элементы — по возрастанию 
        //номеров подъездов. Элементы третьего уровня, имеющие общего родителя, должны быть отсортированы по возрастанию номеров квартир.
        //Подъезды, в которых отсутствуют задолжники, не отображаются. 
        public static void Solve()
        {
            Task("LinqXml81");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Elements().Descendants().Select(el => new { 
                                                                                house = int.Parse(el.Parent.Name.LocalName.Replace("house","")),
                                                                                flat = int.Parse(el.Name.LocalName.Replace("flat","")),
                                                                                entrance = (int.Parse(el.Name.LocalName.Replace("flat","")) - 1) / 36 + 1,
                                                                                name = el.Attribute("name").Value,
                                                                                debt = (double)el.Attribute("debt")
                                                                           })
                                .OrderBy(h => h.house).ThenBy(e => e.entrance).ThenBy(f => f.flat);
            doc.Root.ReplaceNodes(data.GroupBy(h => h.house,
                                       (hn, ee) => new XElement(ns + "house",
                                                    new XAttribute("number", hn),
                                                    ee.GroupBy(en => en.entrance,
                                                       (e, el) => new XElement(ns + "entrance",
                                                                   new XAttribute("number", e),
                                                                   new XAttribute("count", el.Select(c => c.name).Count()),
                                                                   new XAttribute("avr-debt", Math.Truncate(el.Select(d => d.debt).Sum() / el.Select(c => c.name).Count())),
                                                                   el.Select(df => new XElement(ns + "debt",
                                                                                        new XAttribute("flat", df.flat),
                                                                                        new XAttribute("name", df.name),
                                                                                        df.debt))
                                                                     .Where(ad => (double)ad >= Math.Truncate(el.Select(d => d.debt).Sum() / el.Select(c => c.name).Count())))))));
            doc.Save(fileName);
        }
    }
}
