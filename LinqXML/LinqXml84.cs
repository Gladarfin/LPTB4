// File: "LinqXml84"
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

        //LinqXml84�. ��� XML-�������� � ����������� �� ������� �������� �� ��������� ���������. 
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml83):
            //<pupil class="9" name="��������� �.�.">
            //  <subject>������</subject>
            //  <mark>4</mark>
            //</pupil>
        //������������� ��������, ������� �������� ������� ������ ��������� �������:
        //<class9 name = "��������� �.�." subject="������">4</class9>
        //��� �������� ������ ����� ������� class, ����� �������� ����������� ����� ������.�������� ������ ���� �������������
        //�� ����������� ������� �������, ��� ���������� ������� ������� � � ���������� ������� ������� � ��������� ��������,
        //��� ������� ��������� � � ���������� ������� �������� ���������, � ��� ���������� ��������� � �� ����������� ������.
        public static void Solve()
        {
            Task("LinqXml84");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Elements().Select(el => new { 
                                                                cl = int.Parse(el.Attribute("class").Value),
                                                                name = el.Attribute("name").Value,
                                                                subject = el.Element(ns + "subject").Value,
                                                                mark = el.Element(ns + "mark").Value
                                                             })
                                .OrderBy(el => el.cl).ThenBy(el => el.name).ThenBy(el => el.subject).ThenBy(el => el.mark);

            doc.Root.ReplaceNodes(data.Select(el => new XElement(ns + ("class" + el.cl),
                                                                 new XAttribute("name", el.name),
                                                                 new XAttribute("subject", el.subject),
                                                                 el.mark)));
            doc.Save(fileName);
        }
    }
}
