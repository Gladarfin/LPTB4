// File: "LinqXml31"
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

        //LinqXml31�. ��� XML-�������� � ������ S1 � S2. 
        //� ������ S1 �������� ��� ������ �� ��������� ��������� ���������, 
        //������ S2 �������� ���������� ��� �������� XML. ����� ������� �������� 
        //������� ������ � ������ S1 �������� ������� � ������ S2. 
        //�������� � ������� ������������ �������� ������ ��������� � ���������� � ��������� ��������������� ��������.
        //��������.��� ������� �������� S1 ������� ����� AddAfterSelf � ����� �����������: ������� S2 � �������������������� Attributes � Nodes �������� S1.
        public static void Solve()
        {
            Task("LinqXml31");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var s1 = GetString();
            var s2 = GetString();
            foreach(var e in doc.Root.Elements(s1))
            {
                e.AddAfterSelf(new XElement(s2, e.Attributes(), e.Nodes()));
            }
            doc.Save(fileName);
        }
    }
}
