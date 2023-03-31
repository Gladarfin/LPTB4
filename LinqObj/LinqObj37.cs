// File: "LinqObj37"
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
            //LinqObj37�. �������� ������������������ �������� �������� �� ��������������� ��������(���).
            //������ ������� ������������������ �������� ��������� ����:

            //    < �������� > 
            //    < ����� ������� > 
            //    < ���� 1 �����(� ��������) >
            //    < ����� >

            //�������� �������� � ���� �� �������� ��������. � �������� ����� ������� ����������� ����� 92, 95 ��� 98.
            //������ �������� ����� �� ����� ����� ��� �� ������ �����; ���� �� ������ ��� ����� � ��� �� �������� ����� �����������.
            //��� ������ ����� �������, �������������� � �������� ������, ���������� ����������� � ������������ ���� 
            //����� ������� ���� �����(������� �������� �����, ����� ���� � ��������� �������).�������� � ������ ����� 
            //�������� �� ����� ������ � ������������� �� �������� �������� �����.

            Task("LinqObj37");

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[1]))
                .OrderByDescending(x => x.Key)
                .Select(x => $"{x.Key} {x.Min(y => int.Parse(y[2]))} {x.Max(y => int.Parse(y[2]))}");


            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
