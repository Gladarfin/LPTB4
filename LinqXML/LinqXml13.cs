using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace PT4Tasks
{
    public class MyTask: PT
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

        public static void Solve()
        {
            Task("LinqXml13");

            //LinqXml13�. ��� XML-��������, ���������� ���� �� ���� �������.
            //������� ��� ��������� ����� ���������, �������� � ��������.
            //������� ���� ��������� ������ ��������������� ������� �� ������� ��������� � ��������.
            //��������.������������ ������ SelectMany � Distinct.
            var doc = XDocument.Load(GetString());
            var result = doc.Descendants()
               .Attributes()
               .Select(e => e.Name.LocalName)
               .Distinct();
            Put(result);
        }
    }
}
