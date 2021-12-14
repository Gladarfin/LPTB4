// File: "LinqXml35"
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

        //LinqXml35�. ��� XML-��������. ��� ������� �������� ������� ������ �������� 
        //� ����� ������ ��� ��������� ������� child-count �� ���������, ������ ���������� 
        //���� �������� ����� ����� ��������. ���� ������� �� ����� �������� �����, 
        //�� ������� child-count ������ ����� �������� 0. 
        public static void Solve()
        {
            Task("LinqXml35");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            foreach (var el in doc.Root.Elements().Elements())
            {
                el.Add(new XAttribute("child-count", el.Nodes().Count()));
            }
            doc.Save(fileName);
        }
    }
}
