// File: "LinqXml33"
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

        //LinqXml33�. ��� XML-��������. ��� ������� �������� ������� ������, 
        //�������� ��������, �������� � ����� ��� �������� ����� ������� 
        //� ������ attr � ����������, ������������ � ���������� ���������������
        //�������� ������� ������, ����� ���� ������� ��� �������� � ��������������� ��������. 
        //����������� ������� attr ������ ���� ����������� � ���� ���������������� ����.
        //��������.������������ ����� ReplaceAttributes, ������ � �������� ��������� ����� �������� �������.
        public static void Solve()
        {
            Task("LinqXml33");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);

            foreach (var e in doc.Root.Elements().Where(el => el.HasAttributes))
            {
                e.ReplaceAttributes(new XElement("attr", e.Attributes()));
            }
            doc.Save(fileName);
        }
    }
}
