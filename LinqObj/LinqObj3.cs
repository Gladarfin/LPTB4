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
			//LinqObj3�. �������� ������������������ �������� �������� � �������� ������ - ������.
            //������ ������� ������������������ �������� ��������� ������������� ����:
            //< ��� > < ����� ������ > < ����������������� �������(� �����) > < ��� ������� >
            //���������� ���, � ������� ��������� ����������������� ������� ���� �������� ���� ����������, � ������� ���� ��� � ���������� ��������� �����������������. 
            //���� ����� ����� ���� ���������, �� ������� ���������� �� ���.
            Task("LinqObj3");
            var d = File.ReadAllLines(GetString(), Encoding.Default)
                    .Select(s => new[] {
                                  int.Parse(s.Split(' ')[0]),
                                  int.Parse(s.Split(' ')[2])})
                                                              .GroupBy(x => x[0])
                                                              .Select(x => new { year = x.Key, item = x.Sum(y => y[1]) })
                                                              .OrderByDescending(y => y.item)
                                                              .ThenBy(y => y.year)
                                                              .Select(e => new[] { e.year.ToString() + ' ' + e.item.ToString() })
                                                              .First();
            File.WriteAllLines(GetString(), d, Encoding.Default);
        }
    }
}
