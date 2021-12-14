// File: "LinqXml25"
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
        //LinqXml25�. ��� XML-��������. ��� ���� ��������� ������� � ������� ������, 
        //������� ����� ������ ��������, ������� ��� �� ��������. 
        public static void Solve()
        {
            Task("LinqXml25");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            doc.Root.Elements().Attributes().Where(e => e.Parent.Attributes().Count() > 1).Remove();
            doc.Root.Elements().Elements().Attributes().Where(e => e.Parent.Attributes().Count() > 1).Remove();
            doc.Save(fileName);
        }
    }
}
