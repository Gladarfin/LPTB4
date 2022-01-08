// File: "LinqXml61"
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

        //LinqXml61�. ��� XML-�������� � ����������� � �������� ������-������. ������� �������� ������� ������:
        //<record>
        //  <id>10</id>
        //  <date>2000-05-01T00:00:00</date>
        //  <time>PT5H13M</time>
        //</record>
        //
        //����� id � ��� �������(����� �����), date � ���� � ����������� � ���� � ������, 
        //time � ����������������� �������(� ����� � �������) ������� ������� � ������� ���������� ������.
        //������������� ��������, ������� �������� ������� ������ ��������� �������:
        //<time id = "10" year= "2000" month= "5" > PT5H13M </ time >
        //
        //������� ���������� ��������� ������� ������ �� ��������. 

        public static void Solve()
        {
            Task("LinqXml61");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Elements().Select(el => new XElement(ns + "time",
                                                                   new XAttribute("id", el.Element(ns + "id").Value),
                                                                   new XAttribute("year", ((DateTime)el.Element(ns + "date")).Year),
                                                                   new XAttribute("month", ((DateTime)el.Element(ns + "date")).Month),
                                                                   el.Element(ns + "time").Value)));
            doc.Save(fileName);
        }
    }
}
