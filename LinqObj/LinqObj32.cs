// File: "LinqObj32"
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
            //LinqObj32�. �������� ������������������ �������� �������� � ����������� �� ������ ������������ �����, 
            //������� � 144 - ���������� 9 - ������� ����.������ ������� ������������������ �������� ��������� ����:

            //    < ������� > 
            //    < ����� �������� > 
            //    < ������������� >

            //������������� ����������� � ���� �������� �����(����� ����� � �����, ������� ����� � �������).
            //� ������ �������� �� ������ ����� ������������� �� 4 ��������.��� ������� �� 9 ������ ���� ����� ������ 
            //� ���������� �������������� � ������� �������� � ���: ����� ����� � �������������(��������� � ����� �������� �������).
            //�������, ��� � ������ �������� ������ ��� ������������� ����� ��������� ��������. �������� � ������ ����� �������� �� 
            //��������� ������ � ������������� �� ����������� ������ �����. ���� �� ����� - ���� ����� ���������� �����������, 
            //�� ��� ����� ����� ������� �������������, ������ 0.00.

            Task("LinqObj32");

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Concat(Enumerable.Range(1, 9)
                .Select(i => String.Format("{0} {1} {2}", "", i * 4, 0)))
                .Select(x => new
                {
                    debt = double.Parse(x.Split(' ')[2], CultureInfo.InvariantCulture),
                    floor = (int.Parse(x.Split(' ')[1]) - 1) % 36 / 4 + 1
                })
                .GroupBy(x => x.floor)
                .OrderBy(x => x.Key)
                .SelectMany(x => x.OrderBy(y => y.debt).Take(2).OrderByDescending(y => y.debt).Take(1))
                .Select(x => $"{x.floor} {x.debt.ToString("0.00", CultureInfo.InvariantCulture)}");

            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
