// File: "LinqXml88"
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

        //LinqXml88�. ��� XML-�������� � ����������� �� ������� �������� �� ��������� ���������. 
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml83, ������ ������������� �� �������):
            //<class number="9">
            //  <pupil name="��������� �.�." subject="������" mark="4" />
            //  ...
            //</class>
        //������������� ��������, �������� ����������� ������ �� ��������� � ������� �������� ������ � ��� ��������, 
        //������� �������� �� ������� �������� ����� ���� ������. �������� �������� ������� ������ ��������� �������:
            //<subject name="������">
            //  <pupil class="9" name="��������� �.�." m1="4" m2="3" m3="3" />
            //  ...
            //</subject>
        //������ ������� ��������� �� ������� �������� ����������� � ���������, ������� ������� m, ����� �������� ������� ���������� ����� ������.
        //�������� ������� ������ ������ ���� ������������� � ���������� ������� �������� ���������, �� �������� �������� � �� �����������
        //������� �������, � ��� ���������� ������� � � ���������� ������� ������� � ��������� ��������. ������ ��� ������� ���������
        //������ ������������� � ������� ��������. ���� ��� ���������� �������� �� ������� ��������, ������� �� ���� ����� ���� ������,
        //�� ��������������� ������� ������� ������ ������ ���� ����������� ��������������� �����, ��������:
            //<subject name="�����" />

        public static void Solve()
        {
            Task("LinqXml88");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Descendants(ns + "pupil").Select(el => new { 
                                                                                cl = int.Parse(el.Parent.Attribute("number").Value),
                                                                                name = el.Attribute("name").Value,
                                                                                subject = el.Attribute("subject").Value,
                                                                                mark = int.Parse(el.Attribute("mark").Value)
                                                                            })
                               .OrderBy(el => el.subject).ThenBy(c => c.cl).ThenBy(n => n.name).ThenByDescending(m => m.mark);

            doc.Root.ReplaceNodes(data.GroupBy(s => s.subject,
                                       (s, ee) => new XElement(ns + "subject",
                                                   new XAttribute("name", s),
                                                   ee.GroupBy(n => n.name).Where(mc => mc.Select(m => m.mark).Count() > 2)
                                                   .Select(e => new XElement(ns + "pupil",
                                                                 new XAttribute("class", e.Select(ec => ec.cl).First()),
                                                                 new XAttribute("name", e.Key),
                                                                 e.Select((el, i) => new XAttribute("m" + (i + 1), el.mark)))))));
            doc.Save(fileName);
        }
    }
}
