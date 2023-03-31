// File: "LinqObj40"
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

            //LinqObj40�. �������� ������������������ �������� �������� �� ��������������� �������� (���). ������ �������
            //������������������ �������� ��������� ����:

                // < �������� >
                // < ����� >
                // < ����� ������� >
                // < ���� 1 �����(� ��������) >

            //�������� �������� � ���� �� �������� ��������. � �������� ����� ������� ����������� ����� 92, 95 ��� 98.
            //������ �������� ����� �� ����� ����� ��� �� ������ �����; ���� �� ������ ��� ����� � ��� �� �������� ����� �����������.
            //��� ������ ����� ���������� ���������� ���, ������������ ������������ ����� �������(������� �������� �������� �����,
            //����� ��� ����� � ���������� ��� ��� ������� ����� 92, 95 � 98; ��������� �� ���� ����� ����� ���� ����� 0).
            //�������� � ������ ����� �������� �� ����� ������ � ������������� �� ��������� ���� � ���������� �������. 
            Task("LinqObj40");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => x[1],
                        (x, y) => new { 
                                        street = x, 
                                        brand92 = y.Count(yy => yy[2] == "92"), 
                                        brand95 = y.Count(yy => yy[2] == "95"), 
                                        brand98 = y.Count(yy => yy[2] == "98") })
                .OrderBy(x => x.street)
                .Select(x => $"{x.street} {x.brand92} {x.brand95} {x.brand98}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
