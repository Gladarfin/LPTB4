// File: "LinqObj54"
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
            //LinqObj54�. �������� ������������������ �������� �������� � ����������� ����� ��������� ��� �� ����������,
            //�������� ����� � �����������(� ��������� �������). ������ ������� ������������������ �������� ��������� ����:
    
                //< ����� ��� >
                //< ����� ����� >
                //< ������� >
                //< �������� >

            //����� ��� ������������ ����� ��� ����� ����� � ��������� �� 0 �� 100, ������� ���������� ���� �� ����� ����� ��������.
            //��� ������ ����� ����� ������� �������� ���������� ����� ���, ���������� ��������� ���� �����(������� �������� ��������
            //����� ������ � ����������� ������� ������ ����� ������ ���� �������� �� ���������� ��������). �������� � ������ �����
            //�������� �� ��������� ������, �������� ������� ��������� ���� ��� � ����� �����.������ ������������� �� ��������
            //�������� �����, � ��� ������ ��������� �������� ����� � �� ����������� ������ �����. 

            Task("LinqObj54");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[3]),
                        (x, y) => new
                        {
                            school = x,
                            avgGrade = y.Select(g => int.Parse(g[0]) + int.Parse(g[1]) + int.Parse(g[2])).Sum() / y.Count()
                        })
                .OrderByDescending(x => x.avgGrade)
                .ThenBy(x => x.school)
                .Select(x => $"{x.avgGrade} {x.school}");                


            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
