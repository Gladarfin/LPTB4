// File: "LinqObj64"
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
            //LinqObj64�. �������� ������������������ �������� �������� �� ������� �������� �� ���� ���������: �������,
            //��������� � ������. ������ ������� ������������������ �������� ������ �� ����� ������ � �������� ��������� ����:

            //  < ����� >
            //  < ������� >
            //  < �������� >
            //  < �������� �������� >
            //  < ������ >

            //������ �������������(� ����������� �������� � ����������) ����� �������� ���.����� �������� ����� ������,
            //������ � ����� ����� � ��������� 2�5.�������� �������� ����������� � ��������� �����.������� �������� �� ��������,
            //������� �� ������ ������� ������ �� ����� 4: ����� ������, �������, �������� � ������� ������ �� ������(��������� � �����
            //�������� �������).�������� � ������ �������� �������� �� ��������� ������ � ����������� � ������� ����������� �������,
            //� ��� ���������� ������� � � ���������� ������� ������� � ���������. ���� �� ���� �� �������� �� ������������� ���������
            //��������, �� �������� � �������������� ���� ����� �Students not found�. 

            Task("LinqObj64");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => x[1] + ' ' + x[2])
                .Select(x => new
                {
                    student = x.Key,
                    phy = x.Where(a => a[3] == "Physics")
                                   .Select(a => int.Parse(a[4]))
                                   .DefaultIfEmpty()
                                   .Average(),
                    cl = x.Select(c => int.Parse(c[0])).First()
                })
                .Where(x => x.phy >= 4)
                .OrderBy(x => x.cl)
                .ThenBy(x => x.student)
                .Select(x => $"{x.cl} {x.student} {x.phy.ToString("0.00", CultureInfo.InvariantCulture)}")
                .DefaultIfEmpty("Students not found");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
