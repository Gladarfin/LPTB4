// File: "LinqObj33"
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
            //LinqObj33°. Исходная последовательность содержит сведения о задолжниках по оплате коммунальных услуг, 
            //живущих в 144 - квартирном 9 - этажном доме.Каждый элемент последовательности включает следующие поля:

            //    < Номер квартиры > 
            //    < Задолженность > 
            //    < Фамилия >

            //Задолженность указывается в виде дробного числа(целая часть — рубли, дробная часть — копейки).
            //В каждом подъезде на каждом этаже располагаются по 4 квартиры.Найти жильцов, долг которых не меньше величины 
            //средней задолженности по дому, и вывести сведения о них: номер квартиры, фамилия, задолженность 
            //(выводится с двумя дробными знаками). Жильцы, не имеющие долга, при вычислении средней задолженности не учитываются. 
            //Сведения о каждом задолжнике выводить на отдельной строке и упорядочивать по возрастанию номеров квартир. 

            Task("LinqObj33");
            var f = File.ReadAllLines(GetString(), Encoding.Default);
            var avg = f.Where(y => double.Parse(y.Split(' ')[1]) > 0).Average(x => double.Parse(x.Split(' ')[1], CultureInfo.InvariantCulture));
            var r = f
                .Select(x => new
                {
                    surname = x.Split(' ')[2],
                    flat = int.Parse(x.Split(' ')[0]),
                    debt = double.Parse(x.Split(' ')[1], CultureInfo.InvariantCulture),
                })
                .Where(y => y.debt >= avg)
                .OrderBy(x => x.flat)
                .Select(x => $"{x.flat} {x.surname} {x.debt.ToString("0.00", CultureInfo.InvariantCulture)}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
