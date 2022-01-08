// File: "LinqXml75"
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

        //LinqXml75�. ��� XML-�������� � ����������� � ����� ��������������� ������� �� ������. 
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml68, �������� �������� � �����, 
        //����������� �������� �������������, ����������� � �������� ���� ��������� ������� ������):
            //<�����_��.������>
            //  <brand>92</brand>
            //  <price>2200</price>
            //</�����_��.������>
        //������������� ��������, ������������ ������ �� ��������� ���� � ������� �������� ������� ������ ��������� �������:
            //<��.������>
            //  <brand98 station-count="0">0</brand98>
            //  <brand95 station-count="0">0</brand95>
            //  <brand92 station-count="3">2255</brand92>
            //</��.������>
        //��� �������� ������� ������ ��������� � ��������� �����, ��� �������� ������� ������ ����� ������� brand,
        //����� �������� ����������� ����� �������.������� station-count ����� ���������� ���, 
        //������������� �� ������ ����� � ������������ ������ ������ �����; ��������� �������� 
        //������� ������ �������� ������� ���� 1 ����� ������� ������ ����� �� ���� ���, ������������� �� ������ �����.
        //������� ���� ��������� �� ��������� �������: ���������� ���� �� ���� ��������/������ �������, 
        //��� �������� �/� ���������� ������������� �������. ���� �� ������ ����� ����������� ���, ������������ ������ ������ �����,
        //�� �������� ���������������� �������� ������� ������ � �������� ��� �������� station-count ������ ���� ����� 0. 
        //�������� ������� ������ ������ ���� ������������� � ���������� ������� �������� ����, � �� �������� �������� 
        //� �� �������� ����� �������. 
        public static void Solve()
        {
            Task("LinqXml75");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            //��������������� ������������������
            var data = doc.Root.Elements().Select(el =>
            {
                string[] s = el.Name.LocalName.Split('_');
                return new
                {
                    company = s[0],
                    street = s[1],
                    //���� ����� �������� ��� � ������ �������� ���� ������ �������� �� namespace + ����� - �������� �� �����
                    brand = "brand" + el.Element("brand").Value,
                    price = int.Parse(el.Element("price").Value)

                };
            }).OrderBy(e => e.street);
            var brands = new string[] { "brand98", "brand95", "brand92" };

            doc.Root.ReplaceNodes(data.GroupBy(st => st.street,
                                 (s, ee) => new XElement(ns + s,
                                                brands.GroupJoin(ee, e1 => e1, e2 => e2.brand,
                                                (e1, e3) => new XElement(ns + e1,
                                                                new XAttribute("station-count", e3.Select(el => el.company).Count()),
                                                                e3.Select(el => el.company).Count() == 0 ? 0 :
                                                                e3.Select(el => el.price).Sum() / e3.Select(el => el.company).Count()
                                                                )))));
            doc.Save(fileName);
        }
    }
}
