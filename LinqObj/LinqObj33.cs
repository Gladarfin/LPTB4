// File: "LinqObj33"
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
            //LinqObj33�. �������� ������������������ �������� �������� � ����������� �� ������ ������������ �����, 
            //������� � 144 - ���������� 9 - ������� ����.������ ������� ������������������ �������� ��������� ����:

            //    < ����� �������� > 
            //    < ������������� > 
            //    < ������� >

            //������������� ����������� � ���� �������� �����(����� ����� � �����, ������� ����� � �������).
            //� ������ �������� �� ������ ����� ������������� �� 4 ��������.����� �������, ���� ������� �� ������ �������� 
            //������� ������������� �� ����, � ������� �������� � ���: ����� ��������, �������, ������������� 
            //(��������� � ����� �������� �������). ������, �� ������� �����, ��� ���������� ������� ������������� �� �����������. 
            //�������� � ������ ���������� �������� �� ��������� ������ � ������������� �� ����������� ������� �������. 

            Task("LinqObj33");
            var f = File.ReadAllLines(GetString(), Encoding.Default);
            var avg = f.Where(y => double.Parse(y.Split(' ')[1]) > 0).Average(x => double.Parse(x.Split(' ')[1], CultureInfo.InvariantCulture));
            var r = f
                .Select(x => new
                {
                    surname = x.Split(' ')[2],
                    flat = int.Parse(x.Split(' ')[0]),
                    debt = double.Parse(x.Split(' ')[1], CultureInfo.InvariantCulture),
                })
                .Where(y => y.debt >= avg)
                .OrderBy(x => x.flat)
                .Select(x => $"{x.flat} {x.surname} {x.debt.ToString("0.00", CultureInfo.InvariantCulture)}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
