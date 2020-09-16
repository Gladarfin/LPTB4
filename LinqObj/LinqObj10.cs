using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        // ��� ������ ������ ����� �� ��������� ���������� �����
        // � ������ a ���� string[] ����������� ��������:
        //
        //   a = File.ReadAllLines(GetString(), Encoding.Default);
        //
        // ��� ������ ������������������ s ���� IEnumerable<string>
        // � �������������� ��������� ���� ����������� ��������:
        //
        //   File.WriteAllLines(GetString(), s.ToArray(), Encoding.Default);
        //
        // ��� ������� ����� ������ LinqObj �������� ���������
        // �������������� ������ ����������, ������������ � ���������:
        //
        //   Show() � Show(cmt) - ���������� ������ ������������������,
        //     cmt - ��������� �����������;
        //
        //   Show(e => r) � Show(cmt, e => r) - ���������� ������
        //     �������� r, ���������� �� ��������� e ������������������,
        //     cmt - ��������� �����������.

        public static void Solve()
        {
            //LinqObj10�. �������� ������������������ �������� �������� � �������� ������ - ������.
            //������ ������� ������������������ �������� ��������� ������������� ����:
            //< ��� > < ����� ������ > < ��� ������� > < ����������������� �������(� �����) >
            // ��� ������ ���� ����������, �������������� � �������� ������, ���������� ���������� ��������, 
            //������� �������� ����� � ��������� �����(������� ��������� ���, ����� �����, ����� ���������� ��������).
            //�������� � ������ ���� ���������� �������� �� ����� ������ � ������������� �� �������� ������ ����, 
            //� ��� ����������� ������ ���� � �� ����������� ������ ������.

            Task("LinqObj10");
            var d = File.ReadAllLines(GetString(), Encoding.Default)
                    .GroupBy(x => new { year = x.Split(' ')[0], month = x.Split(' ')[1]},
                             y => y,
                             (x,y) => x.year + ' '+x.month + ' ' + y.Count().ToString()) 
                    .OrderByDescending(x => int.Parse(x.Split(' ')[0]))
                    .ThenBy(x => int.Parse(x.Split(' ')[1]));
            File.WriteAllLines(GetString(), d, Encoding.Default);
        }
    }
}
