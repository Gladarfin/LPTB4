// File: "LinqXml48"
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

        //LinqXml48�. ��� XML-��������. ��� ������� ��������, �������� �� ����� ���� �������� �����, 
        //�������� �������� ������� � ������ has-instructions � ���������� ���������, ������ true, 
        //���� ������ ������� �������� � ����� ����� �������� ����� ���� ��� ����� ���������� ���������, 
        //� false � ��������� ������. ����� ������� �������� ����� ��������� ��������� �������� �����. 
        public static void Solve()
        {
            Task("LinqXml48");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);

            foreach (var e in doc.Descendants().Where(desc => desc.Nodes().Count() > 1))
            {
                e.LastNode.AddBeforeSelf(new XElement("has-instructions", e.Nodes()
                                                                           .OfType<XProcessingInstruction>()
                                                                           .Count() > 0));
            }
            doc.Save(fileName);
        }
    }
}
