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
            Task("LinqXml12");
            //LinqXml12�. ��� XML-��������, ���������� ���� �� ���� ������� ������� ������.
            //����� ��� ��������� ����� ��������� ������� ������ � ������� ������ ��������� 
            //��� ������ � ������ ��� ��������� � �������� � �������� ����� �������� ������� ������.
            //����� ��������� �������� � ���������� �������. 
            var doc = XDocument.Load(GetString());
            var result = doc.Element("root").Elements()
                                            .GroupBy(e => e.Name.LocalName)
                                            .Select(e => new { elemName = e.Key, count = e.Count() }).OrderBy(elem => elem.elemName);
            foreach (var elem in result)
                Put(elem.elemName, elem.count);
        }
    }
}
