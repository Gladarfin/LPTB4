// File: "LinqObj26"
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
            //LinqObj26°. Исходная последовательность содержит сведения о задолжниках по оплате коммунальных услуг, 
            //живущих в 144 - квартирном 9 - этажном доме.Каждый элемент последовательности включает следующие поля:

            //    < Номер квартиры > 
            //    < Фамилия > 
            //    < Задолженность >

            //Задолженность указывается в виде дробного числа(целая часть — рубли, дробная часть — копейки).
            //В каждом подъезде на каждом этаже располагаются по 4 квартиры.Для каждого из 4 подъездов дома 
            //вывести сведения о задолжниках, живущих в этом подъезде: номер подъезда, число задолжников, 
            //средняя задолженность для жильцов этого подъезда(выводится с двумя дробными знаками). 
            //Жильцы, не имеющие долга, при вычислении средней задолженности не учитываются. Сведения о каждом 
            //подъезде выводить на отдельной строке и упорядочивать по возрастанию номера подъезда. 
            //Если в каком - либо подъезде задолжники отсутствуют, то данные об этом подъезде не выводить.

            Task("LinqObj26");

            var r = File.ReadAllLines(GetString(), Encoding.Default).Show()
            .Select(x => new
            {
                debt = double.Parse(x.Split(' ')[2], CultureInfo.InvariantCulture),
                entrance = (int.Parse(x.Split(' ')[0]) - 1) / 36 + 1
            })
            .Where(d => d.debt != 0)
            .GroupBy(x => x.entrance)
            .OrderBy(g => g.Key)
            .Select(y => y.Key.ToString() + ' ' 
            + y.Count().ToString() + ' ' 
            + y.Average(yy => yy.debt).ToString("0.00", CultureInfo.InvariantCulture));
            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
