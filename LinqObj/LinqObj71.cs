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
            //LinqObj71. ƒаны последовательности A и C, включающие следующие пол€:

            // A:    <  од потребител€ > < √од рождени€ > < ”лица проживани€ >
            // C:    <  од потребител€ > < —кидка(в процентах) > < Ќазвание магазина >

            //—войства последовательностей описаны в преамбуле к данной подгруппе заданий. ƒл€ каждого магазина определить потребителей,
            //имеющих максимальную скидку в этом магазине(вначале выводитс€ название магазина, затем код потребител€, его год рождени€
            //и значение максимальной скидки). ≈сли дл€ некоторого магазина имеетс€ несколько потребителей с максимальной скидкой,
            //то вывести данные о потребителе с минимальным кодом.—ведени€ о каждом магазине выводить на новой строке и упор€дочивать
            //по названи€м магазинов в алфавитном пор€дке. 

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
