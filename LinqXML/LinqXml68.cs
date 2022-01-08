// File: "LinqXml68"
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

        //LinqXml68�. ��� XML-�������� � ����������� � ����� ��������������� ������� �� ������. ������� �������� ������� ������:
            //<record>
            //  <company>�����</company>
            //  <street>��.������</street>
            //  <brand>92</brand>
            //  <price>2200</price>
            //</record>
        //����� street � �������� �����, company � �������� ��������(�������� ���� � �������� �� �������� ��������
        //� �������� ����������� ������� XML), brand � ����� �������(����� 92, 95 ��� 98), price � ���� 1 ����� �������
        //� ��������(����� �����). ������ �������� ����� �� ����� ����� ��� �� ������ �����, ���� �� ������ ��� ����� �
        //��� �� �������� ����� �����������.������������� ��������, ������� �������� ������� ������ ��������� �������:
            //<station company = "�����" street= "��.������" >
             //< info >
             // < brand > 92 </ brand >
             // < price > 2200 </ price >
             //</ info >
            //</ station >
        //������� ���������� ��������� ������� ������ �� ��������. 
        public static void Solve()
        {
            Task("LinqXml68");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Elements().Select(el => new XElement(ns + "station",
                                                                      new XAttribute("company", el.Element(ns + "company").Value),
                                                                      new XAttribute("street", el.Element(ns + "street").Value),
                                                                      new XElement(ns + "info",
                                                                          new XElement(ns + "brand", el.Element(ns + "brand").Value),
                                                                          new XElement(ns + "price", el.Element(ns + "price").Value)))));
            doc.Save(fileName);
        }
    }
}
