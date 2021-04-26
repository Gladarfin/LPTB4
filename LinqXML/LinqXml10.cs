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
            Task("LinqXml10");
            //LinqXml10�. ���� ����� ������������� ���������� ����� � ������������ XML-���������.
            //������� XML - �������� � �������� ��������� root, ���������� ������� ������ line � 
            //������������ ���������(���������� ��������� �������� ��������� ������ ��������� ��������).
            //���� ������ ���������� ����� ���������� � ������ �data:�, �� ���(��� ������ �data:�) 
            //����������� � XML - �������� � �������� ������ � ��������� ���������� ��������� � ������ 
            //instr, � ��������� ������ ������ ����������� � �������� ��������� ���������� ���� � 
            //��������� ������� line.

            var file = File.ReadAllLines(GetString(), Encoding.Default);
            var doc = new XDocument(new XDeclaration(null, "windows-1251", null),
                                    new XElement("root",
                                    file.Select(e => e.StartsWith("data:") ?
                                                     new XProcessingInstruction("instr", e.Substring(5)) :
                                                     new XElement("line", e) as XNode)));
            doc.Save(GetString());
        }
    }
}
