// File: "LinqXml77"
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

        //LinqXml77�. ��� XML-�������� � ����������� � ������������� �� ������ ������������ �����. 
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml76):
            //<debt house = "12" flat="129" name="������� �.�.">1833.32</debt>
        //������������� ��������, ������� �������� ������� ������ ��������� �������:
            //<address12-129 name="������� �.�." debt="1833.32" />
        //��� �������� ������ ����� ������� address, ����� �������� ����������� ����� ���� �, ����� �����, ����� ��������.
        //�������� �������������� ���������������� ������ � ������ ���� ������������� �� ����������� ������� �����, 
        //� ��� ���������� ������� ����� � �� ����������� ������� �������.

        public static void Solve()
        {
            Task("LinqXml77");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Elements().Select(el => new { 
                                                                house = int.Parse(el.Attribute("house").Value),
                                                                flat = int.Parse(el.Attribute("flat").Value),
                                                                name = el.Attribute("name").Value,
                                                                debt = el.Value
                                                             })
                                          .OrderBy(h => h.house).ThenBy(f => f.flat);

            doc.Root.ReplaceNodes(data.Select(el => new XElement(ns + ("address" + el.house +"-"+ el.flat),
                                                                 new XAttribute("name", el.name),
                                                                 new XAttribute("debt", el.debt))));
            doc.Save(fileName);
        }
    }
}
