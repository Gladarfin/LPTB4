// File: "LinqObj27"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            //LinqObj27�. �������� ������������������ �������� �������� � ����������� �� ������ ������������ �����, 
            //������� � 144 - ���������� 9 - ������� ����.������ ������� ������������������ �������� ��������� ����:

            //    < ������� > 
            //    < ����� �������� > 
            //    < ������������� >

            //������������� ����������� � ���� �������� �����(����� ����� � �����, ������� ����� � �������).
            //� ������ �������� �� ������ ����� ������������� �� 4 ��������.��� ������� �� 9 ������ ���� ������� 
            //�������� � �����������, ������� �� ���� �����: ����� �����������, ����� �����, ��������� ������������� 
            //��� ������� ����� �����(��������� � ����� �������� �������). �������� � ������ ����� �������� �� ��������� 
            //������ � ������������� �� ����������� ����� �����������, � ��� ����������� ����� � �� ����������� �����.
            //���� �� ����� - ���� ����� ���������� �����������, �� ������ �� ���� ����� �� ��������.

            Task("LinqObj27");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => new
                {
                    debt = double.Parse(x.Split(' ')[2], CultureInfo.InvariantCulture),
                    floor = (int.Parse(x.Split(' ')[1]) - 1) % 36 / 4 + 1
                })
                .Where(d => d.debt != 0)
                .GroupBy(x => x.floor)
                .OrderBy(x => x.Count())
                .ThenBy(x => x.Key)
                .Select(x => x.Count().ToString() + ' ' 
                + x.Key.ToString() + ' ' 
                + x.Sum(d => d.debt).ToString("0.00", CultureInfo.InvariantCulture));

           File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
