// File: "LinqXml34"
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
        // ѕри решении задач группы LinqXml доступны следующие
        // дополнительные методы расширени€, определенные в задачнике:
        //
        //   Show() и Show(cmt) - отладочна€ печать последовательности,
        //     cmt - строковый комментарий;
        //
        //   Show(e => r) и Show(cmt, e => r) - отладочна€ печать
        //     значений r, полученных из элементов e последовательности,
        //     cmt - строковый комментарий.


        //LinqXml34∞. ƒан XML-документ. 
        //ƒл€ каждого элемента первого уровн€, имеющего атрибуты, 
        //добавить в конец его дочерних узлов элементы с именами, 
        //совпадающими с именами его атрибутов, и текстовыми значени€ми, 
        //совпадающими со значени€ми соответствующих атрибутов, после чего 
        //удалить все атрибуты обрабатываемого элемента первого уровн€.
        //”казание.»спользовать метод ReplaceAttributes, указав в качестве 
        //параметра последовательность элементов, полученную методом Select из последовательности атрибутов.
        public static void Solve()
        {
            Task("LinqXml34");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            foreach (var e in doc.Root.Elements().Where(el => el.HasAttributes))
            {
                e.ReplaceAttributes(e.Attributes().Select(at => new XElement(at.Name.LocalName, at.Value)));              
            }
            doc.Save(fileName);
        }
    }
}
