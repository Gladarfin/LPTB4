// File: "LinqObj28"
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
            // LinqObj28�. �������� ������������������ �������� �������� � ����������� �� ������ ������������ �����, 
            // ������� � 144 - ���������� 9 - ������� ����.������ ������� ������������������ �������� ��������� ����:
            // 
            //     < ������������� > 
            //     < ������� > 
            //     < ����� �������� >
            // 
            // ������������� ����������� � ���� �������� �����(����� ����� � �����, ������� ����� � �������).
            // � ������ �������� �� ������ ����� ������������� �� 4 ��������.��� ������� �� 9 ������ ���� ������� �������� � �����������, 
            // ������� �� ���� �����: ����� �����, ��������� ������������� ��� ������� ����� �����(��������� � ����� �������� �������), 
            // ����� �����������. �������� � ������ ����� �������� �� ��������� ������ � ������������� �� �������� ������ �����. 
            // ���� �� ����� - ���� ����� ���������� �����������, �� ������� ��� ����� ����� ������� ������.
            Task("LinqObj28");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Concat(Enumerable.Range(1, 9)
                .Select(i => String.Format("{0} {1} {2}", 0, "", i * 4)))
                .Select(x => new
                {
                    debt = double.Parse(x.Split(' ')[0], CultureInfo.InvariantCulture),
                    floor = (int.Parse(x.Split(' ')[2]) - 1) % 36 / 4 + 1
                })
                .GroupBy(x => x.floor)
                .OrderByDescending(x => x.Key)   
                .Select(x => $"{x.Key} {x.Sum(y => y.debt).ToString("0.00", CultureInfo.InvariantCulture)} {x.Count(y => y.debt > 0).ToString()}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
