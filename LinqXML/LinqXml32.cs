// File: "LinqXml32"
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

        //LinqXml32�. ��� XML-�������� � ������ S1 � S2. 
        //� ������ S1 �������� ��� ������ �� ��������� ��������� ���������, 
        //������ S2 �������� ���������� ��� �������� XML. 
        //����� ������ ��������� ������� ������ � ������ S1 �������� ������� � ������ S2. 
        //����������� ������� ������ ��������� ��������� ������� � ������ �������� ������� 
        //������������ �������� (���� ��� ����). ���� ������� S1 �� ����� �������� ���������, 
        //�� ����������� ����� ��� ������� S2 ������ ���� ����������� � ���� ���������������� ����.
        //��������.������������ ����� FirstOrDefault.
        public static void Solve()
        {
            Task("LinqXml32");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            string s1 = GetString();
            string s2 = GetString();
            foreach (var e in doc.Root.Elements().Elements(s1))
            {
                e.AddBeforeSelf(new XElement(s2, e.LastAttribute, e.Elements().FirstOrDefault()));
            }
            doc.Save(fileName);
        }
    }
}
