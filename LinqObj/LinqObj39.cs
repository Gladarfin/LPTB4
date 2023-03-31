// File: "LinqObj39"
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
            //LinqObj39°. Дано целое число M — значение одной из марок бензина. Исходная последовательность 
            //содержит сведения об автозаправочных станциях(АЗС).Каждый элемент последовательности включает следующие поля:

            //    < Улица > 
            //    < Компания > 
            //    < Марка бензина > 
            //    < Цена 1 литра(в копейках) >

            //Названия компаний и улиц не содержат пробелов. В качестве марки бензина указываются числа 92, 95 или 98.
            //Каждая компания имеет не более одной АЗС на каждой улице; цены на разных АЗС одной и той же компании могут различаться.
            //Для каждой улицы определить количество АЗС, предлагавших марку бензина M(вначале выводить количество АЗС на данной улице,
            //затем название улицы; количество АЗС может быть равно 0). Сведения о каждой улице выводить на новой строке и упорядочивать 
            //по возрастанию количества АЗС, а для одинакового количества — по названиям улиц в алфавитном порядке. 

            Task("LinqObj39");
            var m = GetInt();
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => x[0])
                .Select(x => new { street = x.Key, count = x.Where(y => int.Parse(y[2]) == m).Count() })
                .OrderBy(x => x.count)
                .ThenBy(x => x.street)
                .Select(x => $"{x.count} {x.street}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
