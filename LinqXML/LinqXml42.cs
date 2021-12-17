// File: "LinqXml42"
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

        //LinqXml42�. ��� XML-��������, � ������� �������� ���� ��������� �������� ���������� ��������������� ������������ �����.
        //�������� � ������� �������� ������� ������, ����������� �������� ��������, �������� ������� sum, 
        //���������� ��������� ������������� ����� ��������� ���� �������� ��������� ������� ��������. ����� ����������� �� ���� ������� ������, 
        //���������� ���� �� ������������. ���� �� ���� �� �������� ��������� �� �������� ���������, �� ������� sum ������ ����� �������� 0. 
        public static void Solve()
        {
            Task("LinqXml42");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            foreach (var e in doc.Root.Elements().Where(el => el.Elements().Count() > 0))
            {
                e.Add(new XElement("sum", Math.Round(e.Elements()
                                                      .Attributes()
                                                      .Select(at => (double)at)
                                                      .Sum(),2)));
            }
            doc.Save(fileName);
        }
    }
}
