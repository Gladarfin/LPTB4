// File: "LinqXml40"
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

        //LinqXml40�. ��� XML-��������. �������� ����� ��������� ���� ���������, 
        //������� ����� � ��������� ����� �������� ��� ����������� ��� ��������, ����������� �������� �-� (�����).
        //��������.��� ��� �������� Name ������ XAttribute �������� ������ ��� ������, 
        //������� ������������ ����� ������������������ ��������� � ���������� ������� � ����������
        //(�������� ����� Select � ������������������ Attributes), ����� ���� ������� �� � �������� ��������� ������ ReplaceAttributes.
        public static void Solve()
        {
            Task("LinqXml40");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);

            foreach (var e in doc.Descendants())
            {
                e.ReplaceAttributes(e.Attributes()
                                     .Select(attr => new XAttribute(e.Name.LocalName + "-" + attr.Name.LocalName, 
                                                                    attr.Value)));
            }
            doc.Save(fileName);
        }
    }
}
