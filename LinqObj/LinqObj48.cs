// File: "LinqObj48"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            //LinqObj48�. �������� ������������������ �������� �������� �� ��������������� �������� (���).
            //������ ������� ������������������ �������� ��������� ����:

            //      < ���� 1 �����(� ��������) >
            //      < ����� >
            //      < ����� ������� >
            //      < �������� >

            //�������� �������� � ���� �� �������� ��������. � �������� ����� ������� ����������� ����� 92, 95 ��� 98.
            //������ �������� ����� �� ����� ����� ��� �� ������ �����; ���� �� ������ ��� ����� � ��� �� �������� ����� �����������.
            //��������� ��� ��������� ���������� ���� � ��������, ������������ � �������� ������ ������, � ��� ������ ����
            //���������������� ������� �������� �����, �������� �������� � ���������� ����� �������, ������� ����������
            //��� ������ ��������, ������������� �� ������ �����(���� ��� �����������, �� ���������� ���������� ������ 0).
            //�������� � ������ ���� �������� �� ����� ������ � ������������� �� ��������� ���� � ���������� �������,
            //� ��� ���������� �������� ���� � �� ��������� ��������(����� � ���������� �������).

            Task("LinqObj48");
            var f = File.ReadAllLines(GetString(), Encoding.Default);
            var r = f.SelectMany(x => f.Select(y => new { street = x.Split(' ')[1], company = y.Split(' ')[3] }))
                .Distinct()
                .GroupJoin(f.Select(x => new { company = x.Split(' ')[3], street = x.Split(' ')[1] }),
                x => new { x.company, x.street },
                y => new { y.company, y.street },
                (k, g) => new { k, count = g.Count() })
                .OrderBy(x => x.k.street)
                .ThenBy(x => x.k.company)
            .Select(x => $"{x.k.street} {x.k.company} {x.count}");

           File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
