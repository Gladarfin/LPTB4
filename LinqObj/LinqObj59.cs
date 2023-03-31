// File: "LinqObj59"
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
            //LinqObj59�. �������� ������������������ �������� �������� � ����������� ����� ��������� ��� �� ����������, �������� ����� � �����������(� ��������� �������). ������ ������� ������������������ �������� ��������� ����:

            //< ����� ����� >
            //< ����� ��� >
            //< ������� >
            //< �������� >

            //����� ��� ������������ ����� ��� ����� ����� � ��������� �� 0 �� 100, ������� ���������� ���� �� ����� ����� ��������.
            //��� ������ ����� � ������� �������� ���������� ���������� ��������, ��������� �� ����� 50 ������ �� ����� ��������
            //(������� ��������� ����� �����, ����� ��� ����� � ���������� �������� ���� �����, ��������� ��������� ����� ������
            //�� ����������, �������� ����� � �����������; ��������� �� ����� ����� ���� ����� 0). �������� � ������ ����� ��������
            //�� ����� ������ � ������������� �� ����������� ������ �����. 
            Task("LinqObj59");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[0]),
                        (x, y) => new {school = x, 
                                       math = y.Select(m => int.Parse(m[1])).Count(mm => mm >= 50),
                                       rus = y.Select(ru => int.Parse(ru[2])).Count(rr => rr >= 50),
                                       inf = y.Select(i => int.Parse(i[3])).Count(ii => ii >= 50)
                        })
                .OrderBy(x => x.school)
                .Select(x => $"{x.school} {x.math} {x.rus} {x.inf}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
