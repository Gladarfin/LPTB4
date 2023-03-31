// File: "LinqObj56"
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

            //LinqObj56�. �������� ������������������ �������� �������� � ����������� ����� ��������� ��� �� ����������,
            //�������� ����� � ����������� (� ��������� �������). ������ ������� ������������������ �������� ��������� ����:

            //< ������� >
            //< �������� >
            //< ����� ��� >
            //< ����� ����� >

            //����� ��� ������������ ����� ��� ����� ����� � ��������� �� 0 �� 100, ������� ���������� ���� �� ����� ����� ��������.
            //������� �������� �� ��������, ��������� ����� 90 ������ ���� �� �� ������ �� ���������(������� ��������� ������� �
            //��������, ����� ����� �����).�������� � ������ �������� �������� �� ��������� ������ � ����������� � ���������� �������
            //������� � ���������, � ��� �� ���������� � �� ����������� ������ �����. ���� �� ���� �� �������� �� �������������
            //��������� ��������, �� �������� � �������������� ���� ����� �Students not found�. 

            Task("LinqObj56");

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .Select(x => new
                {
                    student = x[0] + ' ' + x[1],
                    math = int.Parse(x[2]),
                    rus = int.Parse(x[3]),
                    inf = int.Parse(x[4]),
                    school = x[5]
                })
                .Where(y => y.math > 90 || y.rus > 90 || y.inf > 90)
                .OrderBy(x => x.student)
                .ThenBy(x => x.school)
                .Select(x => $"{x.student} {x.school}")
                .DefaultIfEmpty("Students not found");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
