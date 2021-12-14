// File: "LinqXml22"
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
        //LinqXml22�. ��� XML-�������� � ������ S.
        //� ������ �������� ��� ������ �� ���������� ��������� ��������� ���������.������� �� ��������� ��� �������� � ������ S. 
        public static void Solve()
        {
            Task("LinqXml22");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            string s = GetString();
            doc.Root.Descendants(s).Remove();
            doc.Save(fileName);
        }
    }
}
