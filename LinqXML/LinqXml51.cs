// File: "LinqXml51"
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
        // ѕри решении задач группы LinqXml доступны следующие
        // дополнительные методы расширени€, определенные в задачнике:
        //
        //   Show() и Show(cmt) - отладочна€ печать последовательности,
        //     cmt - строковый комментарий;
        //
        //   Show(e => r) и Show(cmt, e => r) - отладочна€ печать
        //     значений r, полученных из элементов e последовательности,
        //     cmt - строковый комментарий.


        //LinqXml51∞. ƒан XML-документ. Ћюбой его элемент содержит либо набор дочерних элементов,
        //либо текстовое представление некоторой даты, соответствующее стандарту XML. 
        //»зменить все элементы, содержащие дату, следующим образом: добавить атрибут year, 
        //содержащий значение года из исходной даты, и дочерний элемент day с текстовым значением,
        //равным значению дн€ из исходной даты, после чего удалить из обрабатываемого элемента исходную дату.

        //”казание.»спользовать приведение элемента XML к типу DateTime.
        public static void Solve()
        {
            Task("LinqXml51");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            //i don't like this, but it works
            foreach (var e in doc.Root.Descendants().Where(el => !el.HasElements && el.Name.LocalName != "day"))
            {
                var date = (DateTime)e;
                e.Add(new XAttribute("year", date.Year));
                e.ReplaceNodes(new XElement("day", date.Day));
            }
            doc.Save(fileName);
        }
    }
}
