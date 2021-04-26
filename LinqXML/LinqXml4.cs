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
            Task("LinqXml4");
            //LinqXml4�. ���� ����� ������������� ���������� ����� � ������������ XML-���������.
            //������ ������ ���������� ����� �������� ���������(���� ��� �����) ����, 
            //����������� ����� ����� ��������. ������� XML-�������� � �������� ��������� root, 
            //���������� ������� ������ line � ���������� ������� ������ word. �������� line 
            //������������� ������� ��������� ����� � �� �������� �������� ��������� �����, 
            //�������� word ������� �������� line �������� �� ������ ����� �� ��������������� 
            //������(����� ������������� � ���������� �������).
            var file = File.ReadAllLines(GetString(), Encoding.Default);
            var doc = new XDocument(
                new XDeclaration(null, "windows-1251",null),
                new XElement("root",
                file.Select(e => 
                new XElement("line",
                             e.Split(' ')
                              .OrderBy(j => j)
                              .Select(w => new XElement("word", w)))
            )));
            doc.Save(GetString());
        }
    }
}
