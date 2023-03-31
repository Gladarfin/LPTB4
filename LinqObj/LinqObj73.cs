// File: "LinqObj73"
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
            //LinqObj73�. ���� ������������������ A � C, ���������� ��������� ����:

                    // A:    < ��� �������� > < ��� ����������� > < ����� ���������� >
                    // C:    < ��� ����������� > < �������� �������� > < ������(� ���������) >

            //�������� ������������������� ������� � ��������� � ������ ��������� �������. ��� ������� �������� � ������ �����
            //���������� ���������� ������������, ������� �� ���� ����� � ������� ������ � ���� ��������(������� ���������
            //�������� ��������, ����� �������� �����, ����� ���������� ������������ �� �������). ���� ��� ��������� ����
            //������������� ����������� �� ������� �� �������, �� ������ �� ���� ���� �� ���������.�������� � ������ ����
            //������������� �������� �� ����� ������ � ������������� �� ��������� ��������� � ���������� �������, � ��� ����������
            //�������� ��������� � �� ��������� ����(����� � ���������� �������).

            Task("LinqObj73");
            
            var a = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x =>
                {
                    var arr = x.Split(' ');
                    return new
                    {
                        Code = int.Parse(arr[1]),
                        Street = arr[2]
                    };
                });
            var c = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x =>
                {
                    var arr = x.Split(' ');
                    return new
                    {
                        Code = int.Parse(arr[0]),
                        ShopName = arr[1]
                    };
                });
            var r = c.Join(a,
                           shop => shop.Code,
                           person => person.Code,
                           (shop, person) => new { shop, person })
                .OrderBy(x => x.shop.ShopName)
                .ThenBy(x => x.person.Street)
                .GroupBy(x => $"{x.shop.ShopName} {x.person.Street}")
                .Where(x => x.Count() > 0)
                .Select(x => new { ss = x.Key, count = x.Count() })
                .Select(x => $"{x.ss} {x.count}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
