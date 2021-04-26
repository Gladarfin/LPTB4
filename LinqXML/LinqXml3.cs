using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace PT4Tasks
{
    public class MyTask: PT
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

        public static void Solve()
        {
            Task("LinqXml3");
            //LinqXml3�. ���� ����� ������������� ���������� ����� � ������������ XML-���������.
            //������� XML - �������� � �������� ��������� root � ���������� ������� ������ line, 
            //������ �� ������� �������� ���� ������ �� ��������� �����.
            //�������, ���������� ������ � ���������� ������� N(1, 2, �), ������ ����� ������� num 
            //�� ���������, ������ N.
            var file = File.ReadAllLines(GetString(), Encoding.Default);
            var doc = new XDocument(
                new XDeclaration(null, "windows-1251", null),
                new XElement("root",
                file.Select((e, i) => new XElement("line", new XAttribute("num", ++i), e))));
            doc.Save(GetString());

        }
    }
}
