// File: "LinqXml82"
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

        //LinqXml82�. ��� XML-�������� � ����������� � ������������� �� ������ ������������ �����. 
        //������� �������� ������� ������ (����� ������ ��� ��, ��� � � LinqXml76, � �������� ����� �������� ������� ������ 
        //����������� ������ ���� � ��������, ����������� �������� �-� (�����) � ���������� ��������� addr, 
        //� � �������� �������� ����� �������� ����������� ������ ������������� ��� ������ ��������):
            //<addr12-23>1245.64</addr12-23>
        //������������� ��������, �������� ����������� ������ �� ������ ����, � � �������� ������� ���� � �� ������ �����.
        //�������� �������� ������� ������ ��������� �������:
            //<house12>
            //  <floor1 count = "0" total-debt="0" />
            //  ...
            //  <floor6 count = "1" total-debt="1245.64" />
            //  ...
            //  <floor9 count = "3" total-debt="3142.7" />
            //</house12>
        //��� �������� ������� ������ ������ ����� ������� house, ����� �������� ����������� ����� ����, ��� �������� ������� ������ 
        //������ ����� ������� floor, ����� �������� ����������� ����� �����.������� count ����� ����� ����������� �� ������ �����,
        //������� total-debt ���������� ��������� ������������� �� ������� �����, ����������� �� ���� ������� ������(���������� ����        
        //�� ������������). ���� �� ������ ����� ����������� ����������, �� ��� ���������������� �������� ������� ������ �������� 
        //��������� count � total-debt ������ ���� ����� 0. �������� ������� ������ ������ ���� ������������� �� ����������� �������
        //�����, � �� �������� �������� � �� ����������� ������� ������.

        public static void Solve()
        {
            Task("LinqXml82");
            string fileName = GetString();
            XDocument doc = XDocument.Load(fileName);
            XNamespace ns = doc.Root.Name.Namespace;
            var data = doc.Root.Elements()
                            .Select(e =>
                            {
                                string[] s = e.Name.LocalName.Substring(4).Split('-');
                                return new
                                {
                                    house = int.Parse(s[0]),
                                    floor = (int.Parse(s[1]) - 1) % 36 / 4 + 1,
                                    debt = (double)e
                                };
                            }).OrderBy(e => e.house);
            var floors = Enumerable.Range(1, 9);
            doc.Root.ReplaceNodes(data.GroupBy(e => e.house,
                                              (k, ee) => new XElement(ns + ("house" + k),
                                                                      floors.GroupJoin(ee, e1 => e1, e2 => e2.floor,
                                                                                      (e1, ee2) => new XElement(ns + ("floor" + e1),
                                                                                      new XAttribute("count", ee2.Count()),
                                                                                      new XAttribute("total-debt", Math.Round(ee2.Sum(e => e.debt), 2)))))));
            doc.Save(fileName);
        }
    }
}
