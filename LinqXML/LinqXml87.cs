// File: "LinqXml87"
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

        //LinqXml87�. ��� XML-�������� � ����������� �� ������� �������� �� ��������� ���������. 
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml83, ������ ������������� �� ��������):
            //<pupil name = "��������� �.�." class="9">
            //  <mark subject = "������" > 4 </ mark >
            //  ...
            //</pupil>
        //������������� ��������, �������� ����������� ������ �� ��������� ��������� � ������� �������� ������� ������ ��������� �������:
            //<������>
            //  <class9>
            //    <mark-count>4</mark-count>
            //    <avr-mark>4.1</avr-mark>
            //  </class9>
            //  ...
            //</������>
        //��� �������� ������� ������ ��������� � ��������� ��������, ��� �������� ������� ������ ������ ����� ������� class, 
        //����� �������� ����������� ����� ������.�������� �������� mark-count ����� ���������� ������ �� ������� ��������,
        //������������ � ������ ������; �������� �������� avr-mark ����� �������� �������� ���� ������, ���������� �� ��������� �������: 
        //10*������ ������/����������� ������*0.1 (������ �/� ���������� �������� �������������� �������, ���������� �������� ������ 
        //��������� �� ����� ������ �������� �����, ���������� ���� �� ������������). 
        //�������� ������� ������ ������ ���� ������������� � ���������� ������� �������� ���������, � �� �������� �������� � 
        //�� ����������� ������� �������.��� ������� �������� ���������� ������ �� ������, � ������� ���������� ���� �� ���� ������
        //�� ����� ��������. 
        public static void Solve()
        {
            Task("LinqXml87");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Descendants(ns + "mark").Select(el => new { 
                                                                               subject = el.Attribute("subject").Value,
                                                                               mark = int.Parse(el.Value),
                                                                               cl = int.Parse(el.Parent.Attribute("class").Value)
                                                                            }).OrderBy(el => el.subject).ThenBy(el => el.cl);
            doc.Root.ReplaceNodes(data.GroupBy(s => s.subject,
                                        (s, es) => new XElement(ns + s,
                                                    es.GroupBy(c => c.cl,
                                                        (c, ec) => new XElement(ns + ("class" + c),
                                                                    new XElement(ns + "mark-count", 
                                                                                 ec.Select(e => e.mark).Count()),
                                                                    new XElement(ns + "avr-mark",
                                                                                 Math.Round(10 * ec.Select(e => e.mark).Sum() / ec.Select(e => e.mark).Count() * 0.1, 1)))))));
            doc.Save(fileName);                         
        }
    }
}
