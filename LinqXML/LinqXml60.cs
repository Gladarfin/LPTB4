// File: "LinqXml60"
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

        //LinqXml60�. ��� XML-��������, �������� ������� �������� �������� ����������� ���� ��������� ����������� ���� � ������� x � y. 
        //��� �������� ������������ ����� � ������ ��������� ��������� (� ��������� �������� �����������). 
        //������� ����������� �������� y � ��� ���� ���������, ���������� ���� ���������, �������� ��� �� ������� x, 
        //� ��� ���� ���������, ���������� ��������� x, �������� ��� �� ������� xml ������������ ���� XML. 
        public static void Solve()
        {
            Task("LinqXml60");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var x = doc.Root.Attributes().Last().PreviousAttribute;
            var y = doc.Root.Attributes().Last();
            doc.Root.Attributes().Last().Remove();
            foreach (var e in doc.Root.Descendants().Where(el => el.Name.Namespace == y.Value || el.Name.Namespace == x.Value))
            {
                    e.Name = e.Name.Namespace == y.Value ? 
                                                          (XNamespace)x.Value + e.Name.LocalName : 
                                                           XNamespace.Xml + e.Name.LocalName;
            }

            doc.Save(fileName);
        }
    }
}
