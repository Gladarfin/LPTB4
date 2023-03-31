// File: "LinqObj12"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        // To read strings from the source text file into
        // a string sequence (or array) s, use the statement:
        //   s = File.ReadLines(GetString());
        // To write the sequence s of IEnumerable<string> type
        // into the resulting text file, use the statement:
        //   File.WriteAllLines(GetString(), s);
        // When solving tasks of the LinqObj group, the following
        // additional methods defined in the taskbook are available:
        // (*) Show() and Show(cmt) (extension methods) - debug output
        //       of a sequence, cmt - string comment;
        // (*) Show(e => r) and Show(cmt, e => r) (extension methods) -
        //       debug output of r values, obtained from elements e
        //       of a sequence, cmt - string comment.

        public static void Solve()
        {

           // LinqObj12�. ���� ����� ����� P(10 < P < 50). �������� ������������������ �������� �������� � �������� ������ - ������.
           // ������ ������� ������������������ �������� ��������� ������������� ����:
           //     < ����������������� �������(� �����) >
           //     < ��� ������� >
           //     < ����� ������ >
           //     < ��� >
           //��� ������� ����, ��������������� � �������� ������, ���������� ���������� �������, � �������
           //��������� ������������ ������� ���� �������� ���������� ����� P ��������� �� ��������� ������������
           //�� ���� ���(������� �������� ���������� �������, ����� ���).���� � ��������� ���� �� ��� ������ ������
           //�� ����������� ��������� �������, �� ������� ��� ���� 0.�������� � ������ ���� �������� �� ����� ������
           //� ������������� �� �������� ���������� �������, � ��� ����������� ���������� � �� ����������� ������ ����. 
            Task("LinqObj12");
            var p = GetInt();
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .GroupBy(x => x.Split(' ')[3],
                        (x, y) => new {
                            year = x,
                            count = y.GroupBy(m => m.Split(' ')[2],
                            (m, c) => c.Sum(d => double.Parse(d.Split(' ')[0])) > 
                                      p / 100.0 * y.Sum(d => double.Parse(d.Split(' ')[0])))
                            .Where(t => t)
                            .Count()
                        })
                .OrderByDescending(y => y.count)
                .ThenBy(y => y.year)
                .Select(x => x.count.ToString() + ' ' + x.year);

            File.WriteAllLines(GetString(), r, Encoding.Default);


        }
    }
}
