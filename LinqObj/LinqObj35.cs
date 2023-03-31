// File: "LinqObj35"
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
            //LinqObj35�. �������� ������������������ �������� �������� � ����������� �� ������ ������������ �����, 
            //������� � 144 - ���������� 9 - ������� ����.������ ������� ������������������ �������� ��������� ����:

            //    < ������������� > 
            //    < ������� > 
            //    < ����� �������� >

            //������������� ����������� � ���� �������� �����(����� ����� � �����, ������� ����� � �������).
            //� ������ �������� �� ������ ����� ������������� �� 4 ��������.��� ������� �� 4 ��������� ���� 
            //����� �����������, ���� ������� �� ������ �������� ������� ������������� �� ������� ��������, 
            //� ������� �������� � ���: ����� ��������, ������������� (��������� � ����� �������� �������), 
            //�������, ����� ��������.������, �� ������� �����, ��� ���������� ������� ������������� �� �����������. 
            //�������� � ������ ���������� �������� �� ��������� ������ � ������������� �� ����������� ������� ���������, 
            //� ��� ���������� ��������� � �� �������� ������� �������������. �������, ��� � ������ �������� ������ 
            //��� ������������� ����� ��������� ��������. 

            Task("LinqObj35");

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => new
                {
                    surname = x.Split(' ')[1],
                    flat = int.Parse(x.Split(' ')[2]),
                    debt = double.Parse(x.Split(' ')[0], CultureInfo.InvariantCulture),
                    entrance = (int.Parse(x.Split(' ')[2]) - 1) / 36 + 1
                })
                .GroupBy(x => x.entrance)
                .OrderBy(x => x.Key)
                .SelectMany(x => x.OrderByDescending(y => y.debt).Where(d => 
                                                                            d.debt >= 
                                                                            x.Where(de => de.debt > 0).Average(de => de.debt)
                                                                  )
                )
                .Select(x => $"{x.entrance} {x.debt.ToString("0.00", CultureInfo.InvariantCulture)} {x.surname} {x.flat}");

            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
