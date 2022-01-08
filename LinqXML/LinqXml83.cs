// File: "LinqXml83"
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

        //LinqXml83�. ��� XML-�������� � ����������� �� ������� �������� �� ��������� ���������. ������� �������� ������� ������:
            //<record>
            //  <class>9</class>
            //  <name>��������� �.�.</name>
            //  <subject>������</subject>
            //  <mark>4</mark>
            //</record>
        //����� class � ����� ������(����� ����� �� 7 �� 11), name � ������� � �������� ���������(�������� �� �������� ��������
        //� ���������� �� ������� ����� ��������), subject � �������� ��������, �� ���������� ��������, mark � ������(����� ����� 
        //� ��������� �� 2 �� 5). ������ �������������(� ����������� �������� � ����������) ����� �������� ���.������������� ��������,
        //������� �������� ������� ������ ��������� �������:
            //<mark subject = "������" >
            //  < name class="9">��������� �.�.</name>
            //  <value>4</value>
            //</mark>
        // ������� ���������� ��������� ������� ������ �� ��������.
        public static void Solve()
        {
            Task("LinqXml83");
            var fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Elements().Select(el => new XElement(ns + "mark", 
                                                                                new XAttribute("subject", el.Element(ns + "subject").Value),
                                                                                new XElement(ns + "name",
                                                                                             new XAttribute("class", el.Element(ns + "class").Value),
                                                                                             el.Element(ns + "name").Value),
                                                                                new XElement(ns + "value", el.Element(ns + "mark").Value))));
            doc.Save(fileName);

        }
    }
}
