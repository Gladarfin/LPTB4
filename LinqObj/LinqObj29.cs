// File: "LinqObj29"
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
            //LinqObj29°. Исходная последовательность содержит сведения о задолжниках по оплате коммунальных услуг, 
            //живущих в 144 - квартирном 9 - этажном доме.Каждый элемент последовательности включает следующие поля:

            //    < Номер квартиры > 
            //    < Фамилия > 
            //    < Задолженность >

            //Задолженность указывается в виде дробного числа(целая часть — рубли, дробная часть — копейки).
            //В каждом подъезде на каждом этаже располагаются по 4 квартиры.Для каждого из 4 подъездов дома 
            //найти жильца с наибольшей задолженностью и вывести сведения о нем: номер подъезда, номер квартиры, 
            //фамилия жильца, задолженность (выводится с двумя дробными знаками). Считать, что в наборе исходных 
            //данных все задолженности имеют различные значения. Сведения о каждом задолжнике выводить на отдельной 
            //строке и упорядочивать по возрастанию номера подъезда. Если в каком - либо подъезде задолжники отсутствуют, 
            //то данные об этом подъезде не выводить.

            Task("LinqObj29");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => new
                {
                    surname = x.Split(' ')[1],
                    debt = double.Parse(x.Split(' ')[2], CultureInfo.InvariantCulture),
                    entrance = (int.Parse(x.Split(' ')[0]) - 1) / 36 + 1,
                    flatNumber = x.Split(' ')[0]
                })
                .GroupBy(x => x.entrance)
                .OrderBy(x => x.Key)
                .Select(group => group.OrderByDescending(g => g.debt).First())
                .Select(x => $"{x.entrance} {x.flatNumber} {x.surname} {x.debt.ToString("0.00", CultureInfo.InvariantCulture)}");
     

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
