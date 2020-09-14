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
            //LinqObj4�. �������� ������������������ �������� �������� � �������� ������ - ������.������ ������� ������������������ �������� ��������� ������������� ����:
            //< ��� > < ����� ������ > < ����������������� �������(� �����) > < ��� ������� >
            //��� ������� �������, ��������������� � �������� ������, ���������� ��������� ����������������� ������� � ������� ���� ���(������� �������� ��������� �����������������, ����� ��� �������). �������� � ������ ������� �������� �� ����� ������ � ������������� �� �������� ��������� �����������������, � ��� �� ��������� � �� ����������� ���� �������.
            Task("LinqObj4");
            var c = File.ReadAllLines(GetString(), Encoding.Default)
                    .Select(s => new[] { int.Parse(s.Split(' ')[2]),
                                         int.Parse(s.Split(' ')[3])})
                                                                     .GroupBy(code => code[1])
                                                                     .Select(x => new { duration = x.Sum(y => y[0]), code = x.Key })
                                                                     .OrderByDescending(x => x.duration)
                                                                     .ThenBy(x => x.code)
                                                                     .Select(e => e.duration.ToString() + ' ' + e.code.ToString());            
            File.WriteAllLines(GetString(), c, Encoding.Default);
        }
    }
}
