// File: "LinqXml79"
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

        //LinqXml79�. ��� XML-�������� � ����������� � ������������� �� ������ ������������ �����.
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml76):
            //<house value = "12" >
            //  < flat value="129" />
            //  <name value = "������� �.�." />
            //  < debt value="1833.32" />
            //</house>
        //������������� ��������, �������� ����������� ������ �� ������ ����, � � �������� ������� ���� � �� ������ �����.
        //�������� �������� ������� ������ ��������� �������:
            //<house12>
            //  <floor6>
            //    <�������_�.�.flat="129" debt="1833.32" />
            //    ...
            //  </floor6>
            //  ...
            //</house12>
        //��� �������� ������� ������ ������ ����� ������� house, ����� �������� ����������� ����� ����;
        //��� �������� ������� ������ ������ ����� ������� floor, ����� �������� ����������� ����� �����.
        //��� �������� �������� ������ ��������� � �������� � ���������� ������; 
        //������� ���������� �� ��������� �������� �������������.
        //�������� ������� ������ ������ ���� ������������� �� ����������� ������� �����, 
        //� �� �������� �������� � �� �������� ������� ������. �������� �������� ������, 
        //������� ������ ��������, ������ ���� ������������� � ���������� ������� ������� � ��������� �������.
        //�����, � ������� ����������� ����������, �� ������������. 
        public static void Solve()
        {
            Task("LinqXml79");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Elements().Select(e => new{
                                                              house = int.Parse(e.Attribute("value").Value),
                                                              flat = int.Parse(e.Element(ns + "flat").Attribute("value").Value),
                                                              floor = (int.Parse(e.Element(ns + "flat").Attribute("value").Value) - 1) % 36 / 4 + 1,
                                                              name = e.Element(ns + "name").Attribute("value").Value.Replace(" ", "_"),
                                                              debt = e.Element(ns + "debt").Attribute("value").Value
                                                          })
                                          .OrderBy(h => h.house).ThenByDescending(f => f.floor).ThenBy(n => n.name);

            doc.Root.ReplaceNodes(data.GroupBy(h => h.house,
                                              (h, e) => new XElement(ns + ("house" + h),
                                                            e.GroupBy(f => f.floor,
                                                              (f, ee) => new XElement(ns + ("floor" + f),
                                                                             ee.Select(el => new XElement(ns + el.name,
                                                                                                 new XAttribute("flat", el.flat),
                                                                                                 new XAttribute("debt", el.debt))))))));
            doc.Save(fileName);                               
        }
    }
}
