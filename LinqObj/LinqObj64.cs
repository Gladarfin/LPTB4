// File: "LinqObj64"
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
            //LinqObj64°. Исходная последовательность содержит сведения об оценках учащихся по трем предметам: алгебре,
            //геометрии и физике. Каждый элемент последовательности содержит данные об одной оценке и включает следующие поля:

            //  < Класс >
            //  < Фамилия >
            //  < Инициалы >
            //  < Название предмета >
            //  < Оценка >

            //Полных однофамильцев(с совпадающей фамилией и инициалами) среди учащихся нет.Класс задается целым числом,
            //оценка — целое число в диапазоне 2–5.Название предмета указывается с заглавной буквы.Вывести сведения об учащихся,
            //имеющих по физике среднюю оценку не менее 4: номер класса, фамилию, инициалы и среднюю оценку по физике(выводится с двумя
            //дробными знаками).Сведения о каждом учащемся выводить на отдельной строке и располагать в порядке возрастания классов,
            //а для одинаковых классов — в алфавитном порядке фамилий и инициалов. Если ни один из учащихся не удовлетворяет указанным
            //условиям, то записать в результирующий файл текст «Students not found». 

            Task("LinqObj64");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => x[1] + ' ' + x[2])
                .Select(x => new
                {
                    student = x.Key,
                    phy = x.Where(a => a[3] == "Physics")
                                   .Select(a => int.Parse(a[4]))
                                   .DefaultIfEmpty()
                                   .Average(),
                    cl = x.Select(c => int.Parse(c[0])).First()
                })
                .Where(x => x.phy >= 4)
                .OrderBy(x => x.cl)
                .ThenBy(x => x.student)
                .Select(x => $"{x.cl} {x.student} {x.phy.ToString("0.00", CultureInfo.InvariantCulture)}")
                .DefaultIfEmpty("Students not found");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
