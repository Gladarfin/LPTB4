// File: "LinqObj38"
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
            //LinqObj38�. �������� ������������������ �������� �������� �� ��������������� ��������(���).
            //������ ������� ������������������ �������� ��������� ����:

            //    < ���� 1 �����(� ��������) > 
            //    < ����� ������� > 
            //    < �������� > 
            //    < ����� >

            //�������� �������� � ���� �� �������� ��������. � �������� ����� ������� ����������� ����� 92, 95 ��� 98.
            //������ �������� ����� �� ����� ����� ��� �� ������ �����; ���� �� ������ ��� ����� � ��� �� �������� ����� �����������.
            //��� ������ ����� �������, �������������� � �������� ������, ���������� ���������� �������, ������������ ��� �����
            //(������� �������� ���������� �������, ����� ����� �����).�������� � ������ ����� �������� �� ����� ������ � ������������� 
            //�� ����������� ���������� �������, � ��� ����������� ���������� � �� ����������� �������� �����. 

            Task("LinqObj38");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => new { brand = int.Parse(x.Split(' ')[1]), comp = x.Split(' ')[2] })
                .GroupBy(x => x.brand)
                .Select(x => new { brand = x.Key, count = x.Count() })
                .OrderBy(x => x.count)
                .ThenBy(y => y.brand)
                .Select(x => $"{x.count} {x.brand}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
