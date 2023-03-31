// File: "LinqObj28"
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
            // LinqObj28∞. »сходна€ последовательность содержит сведени€ о задолжниках по оплате коммунальных услуг, 
            // живущих в 144 - квартирном 9 - этажном доме. аждый элемент последовательности включает следующие пол€:
            // 
            //     < «адолженность > 
            //     < ‘амили€ > 
            //     < Ќомер квартиры >
            // 
            // «адолженность указываетс€ в виде дробного числа(цела€ часть Ч рубли, дробна€ часть Ч копейки).
            // ¬ каждом подъезде на каждом этаже располагаютс€ по 4 квартиры.ƒл€ каждого из 9 этажей дома вывести сведени€ о задолжниках, 
            // живущих на этом этаже: номер этажа, суммарна€ задолженность дл€ жильцов этого этажа(выводитс€ с двум€ дробными знаками), 
            // число задолжников. —ведени€ о каждом этаже выводить на отдельной строке и упор€дочивать по убыванию номера этажа. 
            // ≈сли на каком - либо этаже задолжники отсутствуют, то вывести дл€ этого этажа нулевые данные.
            Task("LinqObj28");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Concat(Enumerable.Range(1, 9)
                .Select(i => String.Format("{0} {1} {2}", 0, "", i * 4)))
                .Select(x => new
                {
                    debt = double.Parse(x.Split(' ')[0], CultureInfo.InvariantCulture),
                    floor = (int.Parse(x.Split(' ')[2]) - 1) % 36 / 4 + 1
                })
                .GroupBy(x => x.floor)
                .OrderByDescending(x => x.Key)   
                .Select(x => $"{x.Key} {x.Sum(y => y.debt).ToString("0.00", CultureInfo.InvariantCulture)} {x.Count(y => y.debt > 0).ToString()}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
