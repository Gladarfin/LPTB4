// File: "LinqObj62"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            //LinqObj62�. �������� ������������������ �������� �������� �� ������� �������� �� ���� ���������: �������,
            //��������� � ������. ������ ������� ������������������ �������� ������ �� ����� ������ � �������� ��������� ����:

                //< ����� >
                //< ������� >
                //< �������� >
                //< ������ >
                //< �������� �������� >

            //������ �������������(� ����������� �������� � ����������) ����� �������� ���. ����� �������� ����� ������,
            //������ � ����� ����� � ��������� 2�5.�������� �������� ����������� � ��������� �����.��� ������� ��������� ����������
            //���������� ������ �� ������� ��������(���� �� ������ - ���� �������� �������� �� ������� �� ����� ������,
            //�� ������� ��� ����� �������� ����� 0).�������� � ������ �������� �������� �� ��������� ������, �������� �����,
            //�������, �������� � ���������� ������ �� �������, ��������� � ������.������ ����������� � ������� �����������
            //������ ������, � ��� ���������� ������� � � ���������� ������� ������� � ���������. 
            Task("LinqObj62");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => x[1] + ' ' + x[2])
                .Select(x => new
                {
                    student = x.Key,
                    alg = x.Where(a => a[4] == "Algebra").Select(a => int.Parse(a[3])).Count(),
                    geo = x.Where(a => a[4] == "Geometry").Select(a => int.Parse(a[3])).Count(),
                    phy = x.Where(a => a[4] == "Physics").Select(a => int.Parse(a[3])).Count(),
                    cl = x.Select(c => int.Parse(c[0])).First()
                })
                .OrderBy(x => x.cl)
                .ThenBy(x => x.student)
                .Select(x => $"{x.cl} {x.student} {x.alg} {x.geo} {x.phy}");
              
            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
