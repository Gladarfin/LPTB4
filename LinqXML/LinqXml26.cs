// File: "LinqXml26"
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

        //LinqXml26°. Дан XML-документ. Для всех элементов документа удалить все их атрибуты, кроме первого.
        //Указание.В предикате метода Where, отбирающем все атрибуты элемента, кроме первого, использовать 
        //метод PreviousAttribute класса XAttribute.
        public static void Solve()
        {
            Task("LinqXml26");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            doc.Descendants().Attributes().Where(e => e.PreviousAttribute != null).Remove();
            doc.Save(fileName);
        }
    }
}
