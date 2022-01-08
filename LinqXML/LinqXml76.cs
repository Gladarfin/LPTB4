// File: "LinqXml76"
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

        //LinqXml76�. ��� XML-�������� � ����������� � ������������� �� ������ ������������ �����. ������� �������� ������� ������:
            //<record>
            //  <house>12</house>
            //  <flat>129</flat>
            //  <name>������� �.�.</name>
            //  <debt>1833.32</debt>
            //</record>
        //����� house � ����� ���� (����� �����), flat � ����� �������� (����� �����), 
        //name � ������� � �������� ������ (�������� �� �������� �������� � ���������� �� ������� ����� ��������), 
        //debt � ������ ������������� � ���� �������� �����: ����� ����� � �����, ������� ����� � �������(���������� ���� �� �����������). 
        //��� ���� �������� 144-�����������, ����� 9 ������ � 4 ��������; �� ������ ����� � ������ �������� ������������� �� 4 ��������.
        //������������� ��������, ������� �������� ������� ������ ��������� �������:
            //<debt house = "12" flat="129">
            //  <name>������� �.�.</name>
            //  <value>1833.32</value>
            //</debt>
        //������� ���������� ��������� ������� ������ �� ��������.
        public static void Solve()
        {
            Task("LinqXml76");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Elements().Select(e => new XElement(ns + "debt",
                                                                               new XAttribute("house", e.Element(ns + "house").Value),
                                                                               new XAttribute("flat", e.Element(ns + "flat").Value),
                                                                               new XElement(ns + "name", e.Element(ns + "name").Value),
                                                                               new XElement(ns + "value", e.Element(ns + "debt").Value))));
            doc.Save(fileName);
        }
    }
}
