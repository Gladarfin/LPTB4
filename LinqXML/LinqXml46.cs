// File: "LinqXml46"
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

        //LinqXml46�. ��� XML-��������. ��� ������� ��������, �������� �������� ��������, 
        //�������� � ����� ��� ������ ��������� ������� � ������ odd-node-count � ���������� ���������, 
        //������ true, ���� ��������� ���������� �������� ����� � ���� ��� �������� ��������� �������� ��������,
        //� false � ��������� ������. 
        public static void Solve()
        {
            Task("LinqXml46");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);

            foreach (var e in doc.Descendants().Where(el => el.Descendants().Count() > 0))
            {
                e.Add(new XAttribute("odd-node-count", e.Elements()
                                                        .Nodes()
                                                        .Count() % 2 != 0));
            }

            doc.Save(fileName);
        }
    }
}
