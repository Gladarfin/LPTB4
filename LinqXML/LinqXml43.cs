// File: "LinqXml43"
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

        //LinqXml43�. ��� XML-��������, � ������� �������� ���� ��������� �������� ���������� ��������������� ������������ �����. 
        //�������� � ������� �������� ������� ������, ����������� �������� ��������, �������� ������� max, 
        //���������� ��������� ������������� ������������� �� �������� ��������� ���� ���������-�������� ������� ��������.
        //���� �� ���� �� ���������-�������� �� �������� ���������, �� ������� max �� ���������.

        //��������.��� ������������� ��������� ���� ��������(������� ��� ���������� ��������� � ��������) 
        //����� ��������� �� ������������������ ��������� ������������������ �������� �������� Nullable-���� double?, 
        //��������� � ��� ����� Max � �������� ����� ������� max � ������� ������ SetElementValue, ������ � �������� ������� 
        //���������, ������������ ������� Max.��� ���������� ��������� � �������� ����� Max ������ �������� null;
        //� ���� ������ ����� SetElementValue �� ����� ��������� ����� �������.
        public static void Solve()
        {
            Task("LinqXml43");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);

            foreach (var e in doc.Root.Elements().Where(desc => desc.Elements().Count() > 0))
            {
                e.SetElementValue("max", e.Descendants().Attributes().Select(el => (double?)el).Max());
            }

            doc.Save(fileName);
        }
    }
}
