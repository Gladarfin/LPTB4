// File: "LinqXml15"
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

        public static void Solve()
        {
            Task("LinqXml15");
            //LinqXml15 ��� XML-��������, ���������� ���� �� ���� ������� ������� ������. 
            //��� ������� �������� ������� ������ ����� ���������� ��� ��������, 
            //������� �� ����� ���� ���������, � ������� ��� �������� ������� ������ 
            //� ��������� ���������� ��� ��������. �������� �������� � ���������� ������� 
            //�� ����, � ��� ���������� ���� � � ������� ����������� ���������� ���������� ��������. 

            var doc = XDocument.Load(GetString());
            var result = doc.Element("root").Elements()
                            .Select(e => new { elemName = e.Name.LocalName,
                                               count = e.Descendants()
                                                        .Where(attr => attr.Attributes().Count() >= 2).Count() })
                            .OrderBy(e => e.elemName)
                            .ThenBy(e => e.count);                          
            
            foreach (var e in result)
            {
                Put(e.elemName, e.count);
            }

        }
    }
}
