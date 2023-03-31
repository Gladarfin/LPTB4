// File: "LinqObj42"
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

            //LinqObj42�. �������� ������������������ �������� �������� �� ��������������� ��������(���).
            //������ ������� ������������������ �������� ��������� ����:

                 //< ����� ������� >
                 //< �������� >
                 //< ����� >
                 //< ���� 1 �����(� ��������) >

            //�������� �������� � ���� �� �������� ��������. � �������� ����� ������� ����������� ����� 92, 95 ��� 98.
            //������ �������� ����� �� ����� ����� ��� �� ������ �����; ���� �� ������ ��� ����� � ��� �� �������� ����� �����������.
            //��� ������ ����� ���������� ����������� ���� ������� ������ �����(������� �������� �������� �����, ����� ��� ����� �
            //����������� ���� ��� ������� ����� 92, 95 � 98).��� ���������� ������� ������ ����� �������� ����� 0.
            //�������� � ������ ����� �������� �� ����� ������ � ������������� �� ��������� ���� � ���������� �������.

            Task("LinqObj42");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => x[2],
                        (x, y) => new {
                            street = x,
                            brand92 = y.Where(yy => yy[0] == "92").Select(yy => int.Parse(yy[3])).DefaultIfEmpty(0).Min(),
                            brand95 = y.Where(yy => yy[0] == "95").Select(yy => int.Parse(yy[3])).DefaultIfEmpty(0).Min(),
                            brand98 = y.Where(yy => yy[0] == "98").Select(yy => int.Parse(yy[3])).DefaultIfEmpty(0).Min()
                        })
                .OrderBy(x => x.street)
                .Select(x => $"{x.street} {x.brand92} {x.brand95} {x.brand98}");

            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
