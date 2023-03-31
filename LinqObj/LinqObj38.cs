// File: "LinqObj38"
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
            //LinqObj38°. Исходная последовательность содержит сведения об автозаправочных станциях(АЗС).
            //Каждый элемент последовательности включает следующие поля:

            //    < Цена 1 литра(в копейках) > 
            //    < Марка бензина > 
            //    < Компания > 
            //    < Улица >

            //Названия компаний и улиц не содержат пробелов. В качестве марки бензина указываются числа 92, 95 или 98.
            //Каждая компания имеет не более одной АЗС на каждой улице; цены на разных АЗС одной и той же компании могут различаться.
            //Для каждой марки бензина, присутствующей в исходных данных, определить количество станций, предлагавших эту марку
            //(вначале выводить количество станций, затем номер марки).Сведения о каждой марке выводить на новой строке и упорядочивать 
            //по возрастанию количества станций, а для одинакового количества — по возрастанию значения марки. 

            Task("LinqObj38");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => new { brand = int.Parse(x.Split(' ')[1]), comp = x.Split(' ')[2] })
                .GroupBy(x => x.brand)
                .Select(x => new { brand = x.Key, count = x.Count() })
                .OrderBy(x => x.count)
                .ThenBy(y => y.brand)
                .Select(x => $"{x.count} {x.brand}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
