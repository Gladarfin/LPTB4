// File: "LinqXml52"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Globalization;

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

        //LinqXml52�. ��� XML-��������. � ������ ��������� ��������� ����������� ��������� ����, 
        //������������ �������� ����, ������ � ���. ���������� ���� ���� ����������� � ��������� year, month, day.
        //���� ��������� �� ���� ��������� �����������, �� ��������������� ���������� ������������ �� ���������: 2000 ��� ����,
        //1 ��� ������ � 10 ��� ���. ��� ������� �������� �������� � ������ ��� ������ �������� ����� ������� date 
        //� ��������� �������������� ����, ��������� � �������������� ��������� (���� ������������ � �������, 
        //�������� � ��������� XML), � ������� ��������� ��������, ��������� � ������������ ����. 
        public static void Solve()
        {
            Task("LinqXml52");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            //meh... TODO find a better solution
            foreach (var e in doc.Descendants().Where(el => el.Name.LocalName != "date"))
            {
                var date = DateTime.Parse(string.Format(@"{0}-{1}-{2}", (string)e.Attribute("year") ?? "2000",
                                                                        (string)e.Attribute("month") ?? "01",
                                                                        (string)e.Attribute("day") ?? "10"));
                e.AddFirst(new XElement("date", date));
            }
            doc.Descendants().Attributes().Where(a => a.Name.LocalName == "year" ||
                                                      a.Name.LocalName == "month" ||
                                                      a.Name.LocalName == "day").Remove();
            
            doc.Save(fileName);
            
        }
    }
}
