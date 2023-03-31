// File: "LinqObj35"
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
            //LinqObj35°. Исходная последовательность содержит сведения о задолжниках по оплате коммунальных услуг, 
            //живущих в 144 - квартирном 9 - этажном доме.Каждый элемент последовательности включает следующие поля:

            //    < Задолженность > 
            //    < Фамилия > 
            //    < Номер квартиры >

            //Задолженность указывается в виде дробного числа(целая часть — рубли, дробная часть — копейки).
            //В каждом подъезде на каждом этаже располагаются по 4 квартиры.Для каждого из 4 подъездов дома 
            //найти задолжников, долг которых не меньше величины средней задолженности по данному подъезду, 
            //и вывести сведения о них: номер подъезда, задолженность (выводится с двумя дробными знаками), 
            //фамилия, номер квартиры.Жильцы, не имеющие долга, при вычислении средней задолженности не учитываются. 
            //Сведения о каждом задолжнике выводить на отдельной строке и упорядочивать по возрастанию номеров подъездов, 
            //а для одинаковых подъездов — по убыванию размера задолженности. Считать, что в наборе исходных данных 
            //все задолженности имеют различные значения. 

            Task("LinqObj35");

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => new
                {
                    surname = x.Split(' ')[1],
                    flat = int.Parse(x.Split(' ')[2]),
                    debt = double.Parse(x.Split(' ')[0], CultureInfo.InvariantCulture),
                    entrance = (int.Parse(x.Split(' ')[2]) - 1) / 36 + 1
                })
                .GroupBy(x => x.entrance)
                .OrderBy(x => x.Key)
                .SelectMany(x => x.OrderByDescending(y => y.debt).Where(d => 
                                                                            d.debt >= 
                                                                            x.Where(de => de.debt > 0).Average(de => de.debt)
                                                                  )
                )
                .Select(x => $"{x.entrance} {x.debt.ToString("0.00", CultureInfo.InvariantCulture)} {x.surname} {x.flat}");

            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
