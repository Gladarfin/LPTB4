// File: "LinqObj19"
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
            Task("LinqObj19");
            //LinqObj19�. �������� ������������������ �������� �������� �� ������������. ������ ������� ������������������ 
            //�������� ��������� ����:

            //    < ������� > 
            //    < ��� ����������� > 
            //    < ����� ����� >

            //��� ������ ����� ������� ����� ����� ������������ �� ��� ���� � ������� ������� �� ������������ ���� �����, 
            //������������ � �������� ������ ������(������� ��������� ����� �����, ����� ����� ������������, ����� �������). 
            //�������� � ������ ����� �������� �� ����� ������ � ������������� �� ����������� ������� ����. 

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .GroupBy(x => x.Split(' ')[2],
                         (x, y) => x + ' ' + y.Count() + ' ' + y.First().Split(' ')[0])
                .OrderBy(x => int.Parse(x.Split(' ')[0]));

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
