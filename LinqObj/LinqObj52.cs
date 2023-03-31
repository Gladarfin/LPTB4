// File: "LinqObj52"
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
            //LinqObj52�. �������� ������������������ �������� �������� � ����������� ����� ��������� ��� �� ����������,
            //�������� ����� � ����������� (� ��������� �������). ������ ������� ������������������ �������� ��������� ����:

                //< ����� ����� >
                //< ������� >
                //< �������� >
                //< ����� ��� >

            //����� ��� ������������ ����� ��� ����� ����� � ��������� �� 0 �� 100, ������� ���������� ���� �� ����� ����� ��������.
            //��� ������ ����� ������� �������� �� ��������, ��������� ���������� ��������� ���� ��� ����� �������� ���� �����.
            //���� ����� �������� ���������, �� ������� �������� � ������ �������� � ���������� ������� �� ������� � ���������.
            //�������� � ������ �������� �������� �� ��������� ������, �������� ����� �����, ��������� ���� ���, ������� ���������
            //� ��� ��������. ������ ������������� �� �������� ������ �����. 

            Task("LinqObj52");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[0]),
                        (x, y) => new
                        {
                            school = x,
                            studentWithMin = y.Select(d => new {
                                                                grade = int.Parse(d[3]) + int.Parse(d[4]) + int.Parse(d[5]),
                                                                fullName = d[1] + ' ' + d[2] 
                                                               })
                                              .OrderBy(g => g.grade)
                                              .ThenBy(fn => fn.fullName).First()
                        })
                .OrderByDescending(x => x.school)
                .Select(x => $"{x.school} {x.studentWithMin.grade} {x.studentWithMin.fullName}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
