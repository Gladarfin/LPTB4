// File: "LinqXml43"
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

        //LinqXml43°. Дан XML-документ, в котором значения всех атрибутов являются текстовыми представлениями вещественных чисел. 
        //Добавить к каждому элементу первого уровня, содержащему дочерние элементы, дочерний элемент max, 
        //содержащий текстовое представление максимального из значений атрибутов всех элементов-потомков данного элемента.
        //Если ни один из элементов-потомков не содержит атрибутов, то элемент max не добавлять.

        //Указание.Для единообразной обработки двух ситуаций(наличие или отсутствие атрибутов у потомков) 
        //можно построить по последовательности атрибутов последовательность числовых значений Nullable-типа double?, 
        //применить к ней метод Max и добавить новый элемент max с помощью метода SetElementValue, указав в качестве второго 
        //результат, возвращенный методом Max.При отсутствии атрибутов у потомков метод Max вернет значение null;
        //в этом случае метод SetElementValue не будет создавать новый элемент.
        public static void Solve()
        {
            Task("LinqXml43");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);

            foreach (var e in doc.Root.Elements().Where(desc => desc.Elements().Count() > 0))
            {
                e.SetElementValue("max", e.Descendants().Attributes().Select(el => (double?)el).Max());
            }

            doc.Save(fileName);
        }
    }
}
