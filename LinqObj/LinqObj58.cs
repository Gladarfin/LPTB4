// File: "LinqObj58"
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
            //LinqObj58�. �������� ������������������ �������� �������� � ����������� ����� ��������� ��� �� ����������,
            //�������� ����� � ����������� (� ��������� �������). ������ ������� ������������������ �������� ��������� ����:

            //  < ������� >
            //  < �������� >
            //  < ����� ����� >
            //  < ����� ��� >

            //����� ��� ������������ ����� ��� ����� ����� � ��������� �� 0 �� 100, ������� ���������� ���� �� ����� ����� ��������.
            //��� ������ ����� ����� ���� ������ ��������(� ���������� �������), ��������� ����� 50 ������ ���� �� �� ������ ��
            //���������, � ������� �� �������, �������� � ����� �����.�������� � ������ �������� �������� �� ��������� ������ �
            //������������� � ���������� ������� ������� � ���������, � ��� �� ���������� � �� ����������� ������ �����. ���� ���
            //��������� ����� ������� ����� ���� ��������, ��������������� ��������� ��������, �� ������� �������� ��� ���� �����
            //��������. ���� � �������� ������ ��� �� ������ ���������, ���������������� ��������� ��������, �� �������� �
            //�������������� ���� ����� �Students not found�. 

            Task("LinqObj58");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[2]),
                        (x, y) => new {
                            students = y.Select(g => new {
                                school = x,
                                fullname = g[0] + ' ' + g[1],
                                math = int.Parse(g[3]),
                                rus = int.Parse(g[4]),
                                inf = int.Parse(g[5])
                            }).Where(s => s.math < 50 || s.rus < 50 || s.inf < 50)
                              .OrderBy(f => f.fullname)
                              .Take(3)
                        })
                .SelectMany(x => x.students)
                .OrderBy(x => x.fullname)
                .ThenBy(x => x.school)
                .Select(x => $"{x.fullname} {x.school}")
                .DefaultIfEmpty("Students not found");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
