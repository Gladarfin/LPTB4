// File: "LinqXml39"
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


        //LinqXml39°. Дан XML-документ. Для каждого элемента, кроме корня, 
        //изменить его имя, добавив к нему слева исходное имя его родительского элемента, 
        //дополненное символом «-» (дефис). Например, элемент cc третьего уровня, 
        //родительский элемент которого имеет имя bb, должен получить имя bb-cc.
        //Указание.Организовать перебор последовательности Descendants корневого элемента в обратном порядке(используя метод Reverse). 
        public static void Solve()
        {
            Task("LinqXml39");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            foreach (var e in doc.Root.Descendants().Reverse())
            {
                e.Name = e.Parent.Name + "-" + e.Name;
            }
            doc.Save(fileName);
        }
    }
}
