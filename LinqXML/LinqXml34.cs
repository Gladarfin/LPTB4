// File: "LinqXml34"
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


        //LinqXml34�. ��� XML-��������. 
        //��� ������� �������� ������� ������, �������� ��������, 
        //�������� � ����� ��� �������� ����� �������� � �������, 
        //������������ � ������� ��� ���������, � ���������� ����������, 
        //������������ �� ���������� ��������������� ���������, ����� ���� 
        //������� ��� �������� ��������������� �������� ������� ������.
        //��������.������������ ����� ReplaceAttributes, ������ � �������� 
        //��������� ������������������ ���������, ���������� ������� Select �� ������������������ ���������.
        public static void Solve()
        {
            Task("LinqXml34");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            foreach (var e in doc.Root.Elements().Where(el => el.HasAttributes))
            {
                e.ReplaceAttributes(e.Attributes().Select(at => new XElement(at.Name.LocalName, at.Value)));              
            }
            doc.Save(fileName);
        }
    }
}
