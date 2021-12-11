// File: "LinqXml16"
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

        //LinqXml16�. ��� XML-��������, ���������� ���� �� ���� ������� ������� ������. 
        //��� ������� �������� ������� ������ ����� ��������� ���������� ��������� � ��� ���������-�������� ������� ������ 
        //(�. �. ���������, ���������� ��������� ���������� ��� �������� ���������) � ������� ��������� ���������� ��������� � ��� ��������. 
        //�������� �������� � ������� �������� ���������� ���������� ���������, � ��� ���������� ���������� ��������� � � ���������� ������� ����. 

        public static void Solve()
        {
            Task("LinqXml16");
            var doc = XDocument.Load(GetString());
            var result = doc.Root.Elements()
                            .Select(elem => new
                            {
                                attrCount = elem.Elements().Descendants().Attributes().Count(),
                                elemName = elem.Name.LocalName
                            }).OrderByDescending(e => e.attrCount).ThenBy(e => e.elemName);

            foreach (var e in result)
            {
                Put(e.attrCount, e.elemName);
            }
        }
    }
}
