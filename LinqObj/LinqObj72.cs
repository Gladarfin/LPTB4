// File: "LinqObj72"
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
            //LinqObj72�. ���� ������������������ A � C, ���������� ��������� ����:

               //A:    < ��� ����������� > < ����� ���������� > < ��� �������� >
                //C:    < ������(� ���������) > < ��� ����������� > < �������� �������� >

            //�������� ������������������� ������� � ��������� � ������ ��������� �������. ��� ������� �����������, ���������� � A,
            //���������� ���������� ���������, � ������� ��� ��������������� ������(������� ��������� ���������� ���������,
            //����� ��� �����������, ����� ��� ����� ����������).���� � ���������� ����������� ��� ������ �� � ����� ��������,
            //�� ��� ���� ��������� ���������� ���������, ������ 0.�������� � ������ ����������� �������� �� ����� ������ �
            //������������� �� ����������� ���������� ���������, � ��� ������ ���������� � �� ����������� ����� ������������. 

            Task("LinqObj72");
            var a = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x =>
                {
                    var arr = x.Split(' ');
                    return new
                    {
                        Code = int.Parse(arr[0]),
                        Street = arr[1]                        
                    };
                });
            var c = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x =>
                {
                    var arr = x.Split(' ');
                    return new
                    {
                        Code = int.Parse(arr[1]), 
                        ShopName = arr[2]
                    };
                });
            var r = a.GroupJoin(c,
                           person => person.Code,
                           shop => shop.Code,
                           (person, shop) => new { person, Count = shop.Count(x => x.ShopName != null)})
                               .GroupBy(x => x.person.Code)
                               .Select(g => new { 
                                   Count = g.Select(x => x.Count).First(), 
                                   Code = g.Key, 
                                   Street = g.Select(p => p.person.Street).First()
                               })
                               .OrderBy(x => x.Count)
                               .ThenBy(x => x.Code)
                               .Select(x => $"{x.Count} {x.Code} {x.Street}");


            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
