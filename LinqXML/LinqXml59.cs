// File: "LinqXml59"
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

        //LinqXml59�. ��� XML-��������. � ������ �� ��������� ������� ������ ��������� ������������ ������� ������������ ����, 
        //������ ��������, ��� ��� �������� � ���� ��������� ����� ������������� ��������. ��� ������� �������� ������� ������ 
        //� ��� ���������-�������� ������� �������� ���� ��������� � ��������� ������������ ����, ������������ � ���� ��������.
        public static void Solve()
        {
            Task("LinqXml59");
            string fileName = GetString();
            var doc = XDocument.Load(fileName);
            //meh
            foreach (var e in doc.Root.Elements().Attributes().Where(el => el.IsNamespaceDeclaration))
            {
                var prefix = (XNamespace)e.Value;
                var elems = e.Parent.DescendantsAndSelf().Attributes();
                foreach (var at in e.Parent.DescendantsAndSelf().Attributes().Where(el => prefix == el.Name.NamespaceName))
                {
                    at.Value = (int.Parse(at.Value) * 2).ToString();
                }
            }
            doc.Save(fileName);

        }
    }
}
