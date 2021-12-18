// File: "LinqXml57"
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

        //LinqXml57�. ��� XML-�������� � ������ S1 � S2, ���������� ��������� ������������ ����.
        //������� � ��������� ����������� �������� ����������� ���� � ���������� � �������� �������� 
        //��� �������� ����������� ����: ������� x, ��������� � S1, � ������� y, ��������� � S2. 
        //�������� ��������� x �������� �������� � ������� ������, � ��������� y � �������� ����������� �������. 
        public static void Solve()
        {
            Task("LinqXml57");
            string fileName = GetString();
            string s1 = GetString();
            string s2 = GetString();
            var doc = XDocument.Load(fileName);
            doc.Root.Add(new XAttribute(XNamespace.Xmlns + "x", s1),
                         new XAttribute(XNamespace.Xmlns + "y", s2));
            foreach (var e in doc.Descendants())
            {
                XNamespace newNamespace = e.Ancestors().Count() <= 1 ? s1 : s2;
                e.Name = newNamespace + e.Name.LocalName;
            }
            doc.Descendants().Attributes("xmlns").Remove();
            doc.Save(fileName);

        }
    }
}
