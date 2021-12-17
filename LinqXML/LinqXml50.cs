// File: "LinqXml50"
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

        //LinqXml50�. ��� XML-��������. � ������ ��������� ��������� ����������� ��������� ���������� ������� 
        //(� ����, �����, ������� � ��������). ���� ���������� ���� ���� ����������� � �������� time ������� �������� 
        //(� �������, �������� � ��������� XML), ����, ���� ������ ������� �����������, ��������� ������ ������ ���. 
        //�������� � ������ ������ �������� ����� ��������� �������� ������� total-time �� ���������, ������ ���������� 
        //�������� ����������� �������, ��������� �� ����� ���������� ������� ������.

        //��������.������������ ���������� ������� XAttribute � Nullable-���� TimeSpan? � �������� ?? ����� C#
        //(�������� �������� If ����� VB.NET). 
        public static void Solve()
        {
            Task("LinqXml50");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            doc.Root.AddFirst(new XElement("total-time", doc.Root.Elements().Select(e => (TimeSpan?)e.Attribute("time") ?? 
                                                                                          new TimeSpan(24, 0, 0))
                                                                            .Aggregate(TimeSpan.Zero, (a, e) => a + e)));
            doc.Save(fileName);
        }
    }
}
