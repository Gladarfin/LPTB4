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
            Task("LinqXml8");
            //LinqXml8�. ���� ����� ������������� ���������� ����� � ������������ XML-���������.
            //������ ������ ���������� ����� �������� ���������(���� ��� �����) ����, ����������� 
            //����� ����� ��������. ������� XML-�������� � �������� ��������� root, ���������� 
            //������� ������ line, ���������� ������� ������ word � ���������� �������� ������ char.
            //�������� line � word �� �������� �������� ��������� �����. �������� line ������������� 
            //������� ��������� �����, �������� word ������� �������� line ������������� ������ �� 
            //���� ������(����� ������������� � ���������� �������), �������� char ������� �������� 
            //word �������� �� ������ ������� �� ���������������� �����(������� ������������� �
            //������� �� ���������� � �����).

            var file = File.ReadAllLines(GetString(), Encoding.Default);
            var doc = new XDocument(new XDeclaration(null, "windows-1251", null),
                                    new XElement("root",
                                           file.Select(e => new XElement("line",
                                           e.Split(' ')
                                            .OrderBy(n => n)
                                            .Select(w => new XElement("word",
                                            w.ToCharArray().Select(l => new XElement("char", l))))))));
            doc.Save(GetString());
        }
    }
}
