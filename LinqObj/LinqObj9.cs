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
            //LinqObj9�. ���� ����� ����� K � ��� ������ �� �������� ������ - ������.
            //�������� ������������������ �������� �������� � �������� ����� ������ - ������.
            //������ ������� ������������������ �������� ��������� ������������� ����:
            //< ��� ������� > < ����������������� �������(� �����) > < ����� ������ > < ��� >
            //��� ������� ����, � ������� ������ � ����� K ������� �����, ���������� ����� �������, 
            //��� ������� ����������������� ������� ������� ������� ������������ 15 �����(������� �������� ����� �������, ����� ���).
            //���� ��� ���������� ���� ��������� ������ �����������, �� ������� ��� ���� 0.
            //�������� � ������ ���� �������� �� ����� ������; ������ ������������� �� �������� ����� �������, 
            //� ��� ������ ����� ������� � �� ����������� ������ ����. ���� ������ �� ��������� ������� �����������, 
            //�� �������� � �������������� ���� ������ ���� �������.
            Task("LinqObj9");
            int k = GetInt();
            var d = File.ReadAllLines(GetString(), Encoding.Default)
                        .Where(code => int.Parse(code.Split(' ')[0]) == k)
                        .Select(data => new[] { data.Split(' ')[1],
                                                data.Split(' ')[2],
                                                data.Split(' ')[3]})
                        .GroupBy(x => x[2],
                                 y => y,
                                 (x, y) => y.Where(j => int.Parse(j[0]) > 15).Count().ToString() + ' ' + x.ToString())
                        .OrderByDescending(x => x.Split(' ')[0])
                        .ThenBy(x => x.Split(' ')[1])
                        .DefaultIfEmpty("��� ������");
			File.WriteAllLines(GetString(), d, Encoding.Default);
        }
    }
}
