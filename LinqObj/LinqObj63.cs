// File: "LinqObj63"
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
            //LinqObj63�. �������� ������������������ �������� �������� �� ������� �������� �� ���� ���������: �������,
            //��������� � ������. ������ ������� ������������������ �������� ������ �� ����� ������ � �������� ��������� ����:

                //< �������� �������� >
                //< ������� >
                //< �������� >
                //< ����� >
                //< ������ >

            //������ �������������(� ����������� �������� � ����������) ����� �������� ���.����� �������� ����� ������,
            //������ � ����� ����� � ��������� 2�5.�������� �������� ����������� � ��������� �����.������� �������� �� ��������,
            //������� �� ������� ������� ������ �� ����� 4: �������, ��������, ����� ������ � ������� ������ �� �������(���������
            //� ����� �������� �������).��� ��������, �� ������� �� ����� ������ �� �������, ������� ������� ������ ������ 0.00.
            //�������� � ������ �������� �������� �� ��������� ������ � ����������� � ���������� ������� �� ������� � ���������.
            //���� �� ���� �� �������� �� ������������� ��������� ��������, �� �������� � �������������� ���� ����� �Students not found�. 
            Task("LinqObj63");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => x[1] + ' ' + x[2])
                .Select(x => new
                {
                    student = x.Key,
                    alg = x.Where(a => a[0] == "Algebra")
                                   .Select(a => int.Parse(a[4]))
                                   .DefaultIfEmpty()
                                   .Average(),
                    cl = x.Select(c => c[3]).First()
                })
                .Where(x => x.alg <= 4)
                .OrderBy(x => x.student)
                .Select(x => $"{x.student} {x.cl} {x.alg.ToString("0.00", CultureInfo.InvariantCulture)}")
                .DefaultIfEmpty("Students not found");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
