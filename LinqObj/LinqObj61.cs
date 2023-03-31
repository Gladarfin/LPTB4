// File: "LinqObj61"
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
            //LinqObj61°. Исходная последовательность содержит сведения об оценках учащихся по трем предметам: алгебре,
            //геометрии и физике. Каждый элемент последовательности содержит данные об одной оценке и включает следующие поля:

                //< Фамилия >
                //< Инициалы >
                //< Класс >
                //< Название предмета >
                //< Оценка >

            //Полных однофамильцев(с совпадающей фамилией и инициалами) среди учащихся нет. Класс задается целым числом,
            //оценка — целое число в диапазоне 2–5.Название предмета указывается с заглавной буквы.Для каждого учащегося определить
            //среднюю оценку по каждому предмету и вывести ее с двумя дробными знаками(если по какому-либо предмету учащийся не
            //получил ни одной оценки, то вывести для этого предмета 0.00). Сведения о каждом учащемся выводить на отдельной строке,
            //указывая фамилию, инициалы и средние оценки по алгебре, геометрии и физике. Данные располагать в алфавитном порядке
            //фамилий и инициалов. 

            Task("LinqObj61");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => x[0] + ' ' + x[1])
                .Select(x => new { student = x.Key,
                            alg = x.Where(a => a[3] == "Algebra").Select(a => int.Parse(a[4])).DefaultIfEmpty().Average().ToString("0.00", CultureInfo.InvariantCulture),
                            geo = x.Where(a => a[3] == "Geometry").Select(a => int.Parse(a[4])).DefaultIfEmpty().Average().ToString("0.00", CultureInfo.InvariantCulture),
                            phy = x.Where(a => a[3] == "Physics").Select(a => int.Parse(a[4])).DefaultIfEmpty().Average().ToString("0.00", CultureInfo.InvariantCulture)
                })
                .OrderBy(x => x.student)
                .Select(x => $"{x.student} {x.alg} {x.geo} {x.phy}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
