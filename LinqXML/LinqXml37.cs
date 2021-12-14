// File: "LinqXml37"
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

        //LinqXml37°. Дан XML-документ. Для каждого элемента второго уровня, имеющего потомков, 
        //добавить к его текстовому содержимому текстовое содержимое всех элементов-потомков, 
        //после чего удалить все его узлы-потомки, кроме дочернего текстового узла.

        //Указание.Использовать свойство Value класса XElement.
        public static void Solve()
        {
            Task("LinqXml37");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);

            foreach (var e in doc.Root.Elements().Elements().Where(e => !e.IsEmpty))
            {
                e.Value = e.Value;
            }
            doc.Save(fileName);
        }
    }
}
