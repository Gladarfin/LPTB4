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
            Task("LinqXml7");
            //LinqXml7�. ���� ����� ������������� ���������� ����� � ������������ XML-���������.
            //������ ������ ���������� ����� �������� ���������(���� ��� �����) ����� �����, 
            //����������� ����� ����� ��������.������� XML-�������� � �������� ��������� root, 
            //���������� ������� ������ line � ���������� ������� ������ sum-positive � 
            //number-negative.�������� line ������������� ������� ��������� ����� � �� 
            //�������� �������� ��������� �����, ������� sum-positive �������� ������ ��������
            //��������� ������� �������� line � �������� ����� ���� ������������� ����� �� 
            //��������������� ������, �������� number - negative �������� �� ������ �������������� 
            //����� �� ��������������� ������(����� ������������� � �������, �������� ������� 
            //�� ���������� � �������� ������). 

            var file = File.ReadAllLines(GetString(), Encoding.Default);
            var doc = new XDocument(new XDeclaration(null, "windows-1251", null),
                                    new XElement("root",
                                    file.Select(e => new XElement("line",
                                    new XElement("sum-positive", e.Split(' ')
                                                                              .Select(j => Int32.Parse(j))
                                                                              .Where(jj=> jj>=0).Sum()),
                                    e.Split(' ')
                                     .Reverse()
                                     .Where(n => Int32.Parse(n) < 0)
                                     .Select(nn => new XElement("number-negative", Int32.Parse(nn)))))));
            doc.Save(GetString());          
        }
    }
}
