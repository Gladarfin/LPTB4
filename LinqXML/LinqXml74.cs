// File: "LinqXml74"
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

        //LinqXml74�. ��� XML-�������� � ����������� � ����� ��������������� ������� �� ������. 
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml68, ����� �������, 
        //���������� ��������� brand, ����������� � �������� ���� ��������� ������� ������; 
        //������� station �������� �������� ����� � ��������, ����������� �������� �������������):
            //<brand92 station = "��.������_�����" price="2200" />
        //������������� ��������, ������������ ������ �� ��������� �������� � ������� �������� ������� ������ ��������� �������:
            //<�����>
            //  <��.������� brand92 = "0" brand95="0" brand98="0" />
            //  <��.������ brand92 = "2200" brand95="2450" brand98="0" />
            //  ...
            //</�����>
        //��� �������� ������� ������ ��������� � ��������� ��������, ��� �������� ������� ������ ��������� � ��������� �����.
        //�������� ��������� ������� ������ ����� ������� brand, ����� �������� ����������� ����� �������; �� ��������� ��������
        //���� 1 ����� ������� ��������� ����� ��� ����� 0, ���� �� ������ ��� ������ ��������� ����� �� ������������.
        //��� ������ �������� ������ ���������� ���������� �� ������ �����, ��������� � �������� ���������, 
        //���� ���� �� ���� ����� ����������� ��� ������ �������� (� ���� ������ �������� ���� ��������� brand ������ ���� ����� 0). 
        //�������� ������� ������ ������ ���� ������������� � ���������� ������� �������� ��������,
        //� �� �������� �������� � � ���������� ������� �������� ����.

        public static void Solve()
        {
            Task("LinqXml74");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Descendants(ns + "company")
                               .Select(el => { string[] s = el.Attribute("station").Value.Split('_');
                                                 return new
                                                 {
                                                     company = s[1],
                                                     street = s[0],
                                                     brand = el.Parent.Name.LocalName,
                                                     price = int.Parse(el.Attribute("price").Value)
                                                 };
                                             }).OrderBy(el => el.company);
            var brands = new string[] { "brand92", "brand95", "brand98"};
            var streets = doc.Root.Descendants(ns + "company").Select(el => el.Attribute("station").Value.Split('_')[0]).Distinct().OrderBy(e => e);
            doc.Root.ReplaceNodes(data.GroupBy(cn => cn.company,
                                               (c, el) => new XElement(ns + c,
                                               streets.GroupJoin(el, e1 => e1, e2 => e2.street,
                                               (e1, ee2) => new XElement(ns + e1,
                                                                         brands.GroupJoin(ee2, ee1 => ee1, e2 => e2.brand,
                                                                         (ee1, e3) => new XAttribute(ee1, e3.Select(l => l.price).Sum())))))));
            doc.Save(fileName);
        }
    }
}
