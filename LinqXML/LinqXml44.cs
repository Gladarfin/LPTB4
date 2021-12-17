// File: "LinqXml44"
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

        //LinqXml44�. ��� XML-�������� � ������ S. � ������ �������� ��� ������ �� ��������� ��������� ���������; 
        //��������, ��� ��� �������� � ��������� ������ �������� ��������� ������������� ������������� �����. 
        //��� ������� �������� ��������� ��������� ��������: ��������� ���� ��� ��������, ���������� ������� S, 
        //����� ����������� �������� ������� �������� � �������� ��� �������� � ����� ������� min ��������������� ��������. 
        //���� �� ���� �� �������� �������� �� �������� ������� S, �� ������� min � ����� �������� �� ���������.

        //��������.������������ ���������� �������� Attribute(S) � Nullable-���� double?; 
        //���� ������� � ��������� ������ �����������, �� ����� ���������� �������� null. 
        //��� �������� ������ �������� � ��������� ����������� ��������� ������������ ����� SetAttributeValue; 
        //� ������ �������� null ������� ������ �� �����.
        public static void Solve()
        {
            Task("LinqXml44");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            string s = GetString();

            foreach (var e in doc.Descendants().Where(d => d.Descendants().Attributes(s).Count() > 0))
            {
                e.SetAttributeValue("min", e.Descendants()
                                            .Attributes(s)
                                            .Select(at => (double?)at).Min());
            }
            doc.Save(fileName);
        }
    }
}
