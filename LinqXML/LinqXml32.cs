// File: "LinqXml32"
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

        //LinqXml32°. Дан XML-документ и строки S1 и S2. 
        //В строке S1 записано имя одного из элементов исходного документа, 
        //строка S2 содержит допустимое имя элемента XML. 
        //Перед каждым элементом второго уровня с именем S1 добавить элемент с именем S2. 
        //Добавленный элемент должен содержать последний атрибут и первый дочерний элемент 
        //последующего элемента (если они есть). Если элемент S1 не имеет дочерних элементов, 
        //то добавленный перед ним элемент S2 должен быть представлен в виде комбинированного тега.
        //Указание.Использовать метод FirstOrDefault.
        public static void Solve()
        {
            Task("LinqXml32");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            string s1 = GetString();
            string s2 = GetString();
            foreach (var e in doc.Root.Elements().Elements(s1))
            {
                e.AddBeforeSelf(new XElement(s2, e.LastAttribute, e.Elements().FirstOrDefault()));
            }
            doc.Save(fileName);
        }
    }
}
