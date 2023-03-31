// File: "LinqObj67"
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
            //LinqObj67°. Исходная последовательность содержит сведения об оценках учащихся по трем предметам:
            //алгебре, геометрии и физике. Каждый элемент последовательности содержит данные об одной оценке и включает следующие поля:

                //< Класс >
                //< Название предмета >
                //< Фамилия >
                //< Инициалы >
                //< Оценка >

            //Полных однофамильцев(с совпадающей фамилией и инициалами) среди учащихся нет. Класс задается целым числом,
            //оценка — целое число в диапазоне 2–5.Название предмета указывается с заглавной буквы.Найти всех двоечников — учащихся,
            //получивших хотя бы одну двойку по какому - либо предмету.Вывести сведения о каждом из двоечников: номер класса, фамилию,
            //инициалы и полученное число двоек. Сведения о каждом двоечнике выводить на отдельной строке и располагать по убыванию
            //классов, а для одинаковых классов — в алфавитном порядке фамилий и инициалов. Если в наборе исходных данных нет ни
            //одной двойки, то записать в результирующий файл текст «Students not found». 

            Task("LinqObj67");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(st => st[2] + ' ' + st[3])
                .Select(x => new { student = x.Key, 
                                   ds = x.Where(y => int.Parse(y[4]) == 2).Count(),
                                   cl = x.Select(c => int.Parse(c[0])).First()
                })
                .Where(x => x.ds > 0)
                .OrderByDescending(x => x.cl)
                .ThenBy(x => x.student)
                .Select(x => $"{x.cl} {x.student} {x.ds}")
                .DefaultIfEmpty("Students not found");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
