// File: "LinqXml38"
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


        //LinqXml38�. ��� XML-��������. ��� ������� ��������, ����� �����, 
        //�������� ��� ���, ������� � ���� ����� �������� ����� ���� ��� �������, 
        //����������� �������� �-� (�����). ��������, ���� �������� ������� ����� ��� root, 
        //�� ������� bb ������� ������, ������������ ������� �������� ����� ��� aa, ������ �������� ��� root-aa-bb. 
        //��������. ��������� ��� �������� ������������������ Descendants ��������� ��������, ������������ �� �������� Parent � Name. 

        public static void Solve()
        {
            Task("LinqXml38");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);

            foreach (var e in doc.Root.Descendants())
            {
                e.Name = e.Parent.Name + "-" + e.Name;
            }
            doc.Save(fileName);
        }
    }
}
