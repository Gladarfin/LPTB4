using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace PT4Tasks
{
    public class MyTask: PT
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

        public static void Solve()
        {
            Task("LinqXml13");

            //LinqXml13∞. ƒан XML-документ, содержащий хот€ бы один атрибут.
            //¬ывести все различные имена атрибутов, вход€щих в документ.
            //ѕор€док имен атрибутов должен соответствовать пор€дку их первого вхождени€ в документ.
            //”казание.»спользовать методы SelectMany и Distinct.
            var doc = XDocument.Load(GetString());
            var result = doc.Descendants()
               .Attributes()
               .Select(e => e.Name.LocalName)
               .Distinct();
            Put(result);
        }
    }
}
