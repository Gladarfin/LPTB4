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
            Task("LinqXml6");
            //LinqXml6�. ���� ����� ������������� ���������� ����� � ������������ XML-���������.
            //������ ������ ���������� ����� �������� ���������(���� ��� �����) ����� �����, 
            //����������� ����� ����� ��������.������� XML-�������� � �������� ��������� root, 
            //���������� ������� ������ line � ���������� ������� ������ number. 
            //�������� line ������������� ������� ��������� ����� � �� �������� �������� ��������� 
            //�����, �������� number ������� �������� line �������� �� ������ ����� �� ���������������
            //������(����� ������������� � ������� ��������).������� line ������ ��������� ������� sum,
            //������ ����� ���� ����� �� ��������������� ������.
            var file = File.ReadAllLines(GetString(), Encoding.Default);
            var doc = new XDocument(new XDeclaration(null, "windows-1251", null),
                                    new XElement("root", 
                                    file.Select(e => new XElement("line", 
                                                           new XAttribute("sum", e.Split(' ')
                                                                                              .Select(j => Int32.Parse(j)).Sum()),
                                                           e.Split(' ')
                                                            .OrderByDescending(j => Int32.Parse(j))
                                                            .Select(n => new XElement("number",n))))));
            doc.Save(GetString());
            
        }
    }
}
