// File: "LinqObj13"
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
            //LinqObj13�. �������� ������������������ �������� �������� �� ������������. ������ ������� ������������������ 
            //�������� ��������� ����:

            //    < ����� ����� > 
            //    < ��� ����������� > 
            //    < ������� >

            //��� ������� ����, ��������������� � �������� ������, ����� ����� � ���������� ������� ����� ����,
            //������� �������� �����������, ����������� � ���� ����, � ������� ��� � ��������� ����� �����. 
            //�������� � ������ ���� �������� �� ����� ������ � ������������� �� ����������� ������ ����. 

            Task("LinqObj13");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .GroupBy(x => x.Split(' ')[1],
                         (x, y) => new {year = x, schoolNumber = y.Max(n => int.Parse(n.Split(' ')[0]))})
                .OrderBy(x => x.year)
                .Select(x => x.year + ' ' + x.schoolNumber.ToString());

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
