// File: "LinqObj65"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Threading;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            //LinqObj65°. Дана строка S — название одного из трех предметов: алгебры, геометрии или физики.
            //Исходная последовательность содержит сведения об оценках учащихся по этим трем предметам.
            //Каждый элемент последовательности содержит данные об одной оценке и включает следующие поля:

            //  < Фамилия >
            //  < Инициалы >
            //  < Название предмета >
            //  < Оценка >
            //  < Класс >

            //Полных однофамильцев(с совпадающей фамилией и инициалами) среди учащихся нет.Класс задается целым числом,
            //оценка — целое число в диапазоне 2–5.Название предмета указывается с заглавной буквы.Для каждого класса,
            //присутствующего в наборе исходных данных, определить число учащихся, имеющих по предмету S среднюю оценку не более 3.5
            //или не имеющих ни одной оценки по этому предмету.Сведения о каждом классе выводить на отдельной строке, указывая число
            //найденных учащихся(число может быть равно 0) и номер класса.Данные упорядочивать по возрастанию числа учащихся,
            //а для совпадающих чисел — по убыванию номера класса. 

            Task("LinqObj65");
            var s = GetString();
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[4]))
                .Select(x => new
                {
                    cl = x.Key,
                    subj = x.GroupBy(st => st[0] + ' ' + st[1])
                            .Select(y => y.Where(su => su[2] == s).Select(sm => int.Parse(sm[3])).DefaultIfEmpty().Average())
                            .Where(k => k <= 3.5)
                            .Count()

                })
                .OrderBy(x => x.subj)
                .ThenByDescending(x => x.cl)
                .Select(x => $"{x.subj} {x.cl}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
