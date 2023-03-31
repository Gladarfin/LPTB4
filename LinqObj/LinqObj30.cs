// File: "LinqObj30"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            // LinqObj30�. �������� ������������������ �������� �������� � ����������� �� ������ ������������ �����, 
            // ������� � 144 - ���������� 9 - ������� ����.������ ������� ������������������ �������� ��������� ����:
            // 
            //     < ������� > 
            //     < ������������� > 
            //     < ����� �������� >
            // 
            // ������������� ����������� � ���� �������� �����(����� ����� � �����, ������� ����� � �������).
            // � ������ �������� �� ������ ����� ������������� �� 4 ��������.��� ������� �� 9 ������ ���� ����� 
            // ������ � ���������� �������������� � ������� �������� � ���: ����� ��������, ����� �����, ������� ������, 
            // ������������� (��������� � ����� �������� �������). �������, ��� � ������ �������� ������ ��� ������������� 
            // ����� ��������� ��������. �������� � ������ ���������� �������� �� ��������� ������ � ������������� �� ����������� 
            // ������ ��������. ���� �� ����� - ���� ����� ���������� �����������, �� ������ �� ���� ����� �� ��������.

            Task("LinqObj30");

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => new
                {
                    surname = x.Split(' ')[0],
                    debt = double.Parse(x.Split(' ')[1], CultureInfo.InvariantCulture),
                    flat = int.Parse(x.Split(' ')[2]),
                    floor = (int.Parse(x.Split(' ')[2]) - 1) % 36 / 4 + 1
                })
                .GroupBy(x => x.floor)
                .SelectMany(x => x.OrderBy(y => y.debt).Take(1))
                .OrderBy(x => x.flat)
                .Select(x => $"{x.flat} {x.floor} {x.surname} {x.debt.ToString("0.00", CultureInfo.InvariantCulture)}");

            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
