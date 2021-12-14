// File: "LinqXml23"
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
        //LinqXml23�. ��� XML-��������. ������� �� ��������� ��� ���������� ���������.
        //��������.��� ��������� ������������������ ���� ���������� ��������� ��������������� ������� OfType<XProcessingInstruction>.
        public static void Solve()
        {
            Task("LinqXml23");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            doc.Root.DescendantNodes().OfType<XProcessingInstruction>().Remove();
            doc.Save(fileName);
        }
    }
}
