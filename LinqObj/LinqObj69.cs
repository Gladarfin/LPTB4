// File: "LinqObj69"
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
            //LinqObj69°. Исходная последовательность содержит сведения об оценках учащихся по трем предметам:
            //алгебре, геометрии и физике. Каждый элемент последовательности содержит данные об одной оценке и включает следующие поля:

                //< Класс >
                //< Фамилия >
                //< Инициалы >
                //< Название предмета >
                //< Оценка >

            //Полных однофамильцев(с совпадающей фамилией и инициалами) среди учащихся нет.Класс задается целым числом, оценка —
            //целое число в диапазоне 2–5.Название предмета указывается с заглавной буквы.Для каждого класса найти
            //злостных двоечников — учащихся, получивших в данном классе максимальное суммарное число двоек по всем предметам(число
            //не должно быть нулевым). Вывести сведения о каждом из злостных двоечников: фамилию, инициалы, номер класса и полученное
            //число двоек. Сведения о каждом двоечнике выводить на отдельной строке и располагать в алфавитном порядке их фамилий
            //и инициалов (сортировку по классам не проводить). Если в наборе исходных данных нет ни одной двойки,
            //то записать в результирующий файл текст «Students not found». 

            Task("LinqObj69");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => x[0])
                .Select(g => new
                {
                    cls = g.Key,
                    maxCnt = g.GroupBy(g2 => g2[1] + ' ' + g2[2],
                                        (g2, y) => new { cnt = y.Where(gg => int.Parse(gg[4]) == 2).Count() })
                               .Max(x => x.cnt),
                    pupils = g.GroupBy(g3 => g3[1] + ' ' + g3[2],
                                        (g3, y) => new
                                        {
                                            fullname = g3,
                                            cls = g.Key,
                                            cnt = y.Where(gg => int.Parse(gg[4]) == 2).Count()
                                        })
                })
                .Where(x => x.maxCnt > 0)
                .SelectMany(e => e.pupils.Where(ee => ee.cnt == e.maxCnt))
                .OrderBy(x => x.fullname)
                .Select(x => $"{x.fullname} {x.cls} {x.cnt}")
                .DefaultIfEmpty("Students not found");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
