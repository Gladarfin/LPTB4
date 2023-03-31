// File: "LinqObj44"
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
            //LinqObj44°. Исходная последовательность содержит сведения об автозаправочных станциях (АЗС). Каждый элемент
            //последовательности включает следующие поля:

                //< Марка бензина >
                //< Цена 1 литра(в копейках) >
                //< Компания >
                //< Улица >

            //Названия компаний и улиц не содержат пробелов. В качестве марки бензина указываются числа 92, 95 или 98.
            //Каждая компания имеет не более одной АЗС на каждой улице; цены на разных АЗС одной и той же компании могут различаться.
            //Для каждой компании определить разброс цен для всех марок бензина(вначале выводить название компании,
            //затем три числа — разброс цен для бензина марки 92, 95 и 98). При отсутствии бензина нужной марки выводить число −1.
            //Сведения о каждой компании выводить на новой строке и упорядочивать по названиям компаний в алфавитном порядке.

            Task("LinqObj44");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => x[2],
                        (x, y) => new {
                            company = x,
                            diff92 = y.Where(yy => yy[0] == "92").Count() == 0 ?
                                     -1 :
                                     y.Where(yy => yy[0] == "92").Select(mx => int.Parse(mx[1])).Max()
                                     - y.Where(yy => yy[0] == "92").Select(mi => int.Parse(mi[1])).Min(),
                            diff95 = y.Where(yy => yy[0] == "95").Count() == 0 ?
                                     -1 :
                                     y.Where(yy => yy[0] == "95").Select(mx => int.Parse(mx[1])).Max()
                                     - y.Where(yy => yy[0] == "95").Select(mi => int.Parse(mi[1])).Min(),
                            diff98 = y.Where(yy => yy[0] == "98").Count() == 0 ?
                                     -1 :
                                     y.Where(yy => yy[0] == "98").Select(mx => int.Parse(mx[1])).Max()
                                     - y.Where(yy => yy[0] == "98").Select(mi => int.Parse(mi[1])).Min(),

                        })
                .OrderBy(x => x.company)
                .Select(x => $"{x.company} {x.diff92} {x.diff95} {x.diff98}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
