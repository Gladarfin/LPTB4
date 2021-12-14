// File: "LinqXml28"
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

        //LinqXml28�. ��� XML-��������. ������� �������� ��������� ���� ��� ���� ��������� �������� ������. 
        //���� ��������� ���� �������� ������������ �������� ����� ��������, �� ����� ��� �������� �������
        //������ ���� ����������� � ���� ���������������� ����.
        //��������.������������ ����� OfType<XText>.
        public static void Solve()
        {
            Task("LinqXml28");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            doc.Root.Elements().Elements().Elements().Nodes().OfType<XText>().Remove();
            doc.Save(fileName);
        }
    }
}
