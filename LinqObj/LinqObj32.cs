// File: "LinqObj32"
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
            //LinqObj32∞. »сходна€ последовательность содержит сведени€ о задолжниках по оплате коммунальных услуг, 
            //живущих в 144 - квартирном 9 - этажном доме. аждый элемент последовательности включает следующие пол€:

            //    < ‘амили€ > 
            //    < Ќомер квартиры > 
            //    < «адолженность >

            //«адолженность указываетс€ в виде дробного числа(цела€ часть Ч рубли, дробна€ часть Ч копейки).
            //¬ каждом подъезде на каждом этаже располагаютс€ по 4 квартиры.ƒл€ каждого из 9 этажей дома найти жильца 
            //с наименьшей задолженностью и вывести сведени€ о нем: номер этажа и задолженность(выводитс€ с двум€ дробными знаками).
            //—читать, что в наборе исходных данных все задолженности имеют различные значени€. —ведени€ о каждом этаже выводить на 
            //отдельной строке и упор€дочивать по возрастанию номера этажа. ≈сли на каком - либо этаже задолжники отсутствуют, 
            //то дл€ этого этажа вывести задолженность, равную 0.00.

            Task("LinqObj32");

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Concat(Enumerable.Range(1, 9)
                .Select(i => String.Format("{0} {1} {2}", "", i * 4, 0)))
                .Select(x => new
                {
                    debt = double.Parse(x.Split(' ')[2], CultureInfo.InvariantCulture),
                    floor = (int.Parse(x.Split(' ')[1]) - 1) % 36 / 4 + 1
                })
                .GroupBy(x => x.floor)
                .OrderBy(x => x.Key)
                .SelectMany(x => x.OrderBy(y => y.debt).Take(2).OrderByDescending(y => y.debt).Take(1))
                .Select(x => $"{x.floor} {x.debt.ToString("0.00", CultureInfo.InvariantCulture)}");

            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
