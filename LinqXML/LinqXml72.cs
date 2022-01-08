// File: "LinqXml72"
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

        //LinqXml72�. ��� XML-�������� � ����������� � ����� ��������������� ������� �� ������. 
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml68,
        //������ ������������� �� ��������� ��������; �������� �������� ����������� � �������� ���� ��������� ������� ������):
            //<�����>
            //  <price street = "��.������" brand="92">2200</price>
            //  ...
            //</�����>
        //������������� ��������, �������� ����������� ������ �� ��������� ����, 
        //� � �������� ������ ����� � �� ������ �������.�������� �������� ������� ������ ��������� �������:
            //<��.������>
            //  <b92>
            //    <min-price company = "�������-�����" > 2050 </ min - price >
            //    ...
            //  </b92>
            //  ...
            //</��.������>
        //��� �������� ������� ������ ��������� � ��������� �����, ��� �������� ������� ������ ������ ����� ������� b,
        //����� �������� ����������� ����� �������.�������� �������� �������� ������ ����� ����������� ���� ������� 
        //������ ����� �� ������ �����, ��� ������� company �������� �������� ��������, �� ��� ������� ������������ ����������� ����.
        //�������� ������� ������ ������ ���� ������������� � ���������� ������� �������� ����, 
        //� �� �������� �������� � �� ����������� ����� �������. ���� ������� ��������� ��������� �������� ������, 
        //������� ������ �������� (��� ��������, ��� �� ����� ����� ������� ��������� ���, 
        //�� ������� ������ ������ ����� ����� ����������� ����), �� ��� �������� ������ ���� �������������
        //� ���������� ������� �������� ��������.
        public static void Solve()
        {
            Task("LinqXml72");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Descendants(ns + "price")
                                          .OrderBy(sn => sn.Attribute("street").Value)
                                     .GroupBy(st => st.Attribute("street").Value,
                                              (s, el) => new XElement(ns + s,
                                                          el.OrderBy(eb => eb.Attribute("brand").Value)
                                                            .GroupBy(br => br.Attribute("brand").Value,
                                                                     (b, co) => new XElement(ns + ("b" + b),
                                                                     co.Select(p => new XElement(ns + "min-price",
                                                                                     new XAttribute("company", p.Parent.Name.LocalName),
                                                                                     p.Value))
                                                                       .Where(l => l.Value == co.Min(pm => pm.Value))
                                                                       .OrderBy(pr => pr.Value)
                                                                       .ThenBy(cn => cn.Attribute("company").Value))))));
            doc.Save(fileName);
        }
    }
}
