// File: "LinqXml29"
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

        //LinqXml29�. ��� XML-��������. ������� �� ��������� ��� �������� ������� � ������� ������, �� ���������� �������� �����. 
        public static void Solve()
        {
            Task("LinqXml29");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            doc.Root.Elements().Elements().Where(e => e.Nodes().Count() == 0).Remove();
            doc.Root.Elements().Where(e => e.Nodes().Count() == 0).Remove();
            doc.Save(fileName);
        }
    }
}
