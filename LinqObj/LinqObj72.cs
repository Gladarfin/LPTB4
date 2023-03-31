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
            //LinqObj72∞. ƒаны последовательности A и C, включающие следующие пол€:

               //A:    <  од потребител€ > < ”лица проживани€ > < √од рождени€ >
                //C:    < —кидка(в процентах) > <  од потребител€ > < Ќазвание магазина >

            //—войства последовательностей описаны в преамбуле к данной подгруппе заданий. ƒл€ каждого потребител€, указанного в A,
            //определить количество магазинов, в которых ему предоставл€етс€ скидка(вначале выводитс€ количество магазинов,
            //затем код потребител€, затем его улица проживани€).≈сли у некоторого потребител€ нет скидки ни в одном магазине,
            //то дл€ него выводитс€ количество магазинов, равное 0.—ведени€ о каждом потребителе выводить на новой строке и
            //упор€дочивать по возрастанию количества магазинов, а при равном количестве Ч по возрастанию кодов потребителей. 

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
