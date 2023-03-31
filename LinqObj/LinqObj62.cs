// File: "LinqObj62"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            //LinqObj62°. Исходная последовательность содержит сведения об оценках учащихся по трем предметам: алгебре,
            //геометрии и физике. Каждый элемент последовательности содержит данные об одной оценке и включает следующие поля:

                //< Класс >
                //< Фамилия >
                //< Инициалы >
                //< Оценка >
                //< Название предмета >

            //Полных однофамильцев(с совпадающей фамилией и инициалами) среди учащихся нет. Класс задается целым числом,
            //оценка — целое число в диапазоне 2–5.Название предмета указывается с заглавной буквы.Для каждого учащегося определить
            //количество оценок по каждому предмету(если по какому - либо предмету учащийся не получил ни одной оценки,
            //то вывести для этого предмета число 0).Сведения о каждом учащемся выводить на отдельной строке, указывая класс,
            //фамилию, инициалы и количество оценок по алгебре, геометрии и физике.Данные располагать в порядке возрастания
            //номера класса, а для одинаковых классов — в алфавитном порядке фамилий и инициалов. 
            Task("LinqObj62");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => x[1] + ' ' + x[2])
                .Select(x => new
                {
                    student = x.Key,
                    alg = x.Where(a => a[4] == "Algebra").Select(a => int.Parse(a[3])).Count(),
                    geo = x.Where(a => a[4] == "Geometry").Select(a => int.Parse(a[3])).Count(),
                    phy = x.Where(a => a[4] == "Physics").Select(a => int.Parse(a[3])).Count(),
                    cl = x.Select(c => int.Parse(c[0])).First()
                })
                .OrderBy(x => x.cl)
                .ThenBy(x => x.student)
                .Select(x => $"{x.cl} {x.student} {x.alg} {x.geo} {x.phy}");
              
            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
