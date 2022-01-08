// File: "LinqXml67"
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

        //LinqXml67�. ��� XML-�������� � ����������� � �������� ������-������. 
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml61):
            //<client id = "10" time="PT5H13M">
            //  <year>2000</year>
            //  <month>5</month>
            //</client>
        //������������� ��������, ������������ ������ �� ����� � ������� � ������� �������� ������� ������ ��������� �������:
            //<y2000>
            //  <m1 total-time="0" client-count="0" />
            //  ...
            //  <m5 total-time="956" client-count="3" />
            //  ...
            //</y2000>
        //��� �������� ������� ������ ������ ����� ������� y, ����� �������� ����������� ����� ����;
        //��� �������� ������� ������ ������ ����� ������� m, ����� �������� ����������� ����� ������.
        //������� total-time ������ ��������� ��������� ����������������� ������� (� �������) ���� �������� � ������ ������, 
        //������� client-count � ���������� ��������, ������������ � ���� ������. 
        //������ ������� ������� ������ ������ ��������� �������� ������� ������, ��������������� ���� ������� ����; 
        //���� � �����-���� ������ ������� �� �����������, �� �������� ��� ����� ������ ������ ����� ������� ��������.
        //�������� ������� ������ ������ ���� ������������� �� ����������� ������ ����, �� �������� �������� � �� ����������� 
        //������ ������.

        //��������.��� ������������ ������������ �������������������, ��������� �� ����� ��������, 
        //������������ ��������������� ������������������ Enumerable.Range(1, 12) � ����� GroupJoin.
        public static void Solve()
        {
            Task("LinqXml67");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var months = Enumerable.Range(1, 12);
            var data = doc.Root.Descendants(ns + "client").Select(e => 
                new
                {
                    year = int.Parse(e.Element(ns + "year").Value),
                    month = int.Parse(e.Element(ns + "month").Value),
                    time = ((TimeSpan)e.Attribute("time")).TotalMinutes
                });
            doc.Root.ReplaceNodes(data.OrderBy(y => y.year)
                                      .GroupBy(y => y.year,
                                               (e, el) => new XElement(ns + ("y" + e),
                                                           months.GroupJoin(el, e1 => e1, e2 => e2.month,
                                                                            (e1, ee2) => new XElement(ns + ("m" + e1),
                                                                                          new XAttribute("total-time", ee2.Sum(e3 => e3.time)),
                                                                                             new XAttribute("client-count", ee2.Count()))))));

            doc.Save(fileName);
        }
    }
}
