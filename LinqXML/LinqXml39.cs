// File: "LinqXml39"
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


        //LinqXml39�. ��� XML-��������. ��� ������� ��������, ����� �����, 
        //�������� ��� ���, ������� � ���� ����� �������� ��� ��� ������������� ��������, 
        //����������� �������� �-� (�����). ��������, ������� cc �������� ������, 
        //������������ ������� �������� ����� ��� bb, ������ �������� ��� bb-cc.
        //��������.������������ ������� ������������������ Descendants ��������� �������� � �������� �������(��������� ����� Reverse). 
        public static void Solve()
        {
            Task("LinqXml39");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            foreach (var e in doc.Root.Descendants().Reverse())
            {
                e.Name = e.Parent.Name + "-" + e.Name;
            }
            doc.Save(fileName);
        }
    }
}
