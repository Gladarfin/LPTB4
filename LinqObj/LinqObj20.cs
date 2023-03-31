// File: "LinqObj20"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("LinqObj20");
            //LinqObj20�. �������� ������������������ �������� �������� �� ������������. 
            //������ ������� ������������������ �������� ��������� ����:

            //    < ������� > 
            //    < ����� ����� > 
            //    < ��� ����������� >

            //����������, ��� ����� ���� ����� ����� ������������ �� ��� ���� ���� ����������, � ������� ������ �� ������������ �� 
            //���� ����(������� ��������� ����� �����, ����� ������� �����������). �������� � ������ ����������� �������� �� ����� 
            //������ � ������������� �� ����������� ������� ����, � ��� ���������� ������� � � ������� ���������� ������������ � 
            //�������� ������ ������. 

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .GroupBy(x => x.Split(' ')[1])
                .Select(x => new {
                    school = x.Key, 
                    count = x.Count(), 
                    students = x.Select(y => y.Split(' ')[0]).ToArray()
                });
            var max = r.Max(x => x.count);
            var result = r.Where(x => x.count == max)
                .OrderBy(y => int.Parse(y.school))
                .SelectMany(x => x.students.Select(y => $"{x.school} {y}"))
                .ToArray();


            File.WriteAllLines(GetString(), result, Encoding.Default);
        }
    }
}
