// File: "LinqObj45"
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

            //LinqObj45�. �������� ������������������ �������� �������� �� ��������������� �������� (���).
            //������ ������� ������������������ �������� ��������� ����:

                //< �������� >
                //< ���� 1 �����(� ��������) >
                //< ����� ������� >
                //< ����� >
            
            //�������� �������� � ���� �� �������� ��������. � �������� ����� ������� ����������� ����� 92, 95 ��� 98.
            //������ �������� ����� �� ����� ����� ��� �� ������ �����; ���� �� ������ ��� ����� � ��� �� �������� ����� �����������.
            //��� ������ ����� ���������� ���������� ���(������� �������� �������� �����, ����� ���������� ���). �������� � ������
            //����� �������� �� ����� ������ � ������������� �� ��������� ���� � ���������� �������. 

            Task("LinqObj45");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => x[3],
                        //������� ������������, ������� Distinct ������� ������������� �������� ��������
                        (x, y) => new { street = x, count = y.Select(yy => yy[0]).Distinct().Count() }) 
                .OrderBy(x => x.street)
                .Select(x => $"{x.street} {x.count}");

            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
