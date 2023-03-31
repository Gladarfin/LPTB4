// File: "LinqObj31"
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
            //LinqObj31°. Исходная последовательность содержит сведения о задолжниках по оплате коммунальных услуг, 
            //живущих в 144 - квартирном 9 - этажном доме.Каждый элемент последовательности включает следующие поля:

            //        < Задолженность > 
            //        < Фамилия > 
            //        < Номер квартиры >

            //Задолженность указывается в виде дробного числа(целая часть — рубли, дробная часть — копейки).
            //В каждом подъезде на каждом этаже располагаются по 4 квартиры. Для каждого из 4 подъездов дома 
            //найти трех жильцов с наибольшей задолженностью и вывести сведения о них: задолженность(выводится с двумя дробными знаками),
            //номер подъезда, номер квартиры, фамилия жильца. Считать, что в наборе исходных данных 
            //все задолженности имеют различные значения. Сведения о каждом задолжнике выводить на отдельной строке 
            //и упорядочивать по убыванию размера задолженности(номер подъезда при сортировке не учитывать). 
            //Если в каком - либо подъезде число задолжников меньше трех, то включить в полученный набор всех задолжников этого подъезда.

            Task("LinqObj31");

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => new
                {
                    surname = x.Split(' ')[1],
                    debt = double.Parse(x.Split(' ')[0], CultureInfo.InvariantCulture),
                    flat = int.Parse(x.Split(' ')[2]),
                    entrance = (int.Parse(x.Split(' ')[2]) - 1) / 36 + 1
                })
                .GroupBy(x => x.entrance)
                .SelectMany(x => x.OrderByDescending(d => d.debt).Take(3))
                .OrderByDescending(d => d.debt)
                .Select(x => $"{x.debt.ToString("0.00", CultureInfo.InvariantCulture)} {x.entrance} {x.flat} {x.surname}");

            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
