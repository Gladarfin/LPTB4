// File: "LinqObj63"
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
            //LinqObj63°. Исходная последовательность содержит сведения об оценках учащихся по трем предметам: алгебре,
            //геометрии и физике. Каждый элемент последовательности содержит данные об одной оценке и включает следующие поля:

                //< Название предмета >
                //< Фамилия >
                //< Инициалы >
                //< Класс >
                //< Оценка >

            //Полных однофамильцев(с совпадающей фамилией и инициалами) среди учащихся нет.Класс задается целым числом,
            //оценка — целое число в диапазоне 2–5.Название предмета указывается с заглавной буквы.Вывести сведения об учащихся,
            //имеющих по алгебре среднюю оценку не более 4: фамилию, инициалы, номер класса и среднюю оценку по алгебре(выводится
            //с двумя дробными знаками).Для учащихся, не имеющих ни одной оценки по алгебре, считать среднюю оценку равной 0.00.
            //Сведения о каждом учащемся выводить на отдельной строке и располагать в алфавитном порядке их фамилий и инициалов.
            //Если ни один из учащихся не удовлетворяет указанным условиям, то записать в результирующий файл текст «Students not found». 
            Task("LinqObj63");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => x[1] + ' ' + x[2])
                .Select(x => new
                {
                    student = x.Key,
                    alg = x.Where(a => a[0] == "Algebra")
                                   .Select(a => int.Parse(a[4]))
                                   .DefaultIfEmpty()
                                   .Average(),
                    cl = x.Select(c => c[3]).First()
                })
                .Where(x => x.alg <= 4)
                .OrderBy(x => x.student)
                .Select(x => $"{x.student} {x.cl} {x.alg.ToString("0.00", CultureInfo.InvariantCulture)}")
                .DefaultIfEmpty("Students not found");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
