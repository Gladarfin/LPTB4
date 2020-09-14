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
            //LinqObj1�. �������� ������������������ �������� �������� � �������� ������ - ������.
			//������ ������� ������������������ �������� ��������� ������������� ����:
            //< ��� ������� > < ��� > < ����� ������ > < ����������������� �������(� �����) >
            //����� ������� ������������������ � ����������� ������������������ �������. 
			//������� ��� �����������������, � ����� ��������������� �� ��� � ����� ������(� ��������� ������� �� ��� �� ������). 
			//���� ������� ��������� ��������� � ����������� ������������������, �� ������� ������ ���� �� ���, ������� �������� ��������� � �������� ������������������.

            Task("LinqObj1");
            var a = new[] { File.ReadAllLines(GetString(), Encoding.Default)
                                                                            .OrderByDescending(e => int.Parse(e.Split(' ')[3])).Last() }
                           .Select(e => e.Split(' ')[3] + ' ' + e.Split(' ')[1] + ' ' + e.Split(' ')[2]);
            File.WriteAllLines(GetString(), a, Encoding.Default);
			

        }
    }
}
