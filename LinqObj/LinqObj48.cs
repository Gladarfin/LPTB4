// File: "LinqObj48"
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
            //LinqObj48°. Исходная последовательность содержит сведения об автозаправочных станциях (АЗС).
            //Каждый элемент последовательности включает следующие поля:

            //      < Цена 1 литра(в копейках) >
            //      < Улица >
            //      < Марка бензина >
            //      < Компания >

            //Названия компаний и улиц не содержат пробелов. В качестве марки бензина указываются числа 92, 95 или 98.
            //Каждая компания имеет не более одной АЗС на каждой улице; цены на разных АЗС одной и той же компании могут различаться.
            //Перебрать все возможные комбинации улиц и компаний, содержащихся в исходном наборе данных, и для каждой пары
            //«улица–компания» вывести название улицы, название компании и количество марок бензина, которое предлагает
            //АЗС данной компании, расположенная на данной улице(если АЗС отсутствует, то количество полагается равным 0).
            //Сведения о каждой паре выводить на новой строке и упорядочивать по названиям улиц в алфавитном порядке,
            //а для одинаковых названий улиц — по названиям компаний(также в алфавитном порядке).

            Task("LinqObj48");
            var f = File.ReadAllLines(GetString(), Encoding.Default);
            var r = f.SelectMany(x => f.Select(y => new { street = x.Split(' ')[1], company = y.Split(' ')[3] }))
                .Distinct()
                .GroupJoin(f.Select(x => new { company = x.Split(' ')[3], street = x.Split(' ')[1] }),
                x => new { x.company, x.street },
                y => new { y.company, y.street },
                (k, g) => new { k, count = g.Count() })
                .OrderBy(x => x.k.street)
                .ThenBy(x => x.k.company)
            .Select(x => $"{x.k.street} {x.k.company} {x.count}");

           File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
