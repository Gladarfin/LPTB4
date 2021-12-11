// File: "LinqXml19"
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

        public static void Solve()
        {
            //LinqXml19°. Дан XML-документ, содержащий хотя бы один элемент первого уровня. 
            //Для каждого элемента первого уровня найти его дочерние элементы, 
            //имеющие максимальное количество потомков (при подсчете числа потомков 
            //учитывать также потомки-узлы, не являющиеся элементами). Перебирая элементы 
            //первого уровня в порядке их появления в XML-документе, вывести имя элемента, 
            //число N — максимальное количество потомков, имеющихся у его дочерних элементов 
            //(значение N может быть равно 0), — и имена всех дочерних элементов, имеющих N 
            //потомков (имена дочерних элементов выводить в алфавитном порядке; среди этих имен 
            //могут быть совпадающие). Если элемент первого уровня не содержит дочерних элементов, 
            //то в качестве значения N выводить −1, а в качестве имени дочернего элемента — текст «no child». 

            Task("LinqXml19");
            var doc = XDocument.Load(GetString());
            
            foreach (var elem in doc.Root.Elements())
            {
                Put(elem.Name.LocalName);
                var max = elem.Descendants()
                              .Select(e => e.DescendantNodes()
                                            .Count()).DefaultIfEmpty(-1)
                                            .Max();
                Put(max);
                var desc = elem.Descendants()
                               .Where(e => e.DescendantNodes().Count() == max)
                               .Select(n => n.Name.LocalName)
                               .OrderBy(name => name)
                               .DefaultIfEmpty("no child");               
                foreach (var d in desc)
                {
                    Put(d);
                }
            }
        }
    }
}
