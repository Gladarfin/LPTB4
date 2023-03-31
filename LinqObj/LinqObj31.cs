// File: "LinqObj31"
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
            //LinqObj31�. �������� ������������������ �������� �������� � ����������� �� ������ ������������ �����, 
            //������� � 144 - ���������� 9 - ������� ����.������ ������� ������������������ �������� ��������� ����:

            //        < ������������� > 
            //        < ������� > 
            //        < ����� �������� >

            //������������� ����������� � ���� �������� �����(����� ����� � �����, ������� ����� � �������).
            //� ������ �������� �� ������ ����� ������������� �� 4 ��������. ��� ������� �� 4 ��������� ���� 
            //����� ���� ������� � ���������� �������������� � ������� �������� � ���: �������������(��������� � ����� �������� �������),
            //����� ��������, ����� ��������, ������� ������. �������, ��� � ������ �������� ������ 
            //��� ������������� ����� ��������� ��������. �������� � ������ ���������� �������� �� ��������� ������ 
            //� ������������� �� �������� ������� �������������(����� �������� ��� ���������� �� ���������). 
            //���� � ����� - ���� �������� ����� ����������� ������ ����, �� �������� � ���������� ����� ���� ����������� ����� ��������.

            Task("LinqObj31");

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => new
                {
                    surname = x.Split(' ')[1],
                    debt = double.Parse(x.Split(' ')[0], CultureInfo.InvariantCulture),
                    flat = int.Parse(x.Split(' ')[2]),
                    entrance = (int.Parse(x.Split(' ')[2]) - 1) / 36 + 1
                })
                .GroupBy(x => x.entrance)
                .SelectMany(x => x.OrderByDescending(d => d.debt).Take(3))
                .OrderByDescending(d => d.debt)
                .Select(x => $"{x.debt.ToString("0.00", CultureInfo.InvariantCulture)} {x.entrance} {x.flat} {x.surname}");

            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
