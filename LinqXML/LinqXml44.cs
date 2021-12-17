// File: "LinqXml44"
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

        //LinqXml44°. Дан XML-документ и строка S. В строке записано имя одного из атрибутов исходного документа; 
        //известно, что все атрибуты с указанным именем содержат текстовое представление вещественного числа. 
        //Для каждого элемента выполнить следующие действия: перебирая всех его потомков, содержащих атрибут S, 
        //найти минимальное значение данного атрибута и записать это значение в новый атрибут min обрабатываемого элемента. 
        //Если ни один из потомков элемента не содержит атрибут S, то атрибут min к этому элементу не добавлять.

        //Указание.Использовать приведение атрибута Attribute(S) к Nullable-типу double?; 
        //если атрибут с указанным именем отсутствует, то будет возвращено значение null. 
        //Для создания нового атрибута с найденным минимальным значением использовать метод SetAttributeValue; 
        //в случае значения null атрибут создан не будет.
        public static void Solve()
        {
            Task("LinqXml44");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            string s = GetString();

            foreach (var e in doc.Descendants().Where(d => d.Descendants().Attributes(s).Count() > 0))
            {
                e.SetAttributeValue("min", e.Descendants()
                                            .Attributes(s)
                                            .Select(at => (double?)at).Min());
            }
            doc.Save(fileName);
        }
    }
}
