// File: "LinqXml28"
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

        //LinqXml28°. Дан XML-документ. Удалить дочерние текстовые узлы для всех элементов третьего уровня. 
        //Если текстовый узел является единственным дочерним узлом элемента, то после его удаления элемент
        //должен быть представлен в виде комбинированного тега.
        //Указание.Использовать метод OfType<XText>.
        public static void Solve()
        {
            Task("LinqXml28");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            doc.Root.Elements().Elements().Elements().Nodes().OfType<XText>().Remove();
            doc.Save(fileName);
        }
    }
}
