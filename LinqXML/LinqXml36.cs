// File: "LinqXml36"
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

        //LinqXml36�. ��� XML-��������.
        //��� ������� �������� ������� ������, �������� ��������, �������� � ����� ������ ��� ��������� 
        //������� node-count �� ���������, ������ ���������� �����-�������� ����� ��������(���� �������). 
        public static void Solve()
        {
            Task("LinqXml36");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            foreach (var e in doc.Root.Elements().Elements().Where(el => el.DescendantNodes().Count() > 0))
            {
                e.Add(new XAttribute("node-count", e.DescendantNodes().Count()));
            }
            doc.Save(fileName);
        }
    }
}
