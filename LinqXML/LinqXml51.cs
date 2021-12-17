// File: "LinqXml51"
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


        //LinqXml51�. ��� XML-��������. ����� ��� ������� �������� ���� ����� �������� ���������,
        //���� ��������� ������������� ��������� ����, ��������������� ��������� XML. 
        //�������� ��� ��������, ���������� ����, ��������� �������: �������� ������� year, 
        //���������� �������� ���� �� �������� ����, � �������� ������� day � ��������� ���������,
        //������ �������� ��� �� �������� ����, ����� ���� ������� �� ��������������� �������� �������� ����.

        //��������.������������ ���������� �������� XML � ���� DateTime.
        public static void Solve()
        {
            Task("LinqXml51");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            //i don't like this, but it works
            foreach (var e in doc.Root.Descendants().Where(el => !el.HasElements && el.Name.LocalName != "day"))
            {
                var date = (DateTime)e;
                e.Add(new XAttribute("year", date.Year));
                e.ReplaceNodes(new XElement("day", date.Day));
            }
            doc.Save(fileName);
        }
    }
}
