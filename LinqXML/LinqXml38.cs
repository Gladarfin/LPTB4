// File: "LinqXml38"
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


        //LinqXml38°. Дан XML-документ. Для каждого элемента, кроме корня, 
        //изменить его имя, добавив к нему слева исходные имена всех его предков, 
        //разделенные символом «-» (дефис). Например, если корневой элемент имеет имя root, 
        //то элемент bb второго уровня, родительский элемент которого имеет имя aa, должен получить имя root-aa-bb. 
        //Указание. Перебирая все элементы последовательности Descendants корневого элемента, использовать их свойства Parent и Name. 

        public static void Solve()
        {
            Task("LinqXml38");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);

            foreach (var e in doc.Root.Descendants())
            {
                e.Name = e.Parent.Name + "-" + e.Name;
            }
            doc.Save(fileName);
        }
    }
}
