// File: "LinqXml33"
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

        //LinqXml33°. Дан XML-документ. Для каждого элемента первого уровня, 
        //имеющего атрибуты, добавить в конец его дочерних узлов элемент 
        //с именем attr и атрибутами, совпадающими с атрибутами обрабатываемого
        //элемента первого уровня, после чего удалить все атрибуты у обрабатываемого элемента. 
        //Добавленный элемент attr должен быть представлен в виде комбинированного тега.
        //Указание.Использовать метод ReplaceAttributes, указав в качестве параметра новый дочерний элемент.
        public static void Solve()
        {
            Task("LinqXml33");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);

            foreach (var e in doc.Root.Elements().Where(el => el.HasAttributes))
            {
                e.ReplaceAttributes(new XElement("attr", e.Attributes()));
            }
            doc.Save(fileName);
        }
    }
}
