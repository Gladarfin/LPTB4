// File: "LinqXml35"
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

        //LinqXml35∞. ƒан XML-документ. ƒл€ каждого элемента второго уровн€ добавить 
        //в конец списка его атрибутов атрибут child-count со значением, равным количеству 
        //всех дочерних узлов этого элемента. ≈сли элемент не имеет дочерних узлов, 
        //то атрибут child-count должен иметь значение 0. 
        public static void Solve()
        {
            Task("LinqXml35");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            foreach (var el in doc.Root.Elements().Elements())
            {
                el.Add(new XAttribute("child-count", el.Nodes().Count()));
            }
            doc.Save(fileName);
        }
    }
}
