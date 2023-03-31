// File: "LinqObj55"
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
            //LinqObj55�. �������� ������������������ �������� �������� � ����������� ����� ��������� ��� �� ����������,
            //�������� ����� � �����������(� ��������� �������). ������ ������� ������������������ �������� ��������� ����:

                //< ����� ��� >
                //< ������� >
                //< �������� >
                //< ����� ����� >

            //����� ��� ������������ ����� ��� ����� ����� � ��������� �� 0 �� 100, ������� ���������� ���� �� ����� ����� ��������.
            //������� �������� �� ��������, ��������� �� ����� 50 ������ �� ������� ��������(������� ��������� ������� � ��������,
            //����� ����� ����� � ��������� ���� ��� �� ���� ���������). �������� � ������ �������� �������� �� ��������� ������ �
            //���������� ������� ������� � ���������, � ��� �� ���������� � � ������� ���������� �������� � ������ �������� ������.
            //���� �� ���� �� �������� �� ������������� ��������� ��������, �� �������� � �������������� ���� ����� �Students not found�. 

            Task("LinqObj55");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .Select(x => new
                {
                    student = x[3] + ' ' + x[4],
                    math = int.Parse(x[0]),
                    rus = int.Parse(x[1]),
                    inf = int.Parse(x[2]),
                    school = x[5]
                })
                .Where(y => y.math >= 50 && y.rus >= 50 && y.inf >= 50)
                .OrderBy(x => x.student)
                .Select(x => $"{x.student} {x.school} {x.math + x.rus + x.inf}")
                .DefaultIfEmpty("Students not found");
            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
