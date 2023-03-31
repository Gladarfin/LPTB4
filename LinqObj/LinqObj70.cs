// File: "LinqObj70"
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
            //LinqObj70�. �������� ������������������ �������� �������� �� ������� �������� �� ���� ���������: �������, ���������
            //� ������. ������ ������� ������������������ �������� ������ �� ����� ������ � �������� ��������� ����:

            //  < ������ >
            //  < ����� >
            //  < ������� >
            //  < �������� >
            //  < �������� �������� >

            //������ �������������(� ����������� �������� � ����������) ����� �������� ���.����� �������� ����� ������, ������ �
            //����� ����� � ��������� 2�5.�������� �������� ����������� � ��������� �����.��� ������� ������ ����� ������ �������� �
            //��������, ���������� � ������ ������ ������������ ��������� ����� ������� �� ���� ���������(����� �� ������ ���� �������).
            //��� ������ ������ ��������(� ���������, ��� ����������� ������������� ���������� ����� �������) �� ������� ���������
            //��������, ���������� ���� �� ���� ������ ��� ������. ������� �������� � ������ �� ������ ��������: ����� ������, �������,
            //�������� � ���������� ����� �������. �������� � ������ �������� �������� �� ��������� ������ � ����������� �� �����������
            //�������, � ��� ���������� ������� � � ���������� ������� ������� � ���������. ���� � ������ �������� ������ ��� �� ������
            //���������, ���������������� ��������� ��������, �� �������� � �������������� ���� ����� �Students not found�. 

            Task("LinqObj70");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[1]))
                .Select(g => new
                {
                    cls = g.Key,
                    maxCnt = g.GroupBy(g2 => g2[2] + ' ' + g2[3],
                                        (g2, y) => new { cnt = y.Where(gg => int.Parse(gg[0]) == 5).Count(),
                                                         cnt23 = y.Count(gg => int.Parse(gg[0]) == 2 || int.Parse(gg[0]) == 3)
                                        })
                               .Where(x => x.cnt23 == 0).Select(x => x.cnt).DefaultIfEmpty(0).Max(),
                    pupils = g.GroupBy(g3 => g3[2] + ' ' + g3[3],
                                        (g3, y) => new
                                        {
                                            fullname = g3,
                                            cls = g.Key,
                                            cnt5 = y.Where(gg => int.Parse(gg[0]) == 5).Count(),
                                            cnt23 = y.Count(gg => int.Parse(gg[0]) == 2 || int.Parse(gg[0]) == 3)
                                        })
                })
                .Where(x => x.maxCnt > 0)
                .SelectMany(e => e.pupils.Where(ee => ee.cnt5 == e.maxCnt && ee.cnt23 == 0))
                .OrderBy(x => x.cls)
                .ThenBy(x => x.fullname)
                .Select(x => $"{x.cls} {x.fullname} {x.cnt5}")
                .DefaultIfEmpty("Students not found");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
