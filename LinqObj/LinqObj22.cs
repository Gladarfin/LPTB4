// File: "LinqObj22"
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
            Task("LinqObj22");
            //�������� ������������������ �������� �������� �� ������������. ������ ������� ������������������ �������� ��������� ����:

            //    < ������� > 
            //    < ����� ����� > 
            //    < ��� ����������� >

            //��� ������ ����� ����� ���� ����������� ������������ �� ���� ����� � ������� ����� ����� � ��������� ��� ��� ����
            //(���� ������������� �� ��� �� ������, ��� � ����� �����, � ��������������� �� �����������). �������� � ������ ����� 
            //�������� �� ����� ������ � ������������� �� ����������� ������� ����. 

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .OrderBy(x => int.Parse(x.Split(' ')[2]))
                .GroupBy(x => x.Split(' ')[1])
                .OrderBy(x => int.Parse(x.Key))
                .Select(x => x.Key + ' ' + string.Join(" ", x.Select(y => y.Split(' ')[2]).Distinct()));

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
