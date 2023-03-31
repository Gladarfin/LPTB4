// File: "LinqObj60"
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
            //LinqObj60�. �������� ������������������ �������� �������� � ����������� ����� ��������� ��� �� ����������,
            //�������� ����� � ����������� (� ��������� �������). ������ ������� ������������������ �������� ��������� ����:

                //< ������� >
                //< �������� >
                //< ����� ��� >
                //< ����� ����� >

            //����� ��� ������������ ����� ��� ����� ����� � ��������� �� 0 �� 100, ������� ���������� ���� �� ����� ����� ��������.
            //��� ������ ����� � ������� �������� ����� ������� �������� ����� ���, ���������� ��������� ���� �����(������� ��������
            //�������� ����� ������ � ����������� ������� ������ ����� ������ ���� �������� �� ���������� ��������). �������� � ������
            //����� �������� �� ��������� ������, �������� ����� ����� � ������� ����� �� ����������, �������� ����� � �����������.
            //������ ������������� �� �������� ������ �����. 
            Task("LinqObj60");
            Task("LinqObj59");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[5]),
                        (x, y) => new {
                            school = x,
                            math = Math.Truncate(y.Select(m => int.Parse(m[2])).Average()),
                            rus = Math.Truncate(y.Select(ru => int.Parse(ru[3])).Average()),
                            inf = Math.Truncate(y.Select(i => int.Parse(i[4])).Average())
                        })
                .OrderByDescending(x => x.school)
                .Select(x => $"{x.school} {x.math} {x.rus} {x.inf}");

            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
