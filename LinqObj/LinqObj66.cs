// File: "LinqObj66"
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
            //LinqObj66�. ���� ������ S � �������� ������ �� ���� ���������: �������, ��������� ��� ������. �������� ������������������
            //�������� �������� �� ������� �������� �� ���� ���� ���������. ������ ������� ������������������ �������� ������
            //�� ����� ������ � �������� ��������� ����:

            //  < �������� �������� >
            //  < ������� >
            //  < �������� >
            //  < ������ >
            //  < ����� >

            //������ �������������(� ����������� �������� � ����������) ����� �������� ���.����� �������� ����� ������,
            //������ � ����� ����� � ��������� 2�5.�������� �������� ����������� � ��������� �����.��� ������� ������,
            //��������������� � ������ �������� ������, ���������� ����� ��������, ������� �� �������� S ������� ������
            //�� ����� 3.5 � ��� ���� �� ���������� �� ����� ������ �� ����� ��������.�������� � ������ ������ ��������
            //�� ��������� ������, �������� ����� ������ � ����� ��������� ��������(����� ����� ���� ����� 0).
            //������ ������������� �� ����������� ������ ������. 

            Task("LinqObj66");
            var s = GetString();
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[4]))
                .Select(x => new
                {
                    cl = x.Key,
                    subj = x.GroupBy(st => st[1] + ' ' + st[2])
                            .Select(y => new
                            {
                                avg = y.Where(su => su[0] == s).Select(sm => int.Parse(sm[3])).DefaultIfEmpty().Average(),
                                ds = y.Where(su => su[0] == s && int.Parse(su[3]) == 2).Select(sm => int.Parse(sm[3])).Count()
                            })
                            .Where(k => k.avg >= 3.5 && k.ds == 0)
                            .Count()
                })
                .OrderBy(x => x.cl)
                .Select(x => $"{x.cl} {x.subj}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
