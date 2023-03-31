// File: "LinqObj16"
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
            Task("LinqObj16");
            //LinqObj16�. �������� ������������������ �������� �������� �� ������������. 
            //������ ������� ������������������ �������� ��������� ����:

            //    < ��� ����������� > 
            //    < ����� ����� > 
            //    < ������� >

            //��� ������� ����, ��������������� � �������� ������, ������� ����� ����� ������������, 
            //����������� � ���� ����(������� ��������� ����� ������������, ����� ���).�������� � ������ ���� 
            //�������� �� ����� ������ � ������������� �� �������� ����� �����������, � ��� ����������� ����� � 
            //�� ����������� ������ ����. 
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .GroupBy(x => x.Split(' ')[0],
                        (x, y) => y.Count().ToString() + ' ' + x)
                .OrderByDescending(x => int.Parse(x.Split(' ')[0]))
                .ThenBy(y => int.Parse(y.Split(' ')[1]));

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
