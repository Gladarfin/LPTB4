// File: "LinqObj46"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            //LinqObj46�. �������� ������������������ �������� �������� �� ��������������� ��������(���).
            //������ ������� ������������������ �������� ��������� ����:

            //< ����� >
            //< ����� ������� >
            //< ���� 1 �����(� ��������) >
            //< �������� >

            //�������� �������� � ���� �� �������� ��������. � �������� ����� ������� ����������� ����� 92, 95 ��� 98.
            //������ �������� ����� �� ����� ����� ��� �� ������ �����; ���� �� ������ ��� ����� � ��� �� �������� ����� �����������.
            //��� ������ �������� ���������� ���������� ���, ������������ ��� ��� ����� �������(������� �������� ���������� ���,
            //����� � �������� ��������; ���������� ����� ���� ����� 0). �������� � ������ �������� �������� �� ����� ������ �
            //������������� �� �������� ���������� ���, � ��� ������ ����������� � �� ��������� �������� � ���������� �������. 
            Task("LinqObj46");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => new { company = x[3], street = x[0] },
                        (k, g) => new { k, g })
                .GroupBy(x => x.k.company,
                        (x, y) => new { company = x, count = y.Count(s =>
                                                                        s.g.Select(g92 => g92[1]).Contains("92") &&
                                                                        s.g.Select(g95 => g95[1]).Contains("95") &&
                                                                        s.g.Select(g98 => g98[1]).Contains("98"))
                        }
                )
                .OrderByDescending(x => x.count)
                .ThenBy(x => x.company)
                .Select(x => $"{x.count} {x.company}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
