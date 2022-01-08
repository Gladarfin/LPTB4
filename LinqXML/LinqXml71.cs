// File: "LinqXml71"
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

        //LinqXml71�. ��� XML-�������� � ����������� � ����� ��������������� ������� �� ������. 
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml68):
              //<station street = "��.���������" company="�����">
              //  <info brand = "98" price="2850" />
              //</station>
        //������������� ��������, �������� ����������� ������ �� ������ �������, 
        //� � �������� ������ ����� � �� ����� 1 ����� �������.�������� �������� ������� ������ ��������� �������:
            //<b98>
            //  <p2850>
            //    <info street = "��.���������" company= "�����" />
            //    ...
            //  </p2850>
            //  ...
            //</b98>
        //��� �������� ������� ������ ������ ����� ������� b, ����� �������� ����������� ����� �������;
        //��� �������� ������� ������ ������ ����� ������� p, ����� �������� ����������� ���� 1 ����� �������.
        //�������� ������� ������ ������ ���� ������������� �� �������� ����� �������, � �� �������� �������� � �� �������� ���.
        //�������� �������� ������, ������� ������ ��������, ������ ���� ������������� � ���������� ������� �������� ����,
        //� ��� ���������� ���� � � ���������� ������� �������� ��������.
        public static void Solve()
        {
            Task("LinqXml71");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            //��������������� ������� ������ + ���������� �� ���� ���������
            var data = doc.Root.Elements().Select(e => new
            {
                brand = int.Parse(e.Element(ns + "info").Attribute("brand").Value),
                price = int.Parse(e.Element(ns + "info").Attribute("price").Value),
                street = e.Attribute("street").Value,
                company = e.Attribute("company").Value
            }).OrderByDescending(e => e.brand)
              .ThenByDescending(e => e.price)
              .ThenBy(e => e.street)
              .ThenBy(e => e.company);

            doc.Root.ReplaceNodes(data.GroupBy(b => b.brand,
                                               (br, e) => new XElement(ns + ("b" + br),
                                                           e.GroupBy(p => p.price)
                                                            .Select(pr => new XElement(ns + ("p" + pr.Key),
                                                                          pr.Select(sc => new XElement(ns + "info",
                                                                                           new XAttribute("street",sc.street),
                                                                                           new XAttribute("company", sc.company))))))));
                                                                          
            doc.Save(fileName);
        }
    }
}
