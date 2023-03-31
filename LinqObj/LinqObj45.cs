// File: "LinqObj45"
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

            //LinqObj45°. Исходная последовательность содержит сведения об автозаправочных станциях (АЗС).
            //Каждый элемент последовательности включает следующие поля:

                //< Компания >
                //< Цена 1 литра(в копейках) >
                //< Марка бензина >
                //< Улица >
            
            //Названия компаний и улиц не содержат пробелов. В качестве марки бензина указываются числа 92, 95 или 98.
            //Каждая компания имеет не более одной АЗС на каждой улице; цены на разных АЗС одной и той же компании могут различаться.
            //Для каждой улицы определить количество АЗС(вначале выводить название улицы, затем количество АЗС). Сведения о каждой
            //улице выводить на новой строке и упорядочивать по названиям улиц в алфавитном порядке. 

            Task("LinqObj45");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => x[3],
                        //условие некорректное, поэтому Distinct убираем повторяющиеся названия компаний
                        (x, y) => new { street = x, count = y.Select(yy => yy[0]).Distinct().Count() }) 
                .OrderBy(x => x.street)
                .Select(x => $"{x.street} {x.count}");

            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
