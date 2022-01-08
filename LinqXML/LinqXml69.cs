// File: "LinqXml69"
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

        //LinqXml69�. ��� XML-�������� � ����������� � ����� ��������������� ������� �� ������. 
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml68):
            //<station company = "�����" >
            //  < info street="��.������">
            //    <brand>92</brand>
            //    <price>2200</price>
            //  </info>
            //</station>
        //������������� ��������, ������� �������� ������� ������ ��������� �������:
            //<b92 company = "�����" street="��.������" price="2200" />
        //��� �������� ������ ����� ������� b, ����� �������� ����������� ����� �������.
        //�������� �������������� ���������������� ������ � ������ ���� ������������� �� ����������� ����� �������, 
        //��� ���������� ����� � � ���������� ������� �������� ��������, � ��� ���������� �������� � � ���������� ������� �������� ����.
        public static void Solve()
        {
            Task("LinqXml69");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Elements().OrderBy(e => e.Descendants(ns + "brand").First().Value)
                                                     .ThenBy(e => e.Attribute("company").Value)
                                                     .ThenBy(e => e.Descendants(ns + "info").First().Attribute("street").Value)
                                     .Select(el => new XElement(ns + ("b" + el.Descendants(ns + "brand").First().Value),
                                                                       new XAttribute("company", el.Attribute("company").Value),
                                                                       new XAttribute("street", el.Descendants(ns + "info").First().Attribute("street").Value),
                                                                       new XAttribute("price", el.Descendants(ns + "price").First().Value))));
            doc.Save(fileName);
        }
    }
}
