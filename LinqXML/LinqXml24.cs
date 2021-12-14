// File: "LinqXml24"
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

        //LinqXml24�. ��� XML-��������. ������� �� ��������� ��� �����������, 
        //���������� ������ ������� ��� ������� ������ (�. �. ������� ����� 
        //������������ ��������� �������� ������� ��� ������� ������� ������). 
        public static void Solve()
        {
            Task("LinqXml24");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            doc.Root.Nodes().OfType<XComment>().Remove();
            doc.Root.Elements().Nodes().OfType<XComment>().Remove();
            doc.Save(fileName);

        }
    }
}
