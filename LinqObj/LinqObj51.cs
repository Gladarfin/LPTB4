// File: "LinqObj51"
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
            //LinqObj51�. �������� ������������������ �������� �������� � ����������� ����� ��������� ��� �� ����������,
            //�������� ����� � ����������� (� ��������� �������). ������ ������� ������������������ �������� ��������� ����:

            //  < ����� ��� >
            //  < ������� >
            //  < �������� >
            //  < ����� ����� >

            //����� ��� ������������ ����� ��� ����� ����� � ��������� �� 0 �� 100, ������� ���������� ���� �� ����� ����� ��������.
            //��� ������ ����� ������� �������� �� ��������, ��������� ���������� ���� ��� �� ����������� ����� �������� ���� �����.
            //���� ����� �������� ���������, �� ������� �������� � ������ �������� � ������� �� ���������� � �������� ������.
            //�������� � ������ �������� �������� �� ��������� ������, �������� ����� �����, ������� ���������, ��� �������� � ���� ���
            //�� �����������.������ ������������� �� ����������� ������ �����. 


            Task("LinqObj51");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[5]),
                        (x,y) => new { school = x, bestStudent = y.OrderByDescending(s => int.Parse(s[2])).First() })
                .OrderBy(x => x.school)
                .Select(x => $"{x.school} {x.bestStudent[3]} {x.bestStudent[4]} {x.bestStudent[2]}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
