// File: "LinqXml42"
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

        //LinqXml42°. Дан XML-документ, в котором значения всех атрибутов являются текстовыми представлениями вещественных чисел.
        //Добавить к каждому элементу первого уровня, содержащему дочерние элементы, дочерний элемент sum, 
        //содержащий текстовое представление суммы атрибутов всех дочерних элементов данного элемента. Сумма округляется до двух дробных знаков, 
        //незначащие нули не отображаются. Если ни один из дочерних элементов не содержит атрибутов, то элемент sum должен иметь значение 0. 
        public static void Solve()
        {
            Task("LinqXml42");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            foreach (var e in doc.Root.Elements().Where(el => el.Elements().Count() > 0))
            {
                e.Add(new XElement("sum", Math.Round(e.Elements()
                                                      .Attributes()
                                                      .Select(at => (double)at)
                                                      .Sum(),2)));
            }
            doc.Save(fileName);
        }
    }
}
