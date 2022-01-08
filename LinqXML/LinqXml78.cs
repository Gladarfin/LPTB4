// File: "LinqXml78"
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
        // ��� ������� ����� ������ LinqXml �������� ���������
        // �������������� ������ ����������, ������������ � ���������:
        //
        //   Show() � Show(cmt) - ���������� ������ ������������������,
        //     cmt - ��������� �����������;
        //
        //   Show(e => r) � Show(cmt, e => r) - ���������� ������
        //     �������� r, ���������� �� ��������� e ������������������,
        //     cmt - ��������� �����������.

        //LinqXml78�. ��� XML-�������� � ����������� � ������������� �� ������ ������������ �����. 
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml76):
        //<debt house = "12" flat="23">
        //  <name>������ �.�.</name>
        //  <value>1245.64</value>
        //</debt>
        //������������� ��������, �������� ����������� ������ �� ������ ����, 
        //� � �������� ������� ���� � �� ������ ��������.�������� �������� ������� ������ ��������� �������:
        //<house number = "12" >
        //  < entrance number= "1" >
        //    < debt name= "������ �.�." flat= "23" > 1245.64 </ debt >
        //    ...
        //  </entrance>
        //  ...
        //</house>
        //�������� ������� ������ ������ ���� ������������� �� ����������� ������� �����, 
        //� �� �������� �������� � �� ����������� ������� ���������. �������� �������� ������, 
        //������� ������ ��������, ������ ���� ������������� �� �������� ������� ������������� 
        //(��������������, ��� ������� ���� �������������� �������� ����������). ��������, � ������� ����������� ����������, 
        //�� ������������.
        public static void Solve()
        {
            Task("LinqXml78");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Elements().Select(el => new {
                house = int.Parse(el.Attribute("house").Value),
                flat = int.Parse(el.Attribute("flat").Value),
                entrance = (int.Parse(el.Attribute("flat").Value) - 1) / 36 + 1,
                name = el.Element(ns + "name").Value,
                debt = el.Element(ns + "value").Value
            }).OrderBy(n => n.house).ThenBy(e => e.entrance).Show();
            doc.Root.ReplaceNodes(data.GroupBy(hn => hn.house,
                                               (e, h) => new XElement(ns + "house",
                                                             new XAttribute("number", e),
                                                             h.GroupBy(en => en.entrance,
                                                                       (n, ed) => new XElement(ns + "entrance",
                                                                                      new XAttribute("number", n),
                                                                                      ed.Select(d => new XElement(ns + "debt",
                                                                                                         new XAttribute("name", d.name),
                                                                                                         new XAttribute("flat", d.flat),
                                                                                                         d.debt))
                                                                                        .OrderByDescending(d => (double)d))))));
            doc.Save(fileName);                              
        }
    }
}
