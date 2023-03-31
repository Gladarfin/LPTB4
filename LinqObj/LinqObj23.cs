// File: "LinqObj23"
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
            Task("LinqObj23");
            //LinqObj23�. �������� ������������������ �������� �������� �� ������������. 
            //������ ������� ������������������ �������� ��������� ����:

            //    < ������� > 
            //    < ��� ����������� > 
            //    < ����� ����� >

            //��� ������ ���� ���������, �������������� � �������� ������, ����� ����� ������������, 
            //����������� � ����� ���� � �����, � ������� ���, ����� ����� � ��������� ����� ������������. 
            //�������� � ������ ���� ��������� �������� �� ����� ������ � ������������� �� �������� ����,
            //� ��� ����������� ����� � �� ����������� ������ �����. 

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .GroupBy(x => new { year = x.Split(' ')[1], school = x.Split(' ')[2]})
                .OrderByDescending(x => int.Parse(x.Key.year))
                .ThenBy(x => int.Parse(x.Key.school))
                .Select(x => x.Key.year + ' ' + x.Key.school + ' '+ x.Count());

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
