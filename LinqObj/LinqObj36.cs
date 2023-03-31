// File: "LinqObj36"
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
            //LinqObj36�. �������� ������������������ �������� �������� � ����������� �� ������ ������������ �����, 
            //������� � 144 - ���������� 9 - ������� ����.������ ������� ������������������ �������� ��������� ����:

            //    < ����� �������� > 
            //    < ������� > 
            //    < ������������� >

            //������������� ����������� � ���� �������� �����(����� ����� � �����, ������� ����� � �������).
            //� ������ �������� �� ������ ����� ������������� �� 4 ��������.��� ������� �� 9 ������ ���� ����� �����������, 
            //���� ������� �� ������ �������� ������� ������������� �� ������� �����, � ������� �������� � ���: ����� �����, 
            //������������� (��������� � ����� �������� �������), �������, ����� ��������.������, �� ������� �����, 
            //��� ���������� ������� ������������� �� �����������. �������� � ������ ���������� �������� �� ��������� ������ � 
            //������������� �� ����������� ������� ������, � ��� ���������� ������ � �� ����������� ������� �������������. 
            //�������, ��� � ������ �������� ������ ��� ������������� ����� ��������� ��������. 

            Task("LinqObj36");

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => new
                {
                    surname = x.Split(' ')[1],
                    flat = int.Parse(x.Split(' ')[0]),
                    debt = double.Parse(x.Split(' ')[2], CultureInfo.InvariantCulture),
                    floor = (int.Parse(x.Split(' ')[0]) - 1) % 36 / 4 + 1
                })
                .GroupBy(x => x.floor)
                .OrderBy(x => x.Key)
                .SelectMany(x => x.OrderBy(y => y.debt).Where(d =>
                                                                  d.debt <=
                                                                  x.Where(de => de.debt > 0).Average(de => de.debt)
                                                        )
                )
                .Select(x => $"{x.floor} {x.debt.ToString("0.00", CultureInfo.InvariantCulture)} {x.surname} {x.flat}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
