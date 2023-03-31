// File: "LinqObj40"
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

            //LinqObj40°. Исходная последовательность содержит сведения об автозаправочных станциях (АЗС). Каждый элемент
            //последовательности включает следующие поля:

                // < Компания >
                // < Улица >
                // < Марка бензина >
                // < Цена 1 литра(в копейках) >

            //Названия компаний и улиц не содержат пробелов. В качестве марки бензина указываются числа 92, 95 или 98.
            //Каждая компания имеет не более одной АЗС на каждой улице; цены на разных АЗС одной и той же компании могут различаться.
            //Для каждой улицы определить количество АЗС, предлагавших определенную марку бензина(вначале выводить название улицы,
            //затем три числа — количество АЗС для бензина марки 92, 95 и 98; некоторые из этих чисел могут быть равны 0).
            //Сведения о каждой улице выводить на новой строке и упорядочивать по названиям улиц в алфавитном порядке. 
            Task("LinqObj40");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => x[1],
                        (x, y) => new { 
                                        street = x, 
                                        brand92 = y.Count(yy => yy[2] == "92"), 
                                        brand95 = y.Count(yy => yy[2] == "95"), 
                                        brand98 = y.Count(yy => yy[2] == "98") })
                .OrderBy(x => x.street)
                .Select(x => $"{x.street} {x.brand92} {x.brand95} {x.brand98}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
