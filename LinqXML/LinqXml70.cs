// File: "LinqXml70"
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

        //LinqXml70�. ��� XML-�������� � ����������� � ����� ��������������� ������� �� ������. 
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml68):
           //<station brand = "98" price="2850">
           //  <company>�����</company>
           //  <street>��.���������</street>
           //</station>
        //������������� ��������, �������� ����������� ������ �� ��������� ��������, 
        //� � �������� ������ �������� � �� ������ �������.�������� �������� ������� ������ ��������� �������:
            //<company name = "�����" >
            //  < brand value="98">
            //    <price street = "��.���������" > 2850 </ price >
            //    ...
            //  </brand>
            //  ...
            //</company>
        //�������� ������� ������ ������ ���� ������������� � ���������� ������� �������� ��������, 
        //� �� �������� �������� � �� �������� ����� �������.�������� �������� ������, ������� ������ ��������, 
        //������ ���� ������������� � ���������� ������� �������� ����. 
        public static void Solve()
        {
            Task("LinqXml70");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Elements().Select(e => new { 
                                                               name = e.Element(ns + "company").Value,
                                                               brand = int.Parse(e.Attribute("brand").Value),
                                                               street = e.Element(ns + "street").Value,
                                                               price = e.Attribute("price").Value})
                                          .OrderBy(e => e.name).ThenByDescending(e => e.brand).ThenBy(e => e.street).Show();
            doc.Root.ReplaceNodes(data.GroupBy(e => e.name,
                                               (e, c) => new XElement(ns + "company", 
                                                             new XAttribute("name", e),
                                                             c.GroupBy(b => b.brand)
                                                              .Select(br => new XElement(ns + "brand",
                                                                                new XAttribute("value", br.Key),
                                                                                br.Select(el => new XElement(ns + "price",
                                                                                                          new XAttribute("street", el.street),
                                                                                                          el.price)))))));
            doc.Save(fileName);

        }
    }
}
