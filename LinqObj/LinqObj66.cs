// File: "LinqObj66"
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
            //LinqObj66°. Дана строка S — название одного из трех предметов: алгебры, геометрии или физики. Исходная последовательность
            //содержит сведения об оценках учащихся по этим трем предметам. Каждый элемент последовательности содержит данные
            //об одной оценке и включает следующие поля:

            //  < Название предмета >
            //  < Фамилия >
            //  < Инициалы >
            //  < Оценка >
            //  < Класс >

            //Полных однофамильцев(с совпадающей фамилией и инициалами) среди учащихся нет.Класс задается целым числом,
            //оценка — целое число в диапазоне 2–5.Название предмета указывается с заглавной буквы.Для каждого класса,
            //присутствующего в наборе исходных данных, определить число учащихся, имеющих по предмету S среднюю оценку
            //не менее 3.5 и при этом не получивших ни одной двойки по этому предмету.Сведения о каждом классе выводить
            //на отдельной строке, указывая номер класса и число найденных учащихся(число может быть равно 0).
            //Данные упорядочивать по возрастанию номера класса. 

            Task("LinqObj66");
            var s = GetString();
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[4]))
                .Select(x => new
                {
                    cl = x.Key,
                    subj = x.GroupBy(st => st[1] + ' ' + st[2])
                            .Select(y => new
                            {
                                avg = y.Where(su => su[0] == s).Select(sm => int.Parse(sm[3])).DefaultIfEmpty().Average(),
                                ds = y.Where(su => su[0] == s && int.Parse(su[3]) == 2).Select(sm => int.Parse(sm[3])).Count()
                            })
                            .Where(k => k.avg >= 3.5 && k.ds == 0)
                            .Count()
                })
                .OrderBy(x => x.cl)
                .Select(x => $"{x.cl} {x.subj}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
