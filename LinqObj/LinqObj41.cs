// File: "LinqObj41"
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
            // LinqObj41°. Дано целое число M — значение одной из марок бензина. Исходная последовательность содержит сведения
            // об автозаправочных станциях (АЗС). Каждый элемент последовательности включает следующие поля:

            //      < Марка бензина >
            //      < Улица >
            //      < Компания >
            //      < Цена 1 литра(в копейках) >

            // Названия компаний и улиц не содержат пробелов. В качестве марки бензина указываются числа 92, 95 или 98. Каждая компания
            // имеет не более одной АЗС на каждой улице; цены на разных АЗС одной и той же компании могут различаться.
            // Для каждой улицы, на которой имеются АЗС с бензином марки M, определить максимальную цену бензина этой марки
            // (вначале выводить максимальную цену, затем название улицы).Сведения о каждой улице выводить на новой строке и
            // упорядочивать по возрастанию максимальной цены, а для одинаковой цены — по названиям улиц в алфавитном порядке.
            // Если ни одной АЗС с бензином марки M не найдено, то записать в результирующий файл строку «No». 

            Task("LinqObj41");
            int m = GetInt();
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .Where(x => int.Parse(x[0]) == m)
                .GroupBy(x => x[1])
                .Select(g => new { street = g.Key, max = g.Max(x => int.Parse(x[3])) })
                .OrderBy(x => x.max)
                .ThenBy(x => x.street)
                .Select(g => $"{g.max} {g.street}")
                .DefaultIfEmpty("No");

           File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
