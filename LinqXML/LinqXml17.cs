// File: "LinqXml17"
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


        //LinqXml17∞. ƒан XML-документ, содержащий хот€ бы один текстовый узел. 
        //Ќайти все различные имена элементов, имеющих дочерний текстовый узел, 
        //и вывести эти имена, а также значени€ всех св€занных с ними дочерних текстовых узлов. 
        //»мена выводить в алфавитном пор€дке; текстовые значени€, св€занные с каждым именем, 
        //выводить в пор€дке их по€влени€ в документе. 
        public static void Solve()
        {
            Task("LinqXml17");
            var doc = XDocument.Load(GetString());
            var result = doc.Root.DescendantNodes()
                            .OfType<XText>()
                            .Where(e => e.Value != "")
                            .Select(elem => new
                            {
                                name = elem.Parent.Name.LocalName,
                                text = elem.Value
                            })
                            .OrderBy(e => e.name)
                            .GroupBy(e => e.name);

            foreach (var k in result)
            {
                Put(k.Key);
                var textValues = k.Select(e => e.text);
                foreach (var v in textValues)
                    Put(v);
            }
        }
    }
}
