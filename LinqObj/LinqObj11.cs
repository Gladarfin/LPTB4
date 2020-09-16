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
            //LinqObj11�. �������� ������������������ �������� �������� � �������� ������ - ������.
            //������ ������� ������������������ �������� ��������� ������������� ����:
            //< ��� ������� > < ��� > < ����� ������ > < ����������������� �������(� �����) >
            //��� ������ ���� ����������, �������������� � �������� ������, ���������� ����� ����������������� ������� ���� �������� 
            //� ��������� �����(������� ��������� ����� �����������������, ����� ���, ����� �����). 
            //�������� � ������ ���� ���������� �������� �� ����� ������ � ������������� �� ����������� ����� ����������������� �������, 
            //��� ���������� ����������������� � �� �������� ������ ����, � ��� ����������� ������ ���� � �� ����������� ������ ������.
            Task("LinqObj11");
            var d = File.ReadAllLines(GetString(), Encoding.Default)
                        .GroupBy(x => new { year = x.Split(' ')[1], month = x.Split(' ')[2] },
                                 y => y.Split(' ')[3],
                                 (x,y) => y.Select(j => int.Parse(j)).Sum().ToString() + ' '+ x.year+ ' ' +x.month )
                        .OrderBy(x => int.Parse(x.Split(' ')[0]))
                        .ThenByDescending(x => int.Parse(x.Split(' ')[1]))
                        .ThenBy(x => int.Parse(x.Split(' ')[2]));
            File.WriteAllLines(GetString(), d, Encoding.Default);
        }
    }
}
