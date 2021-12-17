// File: "LinqXml45"
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

        //LinqXml45�. ��� XML-��������. ��� ������� ��������, �������� ��������, �������� � ������ ��� ������ 
        //�������� ����� ������� � ������ odd-attr-count � ���������� ���������, ������ true, ���� ���������
        //���������� ��������� ������� �������� � ���� ��� ���������-�������� �������� ��������, � false � ��������� ������.

        //��������.� �������� ��������� ������������ XElement, ������������� �������� ��������, ������� ������������ ���������� ���������; 
        //��� �������� ���������� �������� ���������� ��������� � ������������ �� ���������� XML.
        public static void Solve()
        {
            Task("LinqXml45");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);

            foreach (var e in doc.Descendants().Where(el => el.Attributes().Count() > 0))
            {
                e.AddFirst(new XElement("odd-attr-count", e.DescendantsAndSelf()
                                                           .Attributes()
                                                           .Count() % 2 != 0));
            }

            doc.Save(fileName);
        }
    }
}
