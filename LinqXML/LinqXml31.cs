// File: "LinqXml31"
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

        //LinqXml31°. Дан XML-документ и строки S1 и S2. 
        //В строке S1 записано имя одного из элементов исходного документа, 
        //строка S2 содержит допустимое имя элемента XML. После каждого элемента 
        //первого уровня с именем S1 добавить элемент с именем S2. 
        //Атрибуты и потомки добавленного элемента должны совпадать с атрибутами и потомками предшествующего элемента.
        //Указание.Для каждого элемента S1 вызвать метод AddAfterSelf с тремя параметрами: строкой S2 и последовательностями Attributes и Nodes элемента S1.
        public static void Solve()
        {
            Task("LinqXml31");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var s1 = GetString();
            var s2 = GetString();
            foreach(var e in doc.Root.Elements(s1))
            {
                e.AddAfterSelf(new XElement(s2, e.Attributes(), e.Nodes()));
            }
            doc.Save(fileName);
        }
    }
}
