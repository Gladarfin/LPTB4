// File: "LinqObj34"
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
            // LinqObj34�. �������� ������������������ �������� �������� � ����������� �� ������ ������������ �����, 
            // ������� � 144 - ���������� 9 - ������� ����.������ ������� ������������������ �������� ��������� ����:
            // 
            //     < ������������� > 
            //     < ����� �������� > 
            //     < ������� >
            // 
            // ������������� ����������� � ���� �������� �����(����� ����� � �����, ������� ����� � �������).
            // � ������ �������� �� ������ ����� ������������� �� 4 ��������.����� �������, ���� ������� �� ������ 
            // �������� ������� ������������� �� ����, � ������� �������� � ���: ����� �����, ����� ��������, 
            // �������, �������������(��������� � ����� �������� �������).������, �� ������� �����, 
            // ��� ���������� ������� ������������� �� �����������. �������� � ������ ���������� �������� �� ��������� 
            // ������ � ������������� �� �������� ������� ������, � ��� ���������� ������ � �� ����������� ������� �������. 

            Task("LinqObj34");
            var f = File.ReadAllLines(GetString(), Encoding.Default);
            var avg = f.Where(y => double.Parse(y.Split(' ')[0]) > 0).Average(x => double.Parse(x.Split(' ')[0], CultureInfo.InvariantCulture));
            var r = f
                .Select(x => new
                {
                    surname = x.Split(' ')[2],
                    flat = int.Parse(x.Split(' ')[1]),
                    floor = (int.Parse(x.Split(' ')[1]) - 1) % 36 / 4 + 1,
                    debt = double.Parse(x.Split(' ')[0], CultureInfo.InvariantCulture),
                })
                .Where(y => y.debt <= avg)
                .OrderByDescending(x => x.floor)
                .ThenBy(x => x.flat)
                .Select(x => $"{x.floor} {x.flat} {x.surname} {x.debt.ToString("0.00", CultureInfo.InvariantCulture)}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
