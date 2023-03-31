// File: "LinqObj61"
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
            //LinqObj61�. �������� ������������������ �������� �������� �� ������� �������� �� ���� ���������: �������,
            //��������� � ������. ������ ������� ������������������ �������� ������ �� ����� ������ � �������� ��������� ����:

                //< ������� >
                //< �������� >
                //< ����� >
                //< �������� �������� >
                //< ������ >

            //������ �������������(� ����������� �������� � ����������) ����� �������� ���. ����� �������� ����� ������,
            //������ � ����� ����� � ��������� 2�5.�������� �������� ����������� � ��������� �����.��� ������� ��������� ����������
            //������� ������ �� ������� �������� � ������� �� � ����� �������� �������(���� �� ������-���� �������� �������� ��
            //������� �� ����� ������, �� ������� ��� ����� �������� 0.00). �������� � ������ �������� �������� �� ��������� ������,
            //�������� �������, �������� � ������� ������ �� �������, ��������� � ������. ������ ����������� � ���������� �������
            //������� � ���������. 

            Task("LinqObj61");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => x[0] + ' ' + x[1])
                .Select(x => new { student = x.Key,
                            alg = x.Where(a => a[3] == "Algebra").Select(a => int.Parse(a[4])).DefaultIfEmpty().Average().ToString("0.00", CultureInfo.InvariantCulture),
                            geo = x.Where(a => a[3] == "Geometry").Select(a => int.Parse(a[4])).DefaultIfEmpty().Average().ToString("0.00", CultureInfo.InvariantCulture),
                            phy = x.Where(a => a[3] == "Physics").Select(a => int.Parse(a[4])).DefaultIfEmpty().Average().ToString("0.00", CultureInfo.InvariantCulture)
                })
                .OrderBy(x => x.student)
                .Select(x => $"{x.student} {x.alg} {x.geo} {x.phy}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
