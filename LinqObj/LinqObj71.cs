// File: "LinqObj71"
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
            //LinqObj71. ���� ������������������ A � C, ���������� ��������� ����:

            // A:    < ��� ����������� > < ��� �������� > < ����� ���������� >
            // C:    < ��� ����������� > < ������(� ���������) > < �������� �������� >

            //�������� ������������������� ������� � ��������� � ������ ��������� �������. ��� ������� �������� ���������� ������������,
            //������� ������������ ������ � ���� ��������(������� ��������� �������� ��������, ����� ��� �����������, ��� ��� ��������
            //� �������� ������������ ������). ���� ��� ���������� �������� ������� ��������� ������������ � ������������ �������,
            //�� ������� ������ � ����������� � ����������� �����.�������� � ������ �������� �������� �� ����� ������ � �������������
            //�� ��������� ��������� � ���������� �������. 

            Task("LinqObj71");
            var a = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x =>
                {
                    var arr = x.Split(' ');
                    return new
                    {
                        code = int.Parse(arr[0]),
                        yearOfBirth = arr[1],
                        street = arr[2]
                    };
                });
            var c = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x =>
                {
                    var arr = x.Split(' ');
                    return new
                    {
                        code = int.Parse(arr[0]),
                        discount = int.Parse(arr[1]),
                        shopName = arr[2]
                    };
                });

            var r = c.Join(a,
                               shop => shop.code,
                               person => person.code,
                               (shop, person) => new { shop, person })
                               .OrderByDescending(x => x.shop.discount)
                               .ThenBy(x => x.shop.code)
                               .GroupBy(x => x.shop.shopName)
                               .Select(g => g.First())
                               .OrderBy(x => x.shop.shopName)
                               .Select(x => $"{x.shop.shopName} {x.person.code} {x.person.yearOfBirth} {x.shop.discount}");
            
            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
