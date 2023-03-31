// File: "LinqObj43"
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
            //LinqObj43°. Дано целое число M — значение одной из марок бензина.Исходная последовательность содержит сведения
            //об автозаправочных станциях(АЗС).Каждый элемент последовательности включает следующие поля:

           //   < Цена 1 литра(в копейках) >
           //   < Марка бензина >
           //   < Улица >
           //   < Компания >

            //Названия компаний и улиц не содержат пробелов. В качестве марки бензина указываются числа 92, 95 или 98.
            //Каждая компания имеет не более одной АЗС на каждой улице; цены на разных АЗС одной и той же компании могут различаться.
            //Для каждой компании определить разброс цен на бензин указанной марки M(вначале выводить разность максимальной и
            //минимальной цены бензина марки M для АЗС данной компании, затем — название компании).Если бензин марки M не предлагался
            //данной компанией, то разброс положить равным −1.Сведения о каждой компании выводить на новой строке, данные упорядочивать
            //по убыванию значений разброса, а для равных значений разброса — по названиям компаний в алфавитном порядке. 

            Task("LinqObj43");
            var m = GetInt();
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => x[3],
                        (x, y) => new { company = x, diff = y.Where(yy => int.Parse(yy[1]) == m).Count() == 0 ? 
                        -1 : 
                        y.Where(mx => int.Parse(mx[1]) == m).Select(mx => int.Parse(mx[0])).Max() 
                        - y.Where(mi => int.Parse(mi[1]) == m).Select(mi => int.Parse(mi[0])).Min() })
                .OrderByDescending(x => x.diff)
                .ThenBy(x => x.company)
                .Select(x => $"{x.diff} {x.company}");

            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
