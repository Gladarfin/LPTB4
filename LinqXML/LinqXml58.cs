// File: "LinqXml58"
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

        //LinqXml58�. ��� XML-�������� � ������ S, ���������� ��������� ������������ ����. 
        //���������� � �������� �������� ������� node, ��������� � ������������� ����, �������� � ������ S,
        //� �������� � ������ ������� ������� ������ ��� ��������: ������� node:count �� ���������, 
        //������ ���������� ��������-����� ��� ������� ��������, � ������� xml:count �� ���������, 
        //������ ���������� ��������-��������� ��� ������� �������� (xml � ������� ������������ ���� XML).

        //��������.������������ �������� Xml ������ XNamespace.
        public static void Solve()
        {
            Task("LinqXml58");
            string fileName = GetString();
            string s = GetString();
            var doc = XDocument.Load(fileName);
            doc.Root.Add(new XAttribute(XNamespace.Xmlns + "node", s));
            foreach (var e in doc.Root.Elements())
            {
                e.Add(new XAttribute((XNamespace)s + "count", e.DescendantNodes().Count()),
                      new XAttribute(XNamespace.Xml + "count", e.Descendants().Count()));
            }
            doc.Save(fileName);
        }
    }
}
