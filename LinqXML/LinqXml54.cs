// File: "LinqXml54"
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

        //LinqXml54�. ��� XML-��������, � �������� �������� ������� �, ��������, 
        //�����-���� ������ �������� ����� �������� ������������ ����. 
        //������� � ������������� ���� ��������� �������� ��� �������� ������� � ������� ������; 
        //��� ��������� ����� ������� ������� �������� �� ������� ������������ ����. 
        public static void Solve()
        {
            Task("LinqXml54");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            foreach (var e in doc.Root.Descendants().Where(el => el.Ancestors().Count() <= 2))
            {
                e.Attributes("xmlns").Remove();
                e.Name = doc.Root.GetDefaultNamespace() + e.Name.LocalName;
            }
            doc.Save(fileName);

        }
    }
}
