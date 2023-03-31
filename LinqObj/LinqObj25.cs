// File: "LinqObj25"
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
            Task("LinqObj25");

            //LinqObj25�. �������� ������������������ �������� �������� � ����������� �� ������ ������������ �����, 
            //������� � 144 - ���������� 9 - ������� ����.������ ������� ������������������ �������� ��������� ����:

            //        < ������� > 
            //        < ������������� > 
            //        < ����� �������� >

            //������������� ����������� � ���� �������� �����(����� ����� � �����, ������� ����� � �������).� ������ 
            //�������� �� ������ ����� ������������� �� 4 ��������.����� ����� ��������, ������ �������� ����� ���������� 
            //��������� �������������, � ������� ���� ����� ������ � �������� ��������� �������������(��������� � ����� �������� �������). 
            //�������, ��� ��������� ������������� ��� ���� ��������� ����� ��������� ��������.


            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => new { 
                    surname = x.Split(' ')[0], 
                    debt = double.Parse(x.Split(' ')[1], CultureInfo.InvariantCulture), 
                    entrance = (int.Parse(x.Split(' ')[2]) - 1) / 36 + 1 
                })
                .GroupBy(x => x.entrance,
                        (x,y) => new {entrance = x, debt = y.Sum(s => s.debt)})
                .OrderByDescending(d => d.debt)
                .Select(x => x.entrance.ToString() + ' ' + x.debt.ToString("0.00", CultureInfo.InvariantCulture))
                .Take(1);

           File.WriteAllLines(GetString(), r, Encoding.Default);


        }
    }
}
