// File: "LinqObj15"
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
            Task("LinqObj15");

            //LinqObj15�. �������� ������������������ �������� �������� �� ������������. ������ ������� ������������������ 
            //�������� ��������� ����:

            //    < ����� ����� > 
            //    < ��� ����������� > 
            //    < ������� >

            //����������, � ����� ���� ����� ����� ������������ ��� ���� ���� ���� ����������, � ������� ��� �����, 
            //� ����� ����, � ������� ��� ���� ����������(���� ������������� �� �����������, ������ ����� �������� 
            //�� ����� ������). 

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .GroupBy(x => int.Parse(x.Split(' ')[1]),
                        (x, y) => new { year = x, count = y.Count() })
                .GroupBy(y => y.count)
                .OrderByDescending(yc => yc.Key)
                .Select(x => new{x.Key, years = x.Select(xx => xx.year.ToString()).OrderBy(xy => xy)})
                .First();
            var result = r.years.Prepend(r.Key.ToString());
            File.WriteAllLines(GetString(), result, Encoding.Default);
        }
    }
}
