// File: "LinqObj41"
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
            // LinqObj41�. ���� ����� ����� M � �������� ����� �� ����� �������. �������� ������������������ �������� ��������
            // �� ��������������� �������� (���). ������ ������� ������������������ �������� ��������� ����:

            //      < ����� ������� >
            //      < ����� >
            //      < �������� >
            //      < ���� 1 �����(� ��������) >

            // �������� �������� � ���� �� �������� ��������. � �������� ����� ������� ����������� ����� 92, 95 ��� 98. ������ ��������
            // ����� �� ����� ����� ��� �� ������ �����; ���� �� ������ ��� ����� � ��� �� �������� ����� �����������.
            // ��� ������ �����, �� ������� ������� ��� � �������� ����� M, ���������� ������������ ���� ������� ���� �����
            // (������� �������� ������������ ����, ����� �������� �����).�������� � ������ ����� �������� �� ����� ������ �
            // ������������� �� ����������� ������������ ����, � ��� ���������� ���� � �� ��������� ���� � ���������� �������.
            // ���� �� ����� ��� � �������� ����� M �� �������, �� �������� � �������������� ���� ������ �No�. 

            Task("LinqObj41");
            int m = GetInt();
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .Where(x => int.Parse(x[0]) == m)
                .GroupBy(x => x[1])
                .Select(g => new { street = g.Key, max = g.Max(x => int.Parse(x[3])) })
                .OrderBy(x => x.max)
                .ThenBy(x => x.street)
                .Select(g => $"{g.max} {g.street}")
                .DefaultIfEmpty("No");

           File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
