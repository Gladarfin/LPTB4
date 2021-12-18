// File: "LinqXml53"
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


        //LinqXml53�. ��� XML-��������. � ������ �������� ������� ������ ���������� ������������ ����,
        //������������������ �� ��� ��� ��������-�������. ��� ������� �������� ������� ������ �������� 
        //� ����� ��� ������ �������� ����� ������� � ������ namespace � ���������, ������ ������������ 
        //���� ��������������� �������� ������� ������ (������������ ���� ������������ �������� ������
        //��������� � ������������� ���� ��� ������������� ��������). 
        public static void Solve()
        {
            Task("LinqXml53");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            foreach (var e in doc.Root.Elements())
            {
                e.Add(new XElement(e.GetDefaultNamespace() + "namespace", e.GetDefaultNamespace()));
            }
            doc.Save(fileName);
        }
    }
}
