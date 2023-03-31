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
            //LinqObj73°. Даны последовательности A и C, включающие следующие поля:

                    // A:    < Год рождения > < Код потребителя > < Улица проживания >
                    // C:    < Код потребителя > < Название магазина > < Скидка(в процентах) >

            //Свойства последовательностей описаны в преамбуле к данной подгруппе заданий. Для каждого магазина и каждой улицы
            //определить количество потребителей, живущих на этой улице и имеющих скидку в этом магазине(вначале выводится
            //название магазина, затем название улицы, затем количество потребителей со скидкой). Если для некоторой пары
            //«магазин–улица» потребители со скидкой не найдены, то данные об этой паре не выводятся.Сведения о каждой паре
            //«магазин–улица» выводить на новой строке и упорядочивать по названиям магазинов в алфавитном порядке, а для одинаковых
            //названий магазинов — по названиям улиц(также в алфавитном порядке).

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
