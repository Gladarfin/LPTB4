// File: "LinqObj37"
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
            //LinqObj37°. Исходная последовательность содержит сведения об автозаправочных станциях(АЗС).
            //Каждый элемент последовательности включает следующие поля:

            //    < Компания > 
            //    < Марка бензина > 
            //    < Цена 1 литра(в копейках) >
            //    < Улица >

            //Названия компаний и улиц не содержат пробелов. В качестве марки бензина указываются числа 92, 95 или 98.
            //Каждая компания имеет не более одной АЗС на каждой улице; цены на разных АЗС одной и той же компании могут различаться.
            //Для каждой марки бензина, присутствующей в исходных данных, определить минимальную и максимальную цену 
            //литра бензина этой марки(вначале выводить марку, затем цены в указанном порядке).Сведения о каждой марке 
            //выводить на новой строке и упорядочивать по убыванию значения марки.

            Task("LinqObj37");

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[1]))
                .OrderByDescending(x => x.Key)
                .Select(x => $"{x.Key} {x.Min(y => int.Parse(y[2]))} {x.Max(y => int.Parse(y[2]))}");


            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
