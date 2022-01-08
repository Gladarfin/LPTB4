// File: "LinqXml80"
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

        //LinqXml80�. ��� XML-�������� � ����������� � ������������� �� ������ ������������ �����. 
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml76, 
        //������ ������������� �� ������� �����; � �������� ��������� ������� ������ ����������� ������� � �������� �������,
        //������� ���������� �� ��������� �������� �������������):
            //<house number = "12" >
            //  < ������_�.�.>
            //    < flat value="23" />
            //    <debt value = "1245.64" />
            //  </ ������_�.�.>
            //  ...
            //</house>
        //������������� ��������, �������� ����������� ������ �� ������ ����, �������� � �������� ������� ���� ����������� 
        //�� ������ �������� � ������� �������� ������� ������ ��������� �������:
            //<house12>
            //  <entrance1 total-debt="2493.38" count="3">
            //    <flat23 name = "������ �.�." />
            //    ...
            //  </entrance1>
            //  ...
            //</house12>
        //��� �������� ������� ������ ������ ����� ������� house, ����� �������� ����������� ����� ����, 
        //��� �������� ������� ������ ������ ����� ������� entrance, ����� �������� ����������� ����� ��������, 
        //��� �������� �������� ������ ������ ����� ������� flat, ����� �������� ����������� ����� ��������.
        //������� total-debt ����� ��������� ������������� ������� ������� �������� (�������� ������������� 
        //������ ����������� �� ���� ������� ������, ���������� ���� �� ������������), ������� count ����� 
        //���������� ����������� � ������ ��������.�������� ������� ������ ������ ���� ������������� �� 
        //����������� ������� �����, � �� �������� �������� � �� ����������� ������� ���������.
        //�������� �������� ������, ������� ������ ��������, ������ ���� ������������� �� ����������� ������� �������.
        //��������, � ������� ����������� ����������, �� ������������. 
        public static void Solve()
        {
            Task("LinqXml80");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            var ns = doc.Root.Name.Namespace;
            var data = doc.Root.Descendants(ns + "flat").Select(el => new { 
                                                                               house = int.Parse(el.Parent.Parent.Attribute("number").Value),
                                                                               flat = int.Parse(el.Attribute("value").Value),
                                                                               entrance = (int.Parse(el.Attribute("value").Value) - 1) / 36 + 1,
                                                                               debt = (double)el.Parent.Element(ns + "debt").Attribute("value"),
                                                                               name = el.Parent.Name.LocalName.Replace("_"," ")
            }).OrderBy(el => el.house)
              .ThenBy(el => el.entrance)
              .ThenBy(el => el.flat);

            doc.Root.ReplaceNodes(
                data.GroupBy(hn => "house" + hn.house,
                     (h, ee) => new XElement(ns + h,
                                    ee.GroupBy(en => "entrance" + en.entrance,
                                              (e, ee2) => new XElement(ns + e,
                                                              new XAttribute("total-debt", Math.Round(ee2.Select(d => d.debt).Sum(),2)),
                                                              new XAttribute("count", ee2.Select(d => d.name).Count()),
                                                              ee2.Select(f => new XElement(ns + ("flat" + f.flat),
                                                                                  new XAttribute("name", f.name))))))));
            doc.Save(fileName);
        }
    }
}
