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
            Task("LinqXml11");
            //LinqXml11�. ��� XML-��������.����� ��� ��������� ����� ��� ��������� � ������� ������ 
            //��������� ��� ������ � ������ ��� ��������� � ��������.����� ��������� ��������
            //� ������� �� ������� ���������.
            //��������.������������ ����� GroupBy.

            var doc = XDocument.Load(GetString());
            var result = doc.Descendants()
                            .GroupBy(e => e.Name.LocalName)
                            .Select(j => new { elemName = j.Key, count = j.Count() });
            foreach (var elem in result)
                Put(elem.elemName, elem.count);                   
        }
    }
}
