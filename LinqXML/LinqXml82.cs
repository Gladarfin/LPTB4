// File: "LinqXml82"
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

        //LinqXml82°. Дан XML-документ с информацией о задолженности по оплате коммунальных услуг. 
        //Образец элемента первого уровня (смысл данных тот же, что и в LinqXml76, в качестве имени элемента первого уровня 
        //указываются номера дома и квартиры, разделенные символом «-» (дефис) и снабженные префиксом addr, 
        //а в качестве значения этого элемента указывается размер задолженности для данной квартиры):
            //<addr12-23>1245.64</addr12-23>
        //Преобразовать документ, выполнив группировку данных по номеру дома, а в пределах каждого дома — по номеру этажа.
        //Изменить элементы первого уровня следующим образом:
            //<house12>
            //  <floor1 count = "0" total-debt="0" />
            //  ...
            //  <floor6 count = "1" total-debt="1245.64" />
            //  ...
            //  <floor9 count = "3" total-debt="3142.7" />
            //</house12>
        //Имя элемента первого уровня должно иметь префикс house, после которого указывается номер дома, имя элемента второго уровня 
        //должно иметь префикс floor, после которого указывается номер этажа.Атрибут count равен числу задолжников на данном этаже,
        //атрибут total-debt определяет суммарную задолженность по данному этажу, округленную до двух дробных знаков(незначащие нули        
        //не отображаются). Если на данном этаже отсутствуют задолжники, то для соответствующего элемента второго уровня значения 
        //атрибутов count и total-debt должны быть равны 0. Элементы первого уровня должны быть отсортированы по возрастанию номеров
        //домов, а их дочерние элементы — по возрастанию номеров этажей.

        public static void Solve()
        {
            Task("LinqXml82");
            string fileName = GetString();
            XDocument doc = XDocument.Load(fileName);
            XNamespace ns = doc.Root.Name.Namespace;
            var data = doc.Root.Elements()
                            .Select(e =>
                            {
                                string[] s = e.Name.LocalName.Substring(4).Split('-');
                                return new
                                {
                                    house = int.Parse(s[0]),
                                    floor = (int.Parse(s[1]) - 1) % 36 / 4 + 1,
                                    debt = (double)e
                                };
                            }).OrderBy(e => e.house);
            var floors = Enumerable.Range(1, 9);
            doc.Root.ReplaceNodes(data.GroupBy(e => e.house,
                                              (k, ee) => new XElement(ns + ("house" + k),
                                                                      floors.GroupJoin(ee, e1 => e1, e2 => e2.floor,
                                                                                      (e1, ee2) => new XElement(ns + ("floor" + e1),
                                                                                      new XAttribute("count", ee2.Count()),
                                                                                      new XAttribute("total-debt", Math.Round(ee2.Sum(e => e.debt), 2)))))));
            doc.Save(fileName);
        }
    }
}
