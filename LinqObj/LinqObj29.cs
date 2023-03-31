// File: "LinqObj29"
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
            //LinqObj29�. �������� ������������������ �������� �������� � ����������� �� ������ ������������ �����, 
            //������� � 144 - ���������� 9 - ������� ����.������ ������� ������������������ �������� ��������� ����:

            //    < ����� �������� > 
            //    < ������� > 
            //    < ������������� >

            //������������� ����������� � ���� �������� �����(����� ����� � �����, ������� ����� � �������).
            //� ������ �������� �� ������ ����� ������������� �� 4 ��������.��� ������� �� 4 ��������� ���� 
            //����� ������ � ���������� �������������� � ������� �������� � ���: ����� ��������, ����� ��������, 
            //������� ������, ������������� (��������� � ����� �������� �������). �������, ��� � ������ �������� 
            //������ ��� ������������� ����� ��������� ��������. �������� � ������ ���������� �������� �� ��������� 
            //������ � ������������� �� ����������� ������ ��������. ���� � ����� - ���� �������� ���������� �����������, 
            //�� ������ �� ���� �������� �� ��������.

            Task("LinqObj29");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => new
                {
                    surname = x.Split(' ')[1],
                    debt = double.Parse(x.Split(' ')[2], CultureInfo.InvariantCulture),
                    entrance = (int.Parse(x.Split(' ')[0]) - 1) / 36 + 1,
                    flatNumber = x.Split(' ')[0]
                })
                .GroupBy(x => x.entrance)
                .OrderBy(x => x.Key)
                .Select(group => group.OrderByDescending(g => g.debt).First())
                .Select(x => $"{x.entrance} {x.flatNumber} {x.surname} {x.debt.ToString("0.00", CultureInfo.InvariantCulture)}");
     

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
