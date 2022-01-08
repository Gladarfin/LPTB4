// File: "LinqXml62"
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

        //LinqXml62�. ��� XML-�������� � ����������� � �������� ������-������.
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml61):
        //<time year = "2000" month="5" id="10">PT5H13M</time>
        //������������� ��������, ������� �������� ������� ������ ��������� �������:
        //<id10 date = "2000-05-01T00:00:00" > 313 </ id10 >
        //
        //��� �������� ������ ����� ������� id, ����� �������� ����������� ��� �������; 
        //� �������� �������� date ���� ������ ���� ����� 1, � ����� ������ ���� �������.�������� �������� ����� 
        //����������������� ������� ������� � ������ ������, ������������ � ������.�������� ������ ���� �������������
        //�� ����������� ���� �������, � ��� ���������� �������� ���� � �� ����������� ����.
        public static void Solve()
        {
            Task("LinqXml62");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            doc.Root.ReplaceNodes(doc.Root.Elements().Select(el => new XElement(ns + "id" + el.Attribute("id").Value,
                                                                                new XAttribute("date", DateTime.Parse(string.Format("{0}-{1}-01",
                                                                                                                                    el.Attribute("year").Value,
                                                                                                                                    el.Attribute("month").Value))),
                                                                                ((TimeSpan)el).TotalMinutes))
                                                     .OrderBy(el => int.Parse(el.Name.LocalName.Remove(0,2)))
                                                     .ThenBy(el => el.Attribute("date").Value));
            doc.Save(fileName);


        }
    }
}
