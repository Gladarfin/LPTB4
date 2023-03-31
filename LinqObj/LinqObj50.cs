// File: "LinqObj50"
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

            //LinqObj50�. �������� ������������������ �������� �������� � ����������� ����� ��������� ��� �� ����������,
            //�������� ����� � ����������� (� ��������� �������). ������ ������� ������������������ �������� ��������� ����:

            //      < ������� >
            //      < �������� >
            //      < ����� ��� >
            //      < ����� ����� >

            //����� ��� ������������ ����� ��� ����� ����� � ��������� �� 0 �� 100, ������� ���������� ���� �� ����� ����� ��������.
            //���������� ��� ���������� ��������� ����� � ������� ��� ����� �� ����� ������ � ������� ��������(�������, ��� � ��������
            //������ ������ ������������ �������� � ���������� ���������� �������).����� ������� �������� ��� ���� ��������,
            //���������� ���� �� ���� ���������� ��������� ������(��� ������� ��������� ��������� �������, �������� � ��������� ����).
            //�������� � ������ �������� �������� �� ��������� ������ � ����������� � ������� �� ���������� � �������� ������. 
            
            Task("LinqObj50");
            var f = File.ReadAllLines(GetString(), Encoding.Default).Select(x => x.Split(' '));
            var max = f.Select(y => int.Parse(y[2]) + int.Parse(y[3]) + int.Parse(y[4]))
                .Distinct()
                .OrderByDescending(x => x)
                .Take(2)
                .ToArray();
            var r = f
                .GroupBy(x => new { fullName = x[0] + ' ' + x[1] },
                         (x, y) => new {
                             fullname = x.fullName,
                             sum = y.Select(yy => int.Parse(yy[2]) + int.Parse(yy[3]) + int.Parse(yy[4])).First()
                         })
                .Where(x => x.sum == max[0] || x.sum == max[1])
                .Select(x => $"{x.fullname} {x.sum}");

            var result = r.Select(x => x).Prepend($"{max[0]} {max[1]}");
            File.WriteAllLines(GetString(), result, Encoding.Default);
        }
    }
}
