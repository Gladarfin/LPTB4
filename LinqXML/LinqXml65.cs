// File: "LinqXml65"
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

        //LinqXml65�. ��� XML-�������� � ����������� � �������� ������-������. 
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml61, 
        //������ ������������� �� ����� ��������; ���� ��������, ���������� ��������� id, 
        //����������� � �������� ���� ��������� ������� ������):
            //<id10>
            //  <info>
            //    <date>2000-05-01T00:00:00</date>
            //    <time>PT5H13M</time>
            //  </info>
            //  ...
            //</id10>
        //������������� ��������, ������������ ������ �� ����� � ������� �������� ������� ������ ��������� �������:
            //<year value = "2000" >
            //  < total - time id="10">860</total-time>
            //  ...
            //</year>
        //�������� �������� ������� ������ ������ ���� ����� ����� ����������������� �������(� �������) 
        //������� � ��������� ����� � ������� ���������� ����.�������� ������� ������ ������ ����
        //������������� �� ����������� ������ ����, �� �������� �������� � �� ����������� ����� ��������. 

        public static void Solve()
        {
            Task("LinqXml65");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Descendants(ns + "date")
                                          .GroupBy(d => ((DateTime)d).Year)
                                          .Select(e => new XElement(ns + "year",
                                                                    new XAttribute("value", e.Key),
                                                                    e.Select(tt => new { 
                                                                                        id = tt.Parent.Parent.Name.LocalName.Substring(2),
                                                                                        time = ((TimeSpan)tt.Parent.Element(ns + "time")).TotalMinutes})
                                                                    .GroupBy(aid => aid.id)
                                                                    .Select(el => new XElement(ns + "total-time",
                                                                                               new XAttribute("id", el.Key),
                                                                                               el.Select(ek => ek.time).Sum()))
                                                                    .OrderBy(t => int.Parse(t.Attribute("id").Value))))
                                          .OrderBy(el => el.Attribute("value").Value));            
            doc.Save(fileName);
        }
    }
}
