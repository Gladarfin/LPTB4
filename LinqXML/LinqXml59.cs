// File: "LinqXml59"
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

        //LinqXml59°. Дан XML-документ. В каждом из элементов первого уровня определен единственный префикс пространства имен, 
        //причем известно, что все атрибуты с этим префиксом имеют целочисленные значения. Для каждого элемента первого уровня 
        //и его элементов-потомков удвоить значения всех атрибутов с префиксом пространства имен, определенным в этом элементе.
        public static void Solve()
        {
            Task("LinqXml59");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            //meh
            foreach (var e in doc.Root.Elements().Attributes().Where(el => el.IsNamespaceDeclaration))
            {
                var prefix = (XNamespace)e.Value;
                var elems = e.Parent.DescendantsAndSelf().Attributes();
                foreach (var at in e.Parent.DescendantsAndSelf().Attributes().Where(el => prefix == el.Name.NamespaceName))
                {
                    at.Value = (int.Parse(at.Value) * 2).ToString();
                }
            }
            doc.Save(fileName);

        }
    }
}
