// File: "LinqXml66"
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

        //LinqXml66�. ��� XML-�������� � ����������� � �������� ������-������. 
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml61, ������ ������������� �� ����� ��������):
            //<client id = "10" >
            //  < info date="2000-05-01T00:00:00" time="PT5H13M" />
            //  ...
            //</client>
        //������������� ��������, ������������ ������ �� ����� � ������� � ������� �������� ������ � ��� �������, 
        //� ������� �������� ������� �� ����� ���� ��������.�������� �������� ������� ������ ��������� �������:
        //<d2000-5 total-time="956" client-count="3">
        //  <id10 time = "313" />
        //  ...
        //</d2000-5>
        //��� �������� ������� ������ ������ ����� ������� d, ����� �������� ����������� ����� ���� �, ����� �����, 
        //����� ������(���������� ���� �� ������������). ��� �������� ������� ������ ������ ����� ������� id, 
        //����� �������� ����������� ��� �������.������� total-time ������ ��������� ��������� ����������������� ������� (� �������)
        //���� �������� � ������ ������, ������� client-count � ���������� ��������, ������������ � ���� ������. 
        //������� time ��� ��������� ������� ������ ������ ��������� ����������������� ������� (� �������) ������� � ��������� �����
        //� ������ ������. �������� ������� ������ ������ ���� ������������� �� ����������� ������ ����, � ��� ���������� ������� ����
        //� �� ����������� ������ ������; �� �������� �������� ������ ���� ������������� �� ����������� ����� ��������.

        public static void Solve()
        {
            Task("LinqXml66");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Descendants(ns + "info")
                                          .OrderBy(el => ((DateTime)el.Attribute("date")).Year)
                                          .ThenBy(el => ((DateTime)el.Attribute("date")).Month)
                                          .GroupBy(ym => ("d" + ((DateTime)ym.Attribute("date")).Year + "-" + ((DateTime)ym.Attribute("date")).Month))
                                          .Where(ge => ge.Count() > 2)
                                          .Select(e => new XElement(ns + e.Key,
                                                                    new XAttribute("total-time",
                                                                                   e.Select(tt => ((TimeSpan)tt.Attribute("time")).TotalMinutes)
                                                                                    .Sum()),
                                                                    new XAttribute("client-count",
                                                                                   e.Where(cc => int.Parse(e.Key.Substring(6)) == ((DateTime)cc.Attribute("date")).Month)
                                                                                    .Select(cl => cl.Parent.Attribute("id"))
                                                                                    .Count()),
                                                                    e.OrderBy(id => int.Parse(id.Parent.Attribute("id").Value))
                                                                     .Select(id => new XElement(ns + "id" + id.Parent.Attribute("id").Value,
                                                                                                new XAttribute("time", ((TimeSpan)id.Attribute("time")).TotalMinutes)))
                                                                     )));
            doc.Save(fileName);

        }
    }
}
