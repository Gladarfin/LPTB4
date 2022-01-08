// File: "LinqXml64"
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

        //LinqXml64�. ��� XML-�������� � ����������� � �������� ������-������.
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml61):
            //<client id = "10" >
            //  < date > 2000 - 05 - 01T00:00:00</date>
            //  <time>PT5H13M</time>
            //</client>
            //
        //������������� ��������, ������������ ������ �� �����, � � �������� ������� ���� � �� �������.
        //�������� �������� ������� ������ ��������� �������:
            //
            //<y2000>
            //  <m5>
            //    <client id = "10" time= "313" />
            //    ...
            //  </m5>
            //  ...
            //</y2000>
        //��� �������� ������� ������ ������ ����� ������� y, ����� �������� ����������� ����� ����; 
        //��� �������� ������� ������ ������ ����� ������� m, ����� �������� ����������� ����� ������.
        //������� time ������ ��������� ����������������� ������� � �������.�������� ������� ������ ������ 
        //���� ������������� �� �������� ������ ����, �� �������� �������� � �� ����������� ������ ������. 
        //�������� �������� ������, ������� ������ ��������, ������ ���� ������������� �� ����������� ����� ��������.
        public static void Solve()
        {
            Task("LinqXml64");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            //��������������� ������������������ ������ 
            var data = doc.Root.Elements().Select(el => new
            {
                year = ((DateTime)el.Element(ns + "date")).Year,
                month = ((DateTime)el.Element(ns + "date")).Month,
                time = ((TimeSpan)el.Element(ns + "time")).TotalMinutes,
                client = el.Attribute("id").Value
            }).OrderByDescending(e => e.year).ThenBy(e => e.month);

            doc.Root.ReplaceNodes(data.GroupBy(el => el.year,
                                               (y,m) => new XElement(ns + ("y" + y),
                                                                     m.GroupBy(e => e.month)
                                                                      .Select(elem => new XElement(ns + ("m" + elem.Key),
                                                                                                   elem.Select(mm =>
                                                                                                   new XElement(ns + "client",
                                                                                                                new XAttribute("id", mm.client),
                                                                                                                new XAttribute("time", mm.time)))
                                                                                                                .OrderBy(id => int.Parse(id.Attribute("id").Value))
                                                                                                  )))));
            doc.Save(fileName);
        }
    }
}
