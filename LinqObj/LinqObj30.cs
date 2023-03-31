// File: "LinqObj30"
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
            // LinqObj30°. Исходная последовательность содержит сведения о задолжниках по оплате коммунальных услуг, 
            // живущих в 144 - квартирном 9 - этажном доме.Каждый элемент последовательности включает следующие поля:
            // 
            //     < Фамилия > 
            //     < Задолженность > 
            //     < Номер квартиры >
            // 
            // Задолженность указывается в виде дробного числа(целая часть — рубли, дробная часть — копейки).
            // В каждом подъезде на каждом этаже располагаются по 4 квартиры.Для каждого из 9 этажей дома найти 
            // жильца с наименьшей задолженностью и вывести сведения о нем: номер квартиры, номер этажа, фамилия жильца, 
            // задолженность (выводится с двумя дробными знаками). Считать, что в наборе исходных данных все задолженности 
            // имеют различные значения. Сведения о каждом задолжнике выводить на отдельной строке и упорядочивать по возрастанию 
            // номера квартиры. Если на каком - либо этаже задолжники отсутствуют, то данные об этом этаже не выводить.

            Task("LinqObj30");

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => new
                {
                    surname = x.Split(' ')[0],
                    debt = double.Parse(x.Split(' ')[1], CultureInfo.InvariantCulture),
                    flat = int.Parse(x.Split(' ')[2]),
                    floor = (int.Parse(x.Split(' ')[2]) - 1) % 36 / 4 + 1
                })
                .GroupBy(x => x.floor)
                .SelectMany(x => x.OrderBy(y => y.debt).Take(1))
                .OrderBy(x => x.flat)
                .Select(x => $"{x.flat} {x.floor} {x.surname} {x.debt.ToString("0.00", CultureInfo.InvariantCulture)}");

            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
