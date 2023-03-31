// File: "LinqObj24"
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
            Task("LinqObj24");
            //LinqObj24�. �������� ������������������ �������� �������� �� ������������. 
            //������ ������� ������������������ �������� ��������� ����:

            //    < ������� > 
            //    < ����� ����� > 
            //    < ��� ����������� >

            //��� ������ ���� ����������, �������������� � �������� ������, ����� ���� ������ ������������, 
            //����������� � ���� ����� � ����, � ������� ����� �����, ��� � ��������� �������(� ������� �� ����������
            //� �������� ������ ������). ���� ��� ��������� ���� ���������� ������� ����� ���� ������������, �� �������
            //���������� ��� ���� ������������, ����������� � ���� ����. �������� � ������ ���� ���������� �������� �� 
            //����� ������ � ������������� �� ����������� ������ �����, � ��� ����������� ������� � �� �������� ����.

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .GroupBy(x => new { school = x.Split(' ')[1], year = x.Split(' ')[2] })
                .OrderBy(x => int.Parse(x.Key.school))
                .ThenByDescending(x => int.Parse(x.Key.year))
                .Select(x => x.Key.school + ' ' + x.Key.year + ' ' + string.Join(" ", x.Select(y => y.Split(' ')[0]).Take(3)));

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
