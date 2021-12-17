// File: "LinqXml52"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Globalization;

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

        //LinqXml52∞. ƒан XML-документ. — каждым элементом документа св€зываетс€ некотора€ дата, 
        //определ€ема€ номерами года, мес€ца и дн€.  омпоненты этой даты указываютс€ в атрибутах year, month, day.
        //≈сли некоторые из этих атрибутов отсутствуют, то соответствующие компоненты определ€ютс€ по умолчанию: 2000 дл€ года,
        //1 дл€ мес€ца и 10 дл€ дн€. ƒл€ каждого элемента добавить в начало его набора дочерних узлов элемент date 
        //с текстовым представлением даты, св€занной с обрабатываемым элементом (дата записываетс€ в формате, 
        //прин€том в стандарте XML), и удалить имеющиес€ атрибуты, св€занные с компонентами даты. 
        public static void Solve()
        {
            Task("LinqXml52");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            //meh... TODO find a better solution
            foreach (var e in doc.Descendants().Where(el => el.Name.LocalName != "date"))
            {
                var date = DateTime.Parse(string.Format(@"{0}-{1}-{2}", (string)e.Attribute("year") ?? "2000",
                                                                        (string)e.Attribute("month") ?? "01",
                                                                        (string)e.Attribute("day") ?? "10"));
                e.AddFirst(new XElement("date", date));
            }
            doc.Descendants().Attributes().Where(a => a.Name.LocalName == "year" ||
                                                      a.Name.LocalName == "month" ||
                                                      a.Name.LocalName == "day").Remove();
            
            doc.Save(fileName);
            
        }
    }
}
