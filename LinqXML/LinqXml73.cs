// File: "LinqXml73"
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

        //LinqXml73�. ��� XML-�������� � ����������� � ����� ��������������� ������� �� ������. 
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml68, ������ ������������� �� ��������� ����; 
        //�������� ���� ����������� � �������� ���� ��������� ������� ������):
            //<��.������>
            //  <company name = "�����" >
            //    < brand > 92 </ brand >
            //    < price > 2200 </ price >
            //  </ company >
            //  ...
            //</��.������>
        //������������� ��������, ������������ ������ �� ��������� �������� � ��������� ���� � ������� �������� ������ � ��� ���,
        //�� ������� ������������ �� ����� ���� ����� �������.�������� �������� ������� ������ ��������� �������:
            //<�����_��.������ brand-count="2">
            //  <b92 price = "2200" />
            //  < b95 price="2450" />
            //</�����_��.������>
        //��� �������� ������� ������ �������� �������� ��������, ����� �������� ������� ������ ������������� � �������� �����; 
        //��� �������� ������� ������ ������ ����� ������� b, ����� �������� ����������� ����� �������.������� brand-count ������
        //��������� ���������� ����� �������, ������������ �� ������ ���. �������� ������� ������ ������ ���� ������������� � ����������
        //������� �������� ��������, � ��� ���������� �������� �������� � � ���������� ������� �������� ����; �� �������� �������� ������
        //���� ������������� �� ����������� ����� �������.

        public static void Solve()
        {
            Task("LinqXml73");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Descendants(ns + "company")
                                          .OrderBy(el => el.Attribute("name").Value)
                                          .ThenBy(el => el.Parent.Name.LocalName)
                                          .GroupBy(cs => (cs.Attribute("name").Value + "_" + cs.Parent.Name.LocalName))
                                          .Where(gc => gc.Count() > 1)
                                          .Select(el => new XElement(ns + el.Key,
                                                            new XAttribute("brand-count", el.Count()),
                                                            el.Select(b => new XElement(ns + ("b" + b.Element(ns + "brand").Value),
                                                                               new XAttribute("price", b.Element(ns + "price").Value)))
                                                              .OrderBy(pr => pr.Attribute("price").Value))));

            doc.Save(fileName);

        }
    }
}
