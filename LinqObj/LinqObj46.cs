// File: "LinqObj46"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            //LinqObj46°. Исходная последовательность содержит сведения об автозаправочных станциях(АЗС).
            //Каждый элемент последовательности включает следующие поля:

            //< Улица >
            //< Марка бензина >
            //< Цена 1 литра(в копейках) >
            //< Компания >

            //Названия компаний и улиц не содержат пробелов. В качестве марки бензина указываются числа 92, 95 или 98.
            //Каждая компания имеет не более одной АЗС на каждой улице; цены на разных АЗС одной и той же компании могут различаться.
            //Для каждой компании определить количество АЗС, предлагавших все три марки бензина(вначале выводить количество АЗС,
            //затем — название компании; количество может быть равно 0). Сведения о каждой компании выводить на новой строке и
            //упорядочивать по убыванию количества АЗС, а при равных количествах — по названиям компаний в алфавитном порядке. 
            Task("LinqObj46");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => new { company = x[3], street = x[0] },
                        (k, g) => new { k, g })
                .GroupBy(x => x.k.company,
                        (x, y) => new { company = x, count = y.Count(s =>
                                                                        s.g.Select(g92 => g92[1]).Contains("92") &&
                                                                        s.g.Select(g95 => g95[1]).Contains("95") &&
                                                                        s.g.Select(g98 => g98[1]).Contains("98"))
                        }
                )
                .OrderByDescending(x => x.count)
                .ThenBy(x => x.company)
                .Select(x => $"{x.count} {x.company}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
