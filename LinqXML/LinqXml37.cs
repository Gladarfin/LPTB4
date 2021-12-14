// File: "LinqXml37"
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

        //LinqXml37�. ��� XML-��������. ��� ������� �������� ������� ������, �������� ��������, 
        //�������� � ��� ���������� ����������� ��������� ���������� ���� ���������-��������, 
        //����� ���� ������� ��� ��� ����-�������, ����� ��������� ���������� ����.

        //��������.������������ �������� Value ������ XElement.
        public static void Solve()
        {
            Task("LinqXml37");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);

            foreach (var e in doc.Root.Elements().Elements().Where(e => !e.IsEmpty))
            {
                e.Value = e.Value;
            }
            doc.Save(fileName);
        }
    }
}
