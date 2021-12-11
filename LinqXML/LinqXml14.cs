// File: "LinqXml14"
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
            //LinqXml14 ��� XML-��������. ����� �������� ������� ������, 
            //������� �������� ��������� ����, � ������� ���������� ��������� ���������, 
            //� ����� ��� ������� ���������� �������� � �������� ��� ��������� ���������� ����. 
            //������� ������ ��������� ������ ��������������� ������� �� ���������� � ���������. 

            Task("LinqXml14");
            var doc = XDocument.Load(GetString());
            var result = doc.Root.Elements().Elements()
                            .Nodes()
                            .OfType<XText>()
                            .Where(e => e.Value != "");
            Put(result.Count());
            foreach(var e in result)
            {
                Put(e.Parent.Name.LocalName, e.Value);
            }

        }
    }
}
