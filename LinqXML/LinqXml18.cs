// File: "LinqXml18"
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

        //LinqXml18�. ��� XML-��������, ���������� ���� �� ���� �������.
        //����� ��� ��������� ����� ��������� � ������� ��� �����, � ����� 
        //��� ��������� � ���� ��������(��� �������� ��������� ����������). 
        //������� ���� ������ ��������������� ������� �� ������� ��������� � ��������; 
        //��������, ��������� � ������ ������, �������� � ���������� �������.

        public static void Solve()
        {
            Task("LinqXml18");
            var doc = XDocument.Load(GetString());
            var result = doc.Descendants()
                            .Attributes()
                            .Select(elem => new 
                            { 
                                attrName = elem.Name.LocalName,
                                attrValue = elem.Value
                            })
                            .GroupBy(elem => elem.attrName);

            foreach (var e in result)
            {
                Put(e.Key);
                var attrValues = e.Select(atr => atr.attrValue).OrderBy(atr => atr);
                foreach (var v in attrValues)
                    Put(v);
            }

        }
    }
}
