// File: "LinqXml54"
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

        //LinqXml54°. Дан XML-документ, у которого корневой элемент и, возможно, 
        //какие-либо другие элементы имеют непустое пространство имен. 
        //Связать с пространством имен корневого элемента все элементы первого и второго уровня; 
        //для элементов более высоких уровней оставить их прежние пространства имен. 
        public static void Solve()
        {
            Task("LinqXml54");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            foreach (var e in doc.Root.Descendants().Where(el => el.Ancestors().Count() <= 2))
            {
                e.Attributes("xmlns").Remove();
                e.Name = doc.Root.GetDefaultNamespace() + e.Name.LocalName;
            }
            doc.Save(fileName);

        }
    }
}
