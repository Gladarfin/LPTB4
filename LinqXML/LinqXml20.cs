// File: "LinqXml20"
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

        //LinqXml20°. Дан XML-документ, содержащий хотя бы один элемент первого уровня.
        // Для каждого элемента первого уровня найти его элементы-потомки, имеющие максимальное количество атрибутов.
        // Перебирая элементы первого уровня в порядке их появления в XML-документе, вывести имя элемента, 
        // число N — максимальное количество атрибутов у его потомков (значение N может быть равно 0) — и имена потомков, 
        // имеющих N атрибутов(имена потомков выводить в алфавитном порядке; среди этих имен могут быть совпадающие). 
        // Если элемент первого уровня не содержит элементов-потомков, 
       //  то в качестве значения N выводить −1, а в качестве имени потомка — текст «no child». 
        public static void Solve()
        {
            Task("LinqXml20");
            var doc = XDocument.Load(GetString());
            foreach (var elem in doc.Root.Elements())
            {
                Put(elem.Name.LocalName);
                var max = elem.Descendants()
                              .Select(desc => desc.Attributes().Count())
                              .DefaultIfEmpty(-1).Max();
                Put(max);
                var names = elem.Descendants()
                                .Where(desc => desc.Attributes().Count() == max)
                                .Select(desc =>desc.Name.LocalName)
                                .OrderBy(desc => desc)
                                .DefaultIfEmpty("no child");
                
                foreach (var el in names)
                  Put(el);
            }
                
        }
    }
}
