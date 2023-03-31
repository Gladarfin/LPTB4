// File: "LinqObj21"
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
            Task("LinqObj21");
            //LinqObj21�. �������� ������������������ �������� �������� �� ������������. ������ ������� ������������������ 
            //�������� ��������� ����:

            //    < ������� >
            //    < ��� ����������� > 
            //    < ����� ����� >

            //����������, ��� ����� ���� ����� ����� ������������ �� ��� ���� ���� ����������, � ������� ��� ������ �� ���� ���� 
            //������ � ������ ����������� � ���������� �������(������� ��������� ������� �����������, ����� ����� �����). 
            //�������� � ������ ����������� �������� �� ����� ������ � ������������� � ���������� �������, � ��� ���������� 
            //������� � �� ����������� ������� ����. 


            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .OrderBy(x => x.Split(' ')[0])
                .ThenBy(x => int.Parse(x.Split(' ')[2]))
                .GroupBy(x => x.Split(' ')[2]).Show()
                .Select(y => new { school = y.Key, count = y.Count(), firstStudent = y.Select(x => x.Split(' ')[0]).First()});
            var max = r.Max(x => x.count);
            var result = r.Where(x => x.count == max).Select(x => x.firstStudent + ' ' + x.school);

            File.WriteAllLines(GetString(), result, Encoding.Default);
        }
    }
}
