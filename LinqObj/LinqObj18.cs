// File: "LinqObj18"
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
            Task("LinqObj18");

            //LinqObj18�. �������� ������������������ �������� �������� �� ������������. ������ ������� ������������������ 
            //�������� ��������� ����:

            //    < ��� ����������� > 
            //    < ����� ����� > 
            //    < ������� >

            //����� ����, ��� ������� ����� ������������ ���� �� ������ �������� �������� �� ���� �����(������� ��������� ����� 
            //������������ ��� ������� ����, ����� ���). �������� � ������ ���� �������� �� ����� ������ � ������������� 
            //�� �������� ����� ������������, � ��� ����������� ����� � �� ����������� ������ ����. 

            var f = File
                .ReadAllLines(GetString(), Encoding.Default)
                .GroupBy(x => x.Split(' ')[0])
                .Select(x => new { year = x.Key, stud = x.Count() })
                .OrderByDescending(y => y.stud)
                .ThenBy(x => x.year);
            var avg = f.Average(x => x.stud);
            var r = f.Where(x => x.stud >= avg)
                .Select(x => x.stud.ToString() + ' ' + x.year);
               
            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
