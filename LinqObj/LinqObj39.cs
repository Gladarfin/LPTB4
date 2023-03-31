// File: "LinqObj39"
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
            //LinqObj39�. ���� ����� ����� M � �������� ����� �� ����� �������. �������� ������������������ 
            //�������� �������� �� ��������������� ��������(���).������ ������� ������������������ �������� ��������� ����:

            //    < ����� > 
            //    < �������� > 
            //    < ����� ������� > 
            //    < ���� 1 �����(� ��������) >

            //�������� �������� � ���� �� �������� ��������. � �������� ����� ������� ����������� ����� 92, 95 ��� 98.
            //������ �������� ����� �� ����� ����� ��� �� ������ �����; ���� �� ������ ��� ����� � ��� �� �������� ����� �����������.
            //��� ������ ����� ���������� ���������� ���, ������������ ����� ������� M(������� �������� ���������� ��� �� ������ �����,
            //����� �������� �����; ���������� ��� ����� ���� ����� 0). �������� � ������ ����� �������� �� ����� ������ � ������������� 
            //�� ����������� ���������� ���, � ��� ����������� ���������� � �� ��������� ���� � ���������� �������. 

            Task("LinqObj39");
            var m = GetInt();
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => x[0])
                .Select(x => new { street = x.Key, count = x.Where(y => int.Parse(y[2]) == m).Count() })
                .OrderBy(x => x.count)
                .ThenBy(x => x.street)
                .Select(x => $"{x.count} {x.street}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
