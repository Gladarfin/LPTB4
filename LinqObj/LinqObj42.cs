// File: "LinqObj42"
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

            //LinqObj42°. Исходная последовательность содержит сведения об автозаправочных станциях(АЗС).
            //Каждый элемент последовательности включает следующие поля:

                 //< Марка бензина >
                 //< Компания >
                 //< Улица >
                 //< Цена 1 литра(в копейках) >

            //Названия компаний и улиц не содержат пробелов. В качестве марки бензина указываются числа 92, 95 или 98.
            //Каждая компания имеет не более одной АЗС на каждой улице; цены на разных АЗС одной и той же компании могут различаться.
            //Для каждой улицы определить минимальную цену бензина каждой марки(вначале выводить название улицы, затем три числа —
            //минимальную цену для бензина марки 92, 95 и 98).При отсутствии бензина нужной марки выводить число 0.
            //Сведения о каждой улице выводить на новой строке и упорядочивать по названиям улиц в алфавитном порядке.

            Task("LinqObj42");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => x[2],
                        (x, y) => new {
                            street = x,
                            brand92 = y.Where(yy => yy[0] == "92").Select(yy => int.Parse(yy[3])).DefaultIfEmpty(0).Min(),
                            brand95 = y.Where(yy => yy[0] == "95").Select(yy => int.Parse(yy[3])).DefaultIfEmpty(0).Min(),
                            brand98 = y.Where(yy => yy[0] == "98").Select(yy => int.Parse(yy[3])).DefaultIfEmpty(0).Min()
                        })
                .OrderBy(x => x.street)
                .Select(x => $"{x.street} {x.brand92} {x.brand95} {x.brand98}");

            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
