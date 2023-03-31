// File: "LinqObj49"
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
            //LinqObj49�. �������� ������������������ �������� �������� � ����������� ����� ��������� ��� �� ����������,
            //�������� ����� � ����������� (� ��������� �������). ������ ������� ������������������ �������� ��������� ����:

                //< ������� >
                //< �������� >
                //< ����� ����� >
                //< ����� ��� >

            //����� ��� ������������ ����� ��� ����� ����� � ��������� �� 0 �� 100, ������� ���������� ���� �� ����� ����� ��������.
            //���������� ���������� ��������� ���� � ������� ���.������� ����� �������� ��� ���� ��������, ���������� ����������
            //��������� ����(��� ������� ��������� ��������� �������, �������� � ����� �����).�������� � ������ �������� ��������
            //�� ��������� ������ � ����������� � ������� �� ���������� � �������� ������. 

            Task("LinqObj49");
            var f = File.ReadAllLines(GetString(), Encoding.Default).Select(x => x.Split(' '));
            var min = f.Select(y => int.Parse(y[3]) + int.Parse(y[4]) + int.Parse(y[5])).Show().Min();
            var r = f
                .GroupBy(x => new { fullName = x[0] + ' ' + x[1] },
                         (x, y) => new { fullname = x.fullName, 
                                         sum = y.Select(yy => int.Parse(yy[3]) + int.Parse(yy[4]) + int.Parse(yy[5])).First(), 
                                         school = y.Select(yy => yy[2]).First() })
                .Where(x => x.sum == min)
                .Select(x => $"{x.fullname} {x.school}");

            var result = r.Select(x => x).Prepend(min.ToString());
            File.WriteAllLines(GetString(), result, Encoding.Default);
        }
    }
}
