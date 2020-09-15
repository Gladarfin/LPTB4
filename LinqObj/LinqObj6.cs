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
            //LinqObj6�. �������� ������������������ �������� �������� � �������� ������ - ������.������ ������� ������������������ �������� ��������� ������������� ����:
            //< ��� ������� > < ����������������� �������(� �����) > < ��� > < ����� ������ >
            //��� ������� ������ ���������� ��������� ����������������� ������� ���� �������� �� ��� ����(������� �������� ��������� �����������������, ����� ����� ������).���� ������ � ��������� ������ �����������, �� ��� ����� ������ ������� 0.�������� � ������ ������ �������� �� ����� ������ � ������������� �� �������� ��������� �����������������, � ��� ������ ����������������� � �� ����������� ������ ������.
            Task("LinqObj6");
            var k = File.ReadAllLines(GetString(), Encoding.Default).Concat(Enumerable.Range(1, 12)
                                                                                      .Select(i => String.Format("{0} {1} {2} {3}", 0, 0, 0, i))) //add all 12 month with 0 values, another option is to use dictionaries...
                                                                    .Select(s => new[] { int.Parse(s.Split(' ')[1]),
                                                                                         int.Parse(s.Split(' ')[3])})
                                                                    .GroupBy(month => month[1])
                                                                    .Select(x => new { month = x.Key , duration = x.Select(y => y[0]).Sum() })
                                                                    .OrderByDescending(x => x.duration)
                                                                    .ThenBy(x => x.month)
                                                                    .Select(e => e.duration.ToString() + ' ' + e.month.ToString());
            File.WriteAllLines(GetString(), k, Encoding.Default);
        }
    }
}
