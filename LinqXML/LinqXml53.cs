// File: "LinqXml53"
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


        //LinqXml53°. Дан XML-документ. В каждом элементе первого уровня определено пространство имен,
        //распространяющееся на все его элементы-потомки. Для каждого элемента первого уровня добавить 
        //в конец его набора дочерних узлов элемент с именем namespace и значением, равным пространству 
        //имен обрабатываемого элемента первого уровня (пространство имен добавленного элемента должно
        //совпадать с пространством имен его родительского элемента). 
        public static void Solve()
        {
            Task("LinqXml53");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            foreach (var e in doc.Root.Elements())
            {
                e.Add(new XElement(e.GetDefaultNamespace() + "namespace", e.GetDefaultNamespace()));
            }
            doc.Save(fileName);
        }
    }
}
