// File: "LinqObj68"
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
            //LinqObj68°. Исходная последовательность содержит сведения об оценках учащихся по трем предметам: алгебре,
            //геометрии и физике. Каждый элемент последовательности содержит данные об одной оценке и включает следующие поля:

                //< Класс >
                //< Оценка >
                //< Фамилия >
                //< Инициалы >
                //< Название предмета >

            //Полных однофамильцев(с совпадающей фамилией и инициалами) среди учащихся нет.Класс задается целым числом,
            //оценка — целое число в диапазоне 2–5.Название предмета указывается с заглавной буквы.Найти всех хорошистов — учащихся,
            //не получивших ни одной двойки и тройки, но имеющих хотя бы одну четверку по какому-либо предмету.Вывести сведения
            //о каждом хорошисте: полученное число четверок, фамилию, инициалы и номер класса. Сведения о каждом учащемся выводить
            //на отдельной строке и располагать по возрастанию количества четверок, а при их равенстве — в алфавитном порядке фамилий
            //и инициалов. Если в наборе исходных данных нет ни одного учащегося, удовлетворяющего указанным условиям, то записать
            //в результирующий файл текст «Students not found». 

            Task("LinqObj68");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(st => st[2] + ' ' + st[3])
                .Select(x => new {
                    student = x.Key,
                    ds = x.Where(y => int.Parse(y[1]) == 2 || int.Parse(y[1]) == 3).Count(),
                    bs = x.Where(y => int.Parse(y[1]) == 4).Count(),
                    cl = x.Select(c => int.Parse(c[0])).First()
                })
                .Where(x => x.ds == 0 && x.bs > 0)
                .OrderBy(x => x.bs)
                .ThenBy(x => x.student)
                .Select(x => $"{x.bs} {x.student} {x.cl}")
                .DefaultIfEmpty("Students not found");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
