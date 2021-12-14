// File: "LinqXml21"
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

        //LinqXml21�. ��� XML-�������� � ������ S.
        //� ������ �������� ��� ������ �� ���������� ��������� ��������� ���������.
        //������� �� ��������� ��� �������� ������� ������ � ������ S. 
        public static void Solve()
        {
            Task("LinqXml21");
            var docName = GetString();
            var doc = XDocument.Load(docName);
            var s = GetString();
            doc.Root.Elements(s).Remove();
            doc.Save(docName);
            
        }
    }
}
