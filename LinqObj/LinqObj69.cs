// File: "LinqObj69"
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
            //LinqObj69�. �������� ������������������ �������� �������� �� ������� �������� �� ���� ���������:
            //�������, ��������� � ������. ������ ������� ������������������ �������� ������ �� ����� ������ � �������� ��������� ����:

                //< ����� >
                //< ������� >
                //< �������� >
                //< �������� �������� >
                //< ������ >

            //������ �������������(� ����������� �������� � ����������) ����� �������� ���.����� �������� ����� ������, ������ �
            //����� ����� � ��������� 2�5.�������� �������� ����������� � ��������� �����.��� ������� ������ �����
            //�������� ���������� � ��������, ���������� � ������ ������ ������������ ��������� ����� ����� �� ���� ���������(�����
            //�� ������ ���� �������). ������� �������� � ������ �� �������� ����������: �������, ��������, ����� ������ � ����������
            //����� �����. �������� � ������ ��������� �������� �� ��������� ������ � ����������� � ���������� ������� �� �������
            //� ��������� (���������� �� ������� �� ���������). ���� � ������ �������� ������ ��� �� ����� ������,
            //�� �������� � �������������� ���� ����� �Students not found�. 

            Task("LinqObj69");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => x[0])
                .Select(g => new
                {
                    cls = g.Key,
                    maxCnt = g.GroupBy(g2 => g2[1] + ' ' + g2[2],
                                        (g2, y) => new { cnt = y.Where(gg => int.Parse(gg[4]) == 2).Count() })
                               .Max(x => x.cnt),
                    pupils = g.GroupBy(g3 => g3[1] + ' ' + g3[2],
                                        (g3, y) => new
                                        {
                                            fullname = g3,
                                            cls = g.Key,
                                            cnt = y.Where(gg => int.Parse(gg[4]) == 2).Count()
                                        })
                })
                .Where(x => x.maxCnt > 0)
                .SelectMany(e => e.pupils.Where(ee => ee.cnt == e.maxCnt))
                .OrderBy(x => x.fullname)
                .Select(x => $"{x.fullname} {x.cls} {x.cnt}")
                .DefaultIfEmpty("Students not found");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
