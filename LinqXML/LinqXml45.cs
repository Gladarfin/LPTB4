// File: "LinqXml45"
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

        //LinqXml45°. Дан XML-документ. Для каждого элемента, имеющего атрибуты, добавить в начало его набора 
        //дочерних узлов элемент с именем odd-attr-count и логическим значением, равным true, если суммарное
        //количество атрибутов данного элемента и всех его элементов-потомков является нечетным, и false в противном случае.

        //Указание.В качестве параметра конструктора XElement, определяющего значение элемента, следует использовать логическое выражение; 
        //это позволит отобразить значение логической константы в соответствии со стандартом XML.
        public static void Solve()
        {
            Task("LinqXml45");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);

            foreach (var e in doc.Descendants().Where(el => el.Attributes().Count() > 0))
            {
                e.AddFirst(new XElement("odd-attr-count", e.DescendantsAndSelf()
                                                           .Attributes()
                                                           .Count() % 2 != 0));
            }

            doc.Save(fileName);
        }
    }
}
