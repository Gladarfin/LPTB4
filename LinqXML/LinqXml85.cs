// File: "LinqXml85"
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

        //LinqXml85�. ��� XML-�������� � ����������� �� ������� �������� �� ��������� ���������. 
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml83):
            //<info class="9" name="��������� �.�." subject="������" mark="4" />
        //������������� ��������, �������� ����������� ������ �� ������ ������, � �������� ������� ������ � �� ��������,
        //� ��� ������� ��������� � �� ���������.�������� �������� ������� ������ ��������� �������:
            //<class number="9">
            //  <pupil name = "��������� �.�." >
            //    < subject name="������">
            //      <mark>4</mark>
            //      ...
            //    </subject>
            //    ...
            //  </pupil>
            //  ...
            //</class>
        //�������� ������� ������ ������ ���� ������������� �� ����������� ������� �������, 
        //� �� �������� �������� � � ���������� ������� ������� � ��������� ��������.�������� �������� ������,
        //������� ������ ��������, ������ ���� ������������� � ���������� ������� �������� ���������, � �������� ���������� ������, 
        //������� ������ ��������, ������ ���� ������������� �� �������� ������.
        public static void Solve()
        {
            Task("LinqXml85");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Elements().Select(el => new { 
                                                                cl = int.Parse(el.Attribute("class").Value),
                                                                name = el.Attribute("name").Value,
                                                                subject = el.Attribute("subject").Value,
                                                                mark = el.Attribute("mark").Value
                                                             }).OrderBy(el => el.cl)
                                                               .ThenBy(el => el.name)
                                                               .ThenBy(el => el.subject)
                                                               .ThenByDescending(el => el.mark);
            doc.Root.ReplaceNodes(data.GroupBy(el => el.cl,
                                 (c, ee) => new XElement(ns + "class",
                                             new XAttribute("number", c),
                                             ee.GroupBy(p => p.name,
                                                       (p, pp) => new XElement(ns + "pupil",
                                                                   new XAttribute("name", p),
                                                                   pp.GroupBy(s => s.subject,
                                                                             (s, ss) => new XElement(ns + "subject",
                                                                                         new XAttribute("name", s),
                                                                                         ss.Select(e => new XElement(ns + "mark", e.mark)))))))));
            doc.Save(fileName);                                       
        }
    }
}
