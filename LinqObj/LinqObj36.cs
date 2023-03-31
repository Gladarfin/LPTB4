// File: "LinqObj36"
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
            //LinqObj36∞. »сходна€ последовательность содержит сведени€ о задолжниках по оплате коммунальных услуг, 
            //живущих в 144 - квартирном 9 - этажном доме. аждый элемент последовательности включает следующие пол€:

            //    < Ќомер квартиры > 
            //    < ‘амили€ > 
            //    < «адолженность >

            //«адолженность указываетс€ в виде дробного числа(цела€ часть Ч рубли, дробна€ часть Ч копейки).
            //¬ каждом подъезде на каждом этаже располагаютс€ по 4 квартиры.ƒл€ каждого из 9 этажей дома найти задолжников, 
            //долг которых не больше величины средней задолженности по данному этажу, и вывести сведени€ о них: номер этажа, 
            //задолженность (выводитс€ с двум€ дробными знаками), фамили€, номер квартиры.∆ильцы, не имеющие долга, 
            //при вычислении средней задолженности не учитываютс€. —ведени€ о каждом задолжнике выводить на отдельной строке и 
            //упор€дочивать по возрастанию номеров этажей, а дл€ одинаковых этажей Ч по возрастанию размера задолженности. 
            //—читать, что в наборе исходных данных все задолженности имеют различные значени€. 

            Task("LinqObj36");

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => new
                {
                    surname = x.Split(' ')[1],
                    flat = int.Parse(x.Split(' ')[0]),
                    debt = double.Parse(x.Split(' ')[2], CultureInfo.InvariantCulture),
                    floor = (int.Parse(x.Split(' ')[0]) - 1) % 36 / 4 + 1
                })
                .GroupBy(x => x.floor)
                .OrderBy(x => x.Key)
                .SelectMany(x => x.OrderBy(y => y.debt).Where(d =>
                                                                  d.debt <=
                                                                  x.Where(de => de.debt > 0).Average(de => de.debt)
                                                        )
                )
                .Select(x => $"{x.floor} {x.debt.ToString("0.00", CultureInfo.InvariantCulture)} {x.surname} {x.flat}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
