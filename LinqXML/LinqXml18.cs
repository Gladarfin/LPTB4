// File: "LinqXml18"
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

        //LinqXml18∞. ƒан XML-документ, содержащий хот€ бы один атрибут.
        //Ќайти все различные имена атрибутов и вывести эти имена, а также 
        //все св€занные с ними значени€(все значени€ считаютс€ текстовыми). 
        //ѕор€док имен должен соответствовать пор€дку их первого вхождени€ в документ; 
        //значени€, св€занные с каждым именем, выводить в алфавитном пор€дке.

        public static void Solve()
        {
            Task("LinqXml18");
            var doc = XDocument.Load(GetString());
            var result = doc.Descendants()
                            .Attributes()
                            .Select(elem => new 
                            { 
                                attrName = elem.Name.LocalName,
                                attrValue = elem.Value
                            })
                            .GroupBy(elem => elem.attrName);

            foreach (var e in result)
            {
                Put(e.Key);
                var attrValues = e.Select(atr => atr.attrValue).OrderBy(atr => atr);
                foreach (var v in attrValues)
                    Put(v);
            }

        }
    }
}
