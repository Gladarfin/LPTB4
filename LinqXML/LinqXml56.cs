// File: "LinqXml56"
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

        //LinqXml56�. ��� XML-��������. � �������� �������� ��������� ��������� ������������ ������� ������������ ����. 
        //�������� ������ ��������� ����� ���� ��������� ������� ������ � ������� �� ���� ��������� ����������� ��������
        //����������� ���� (���� ����� ����������� �������). 
        public static void Solve()
        {
            Task("LinqXml56");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Attributes().Last();
            foreach (var e in doc.Root.Elements())
            {
                e.Attributes("xmlns").Remove();
                e.Name = (XNamespace)ns.Value + e.Name.LocalName;
            }
            doc.Save(fileName);

        }
    }
}
