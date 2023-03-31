// File: "LinqObj47"
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
            //LinqObj47�. �������� ������������������ �������� �������� �� ��������������� ��������(���).
            //������ ������� ������������������ �������� ��������� ����:

                //< ���� 1 �����(� ��������) >
                //< �������� >
                //< ����� >
                //< ����� ������� >

            //�������� �������� � ���� �� �������� ��������. � �������� ����� ������� ����������� ����� 92, 95 ��� 98.
            //������ �������� ����� �� ����� ����� ��� �� ������ �����; ���� �� ������ ��� ����� � ��� �� �������� ����� �����������.
            //������� ������ ��� ���� ���, ������������ �� ����� ���� ����� �������(������� ��������� �������� ��������, ����� ��������
            //�����, ����� ���������� �������������� ����� �������). �������� � ������ ��� �������� �� ����� ������ � �������������
            //�� ��������� �������� � ���������� �������, � ��� ���������� �������� � �� ��������� ����(����� � ���������� �������).
            //���� �� ����� ��������� ��� �� �������, �� �������� � �������������� ���� ������ �No�. 

            Task("LinqObj47");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => new { company = x[1], street = x[2] },
                        (x, y) => new { key = x, count = y.Count() })
                .Where(x => x.count >= 2)
                .OrderBy(x => x.key.company)
                .ThenBy(x => x.key.street)
                .Select(x => $"{x.key.company} {x.key.street} {x.count}")
                .DefaultIfEmpty("No");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
