// File: "LinqXml89"
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

        //LinqXml89�. ��� XML-�������� � ����������� �� ������� �������� �� ��������� ���������. 
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml83, � �������� ���� ��������� 
        //������� ������ ����������� ������� � �������� ��������; ��� ���� ������ ����� �������� � ���������� ���������� 
        //�������� �������������):
            //<������_�.�. class="11" subject="������">4</������_�.�.>
        //������������� ��������, �������� ����������� ������ �� ���������, � ��� ������� �������� � �� �������.
        //�������� �������� ������� ������ ��������� �������:
            //<������>
            //  <class7 pupil-count= "0" mark-count= "0" />
            //  ...
            //  <class11 pupil-count= "3" mark-count= "5" />
            //</ ������ >
        //��� �������� ������� ������ ��������� � ��������� ��������, ��� �������� ������� ������ ������ ����� ������� class, 
        //����� �������� ����������� ����� ������.�������� �������� pupil-count ����� ���������� �������� ������� ������,
        //������� ���� �� ���� ������ �� ������� ��������, �������� �������� mark-count ����� ���������� ������ �� ������� 
        //�������� � ������ ������.��� ������� �������� ������ ���� �������� ���������� �� ������� ������ (�� 7 �� 11);
        //���� � ��������� ������ �� ������� �������� �� ���� �������� �� ������ ���������, �� �������� pupil-count � mark-count
        //������ ���� ����� 0. �������� ������� ������ ������ ���� ������������� � ���������� ������� �������� ���������, 
        //� �� �������� �������� � �� ����������� ������� �������.

        public static void Solve()
        {
            Task("LinqXml89");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Elements().Select(el => new { 
                                                                name = el.Name.LocalName.Replace("_", " "),
                                                                cl = int.Parse(el.Attribute("class").Value),
                                                                subject = el.Attribute("subject").Value,
                                                                mark = int.Parse(el.Value)
                                                            }).OrderBy(s => s.subject);
            var cl = Enumerable.Range(7, 5);

            doc.Root.ReplaceNodes(data.GroupBy(s => s.subject,
                                   (s, ee) => new XElement(ns + s,
                                               cl.GroupJoin(ee, e1 => e1, e2 => e2.cl,
                                                 (e1, ee2) => new XElement(ns + ("class" + e1),
                                                               new XAttribute("pupil-count", ee2.Select(p => p.name).Distinct().Count()),
                                                               new XAttribute("mark-count", ee2.Select(m => m.mark).Count()))))));
            doc.Save(fileName);

        }
    }
}
