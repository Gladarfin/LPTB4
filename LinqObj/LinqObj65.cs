// File: "LinqObj65"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Threading;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            //LinqObj65�. ���� ������ S � �������� ������ �� ���� ���������: �������, ��������� ��� ������.
            //�������� ������������������ �������� �������� �� ������� �������� �� ���� ���� ���������.
            //������ ������� ������������������ �������� ������ �� ����� ������ � �������� ��������� ����:

            //  < ������� >
            //  < �������� >
            //  < �������� �������� >
            //  < ������ >
            //  < ����� >

            //������ �������������(� ����������� �������� � ����������) ����� �������� ���.����� �������� ����� ������,
            //������ � ����� ����� � ��������� 2�5.�������� �������� ����������� � ��������� �����.��� ������� ������,
            //��������������� � ������ �������� ������, ���������� ����� ��������, ������� �� �������� S ������� ������ �� ����� 3.5
            //��� �� ������� �� ����� ������ �� ����� ��������.�������� � ������ ������ �������� �� ��������� ������, �������� �����
            //��������� ��������(����� ����� ���� ����� 0) � ����� ������.������ ������������� �� ����������� ����� ��������,
            //� ��� ����������� ����� � �� �������� ������ ������. 

            Task("LinqObj65");
            var s = GetString();
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[4]))
                .Select(x => new
                {
                    cl = x.Key,
                    subj = x.GroupBy(st => st[0] + ' ' + st[1])
                            .Select(y => y.Where(su => su[2] == s).Select(sm => int.Parse(sm[3])).DefaultIfEmpty().Average())
                            .Where(k => k <= 3.5)
                            .Count()

                })
                .OrderBy(x => x.subj)
                .ThenByDescending(x => x.cl)
                .Select(x => $"{x.subj} {x.cl}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
