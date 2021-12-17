// File: "LinqXml49"
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

        //LinqXml49�. ��� XML-�������� � ������ S. � ������ �������� ��� ������ �� ��������� ��������� ���������;
        //��������, ��� ��� �������� � ��������� ������ �������� ������������� ���������� ���������� ������� 
        //(� ����, �����, ������� � ��������) � �������, �������� � ��������� XML. �������� � �������� ������� 
        //������� total-time, ������ ���������� �������� ����������� �������, ��������� �� ���� ��������� S ��������� ���������.

        //��������.������������ ���������� ������� XAttribute � ���� TimeSpan.��� ������������ ���������� ����������� ������� 
        //������������ ����� Aggregate � �������� �+� ��� ���� TimeSpan.
        public static void Solve()
        {
            Task("LinqXml49");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            string s = GetString();
            doc.Root.Add(new XAttribute("total-time", doc.Descendants().Attributes(s)
                                                                       .Select(e => (TimeSpan)e)
                                                                       .Aggregate(TimeSpan.Zero, (a, e) => a + e)));
            doc.Save(fileName);
        }
    }
}
