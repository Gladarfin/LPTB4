// File: "LinqObj53"
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
            //LinqObj53�. �������� ������������������ �������� �������� � ����������� ����� ��������� ��� �� ����������,
            //�������� ����� � ����������� (� ��������� �������). ������ ������� ������������������ �������� ��������� ����:

                //< ������� >
                //< �������� >
                //< ����� ����� >
                //< ����� ��� >

            //����� ��� ������������ ����� ��� ����� ����� � ��������� �� 0 �� 100, ������� ���������� ���� �� ����� ����� ��������.
            //��� ������ ����� ���������� ���������� ��������, ��������� ���� ������� ��������� 150 ������(������� ��������� ����������
            //��������, ��������� � ����� ����� 150 ������, ����� ����� �����; ���������� �������� ����� ���� ����� 0). ��������
            //� ������ ����� �������� �� ����� ������ � ������������� �� �������� ���������� ��������, � ��� ����������� ����������
            //� �� ����������� ������ �����. 

            Task("LinqObj53");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[2]),
                        (x, y) => new
                        {
                            school = x,
                            studentsCount = y.Select(f => int.Parse(f[3]) + int.Parse(f[4]) + int.Parse(f[5]))
                                                                   .Count(s => s > 150)
                        }
                        )
                .OrderByDescending(x => x.studentsCount)
                .ThenBy(x => x.school)
                .Select(x => $"{x.studentsCount} {x.school}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
