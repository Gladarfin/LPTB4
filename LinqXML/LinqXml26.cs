// File: "LinqXml26"
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

        //LinqXml26�. ��� XML-��������. ��� ���� ��������� ��������� ������� ��� �� ��������, ����� �������.
        //��������.� ��������� ������ Where, ���������� ��� �������� ��������, ����� �������, ������������ 
        //����� PreviousAttribute ������ XAttribute.
        public static void Solve()
        {
            Task("LinqXml26");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            doc.Descendants().Attributes().Where(e => e.PreviousAttribute != null).Remove();
            doc.Save(fileName);
        }
    }
}
