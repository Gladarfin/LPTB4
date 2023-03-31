// File: "LinqObj47"
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
            //LinqObj47°. Исходная последовательность содержит сведения об автозаправочных станциях(АЗС).
            //Каждый элемент последовательности включает следующие поля:

                //< Цена 1 литра(в копейках) >
                //< Компания >
                //< Улица >
                //< Марка бензина >

            //Названия компаний и улиц не содержат пробелов. В качестве марки бензина указываются числа 92, 95 или 98.
            //Каждая компания имеет не более одной АЗС на каждой улице; цены на разных АЗС одной и той же компании могут различаться.
            //Вывести данные обо всех АЗС, предлагавших не менее двух марок бензина(вначале выводится название компании, затем название
            //улицы, затем количество предлагавшихся марок бензина). Сведения о каждой АЗС выводить на новой строке и упорядочивать
            //по названиям компаний в алфавитном порядке, а для одинаковых компаний — по названиям улиц(также в алфавитном порядке).
            //Если ни одной требуемой АЗС не найдено, то записать в результирующий файл строку «No». 

            Task("LinqObj47");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => new { company = x[1], street = x[2] },
                        (x, y) => new { key = x, count = y.Count() })
                .Where(x => x.count >= 2)
                .OrderBy(x => x.key.company)
                .ThenBy(x => x.key.street)
                .Select(x => $"{x.key.company} {x.key.street} {x.count}")
                .DefaultIfEmpty("No");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
