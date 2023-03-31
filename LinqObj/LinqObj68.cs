// File: "LinqObj68"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            //LinqObj68�. �������� ������������������ �������� �������� �� ������� �������� �� ���� ���������: �������,
            //��������� � ������. ������ ������� ������������������ �������� ������ �� ����� ������ � �������� ��������� ����:

                //< ����� >
                //< ������ >
                //< ������� >
                //< �������� >
                //< �������� �������� >

            //������ �������������(� ����������� �������� � ����������) ����� �������� ���.����� �������� ����� ������,
            //������ � ����� ����� � ��������� 2�5.�������� �������� ����������� � ��������� �����.����� ���� ���������� � ��������,
            //�� ���������� �� ����� ������ � ������, �� ������� ���� �� ���� �������� �� ������-���� ��������.������� ��������
            //� ������ ���������: ���������� ����� ��������, �������, �������� � ����� ������. �������� � ������ �������� ��������
            //�� ��������� ������ � ����������� �� ����������� ���������� ��������, � ��� �� ��������� � � ���������� ������� �������
            //� ���������. ���� � ������ �������� ������ ��� �� ������ ���������, ���������������� ��������� ��������, �� ��������
            //� �������������� ���� ����� �Students not found�. 

            Task("LinqObj68");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(st => st[2] + ' ' + st[3])
                .Select(x => new {
                    student = x.Key,
                    ds = x.Where(y => int.Parse(y[1]) == 2 || int.Parse(y[1]) == 3).Count(),
                    bs = x.Where(y => int.Parse(y[1]) == 4).Count(),
                    cl = x.Select(c => int.Parse(c[0])).First()
                })
                .Where(x => x.ds == 0 && x.bs > 0)
                .OrderBy(x => x.bs)
                .ThenBy(x => x.student)
                .Select(x => $"{x.bs} {x.student} {x.cl}")
                .DefaultIfEmpty("Students not found");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
