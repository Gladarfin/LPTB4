// File: "LinqObj26"
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
            //LinqObj26�. �������� ������������������ �������� �������� � ����������� �� ������ ������������ �����, 
            //������� � 144 - ���������� 9 - ������� ����.������ ������� ������������������ �������� ��������� ����:

            //    < ����� �������� > 
            //    < ������� > 
            //    < ������������� >

            //������������� ����������� � ���� �������� �����(����� ����� � �����, ������� ����� � �������).
            //� ������ �������� �� ������ ����� ������������� �� 4 ��������.��� ������� �� 4 ��������� ���� 
            //������� �������� � �����������, ������� � ���� ��������: ����� ��������, ����� �����������, 
            //������� ������������� ��� ������� ����� ��������(��������� � ����� �������� �������). 
            //������, �� ������� �����, ��� ���������� ������� ������������� �� �����������. �������� � ������ 
            //�������� �������� �� ��������� ������ � ������������� �� ����������� ������ ��������. 
            //���� � ����� - ���� �������� ���������� �����������, �� ������ �� ���� �������� �� ��������.

            Task("LinqObj26");

            var r = File.ReadAllLines(GetString(), Encoding.Default).Show()
            .Select(x => new
            {
                debt = double.Parse(x.Split(' ')[2], CultureInfo.InvariantCulture),
                entrance = (int.Parse(x.Split(' ')[0]) - 1) / 36 + 1
            })
            .Where(d => d.debt != 0)
            .GroupBy(x => x.entrance)
            .OrderBy(g => g.Key)
            .Select(y => y.Key.ToString() + ' ' 
            + y.Count().ToString() + ' ' 
            + y.Average(yy => yy.debt).ToString("0.00", CultureInfo.InvariantCulture));
            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
