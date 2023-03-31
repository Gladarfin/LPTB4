// File: "LinqObj67"
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
            //LinqObj67�. �������� ������������������ �������� �������� �� ������� �������� �� ���� ���������:
            //�������, ��������� � ������. ������ ������� ������������������ �������� ������ �� ����� ������ � �������� ��������� ����:

                //< ����� >
                //< �������� �������� >
                //< ������� >
                //< �������� >
                //< ������ >

            //������ �������������(� ����������� �������� � ����������) ����� �������� ���. ����� �������� ����� ������,
            //������ � ����� ����� � ��������� 2�5.�������� �������� ����������� � ��������� �����.����� ���� ���������� � ��������,
            //���������� ���� �� ���� ������ �� ������ - ���� ��������.������� �������� � ������ �� ����������: ����� ������, �������,
            //�������� � ���������� ����� �����. �������� � ������ ��������� �������� �� ��������� ������ � ����������� �� ��������
            //�������, � ��� ���������� ������� � � ���������� ������� ������� � ���������. ���� � ������ �������� ������ ��� ��
            //����� ������, �� �������� � �������������� ���� ����� �Students not found�. 

            Task("LinqObj67");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(st => st[2] + ' ' + st[3])
                .Select(x => new { student = x.Key, 
                                   ds = x.Where(y => int.Parse(y[4]) == 2).Count(),
                                   cl = x.Select(c => int.Parse(c[0])).First()
                })
                .Where(x => x.ds > 0)
                .OrderByDescending(x => x.cl)
                .ThenBy(x => x.student)
                .Select(x => $"{x.cl} {x.student} {x.ds}")
                .DefaultIfEmpty("Students not found");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
