// File: "LinqObj27"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            //LinqObj27∞. »сходна€ последовательность содержит сведени€ о задолжниках по оплате коммунальных услуг, 
            //живущих в 144 - квартирном 9 - этажном доме. аждый элемент последовательности включает следующие пол€:

            //    < ‘амили€ > 
            //    < Ќомер квартиры > 
            //    < «адолженность >

            //«адолженность указываетс€ в виде дробного числа(цела€ часть Ч рубли, дробна€ часть Ч копейки).
            //¬ каждом подъезде на каждом этаже располагаютс€ по 4 квартиры.ƒл€ каждого из 9 этажей дома вывести 
            //сведени€ о задолжниках, живущих на этом этаже: число задолжников, номер этажа, суммарна€ задолженность 
            //дл€ жильцов этого этажа(выводитс€ с двум€ дробными знаками). —ведени€ о каждом этаже выводить на отдельной 
            //строке и упор€дочивать по возрастанию числа задолжников, а дл€ совпадающих чисел Ч по возрастанию этажа.
            //≈сли на каком - либо этаже задолжники отсутствуют, то данные об этом этаже не выводить.

            Task("LinqObj27");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => new
                {
                    debt = double.Parse(x.Split(' ')[2], CultureInfo.InvariantCulture),
                    floor = (int.Parse(x.Split(' ')[1]) - 1) % 36 / 4 + 1
                })
                .Where(d => d.debt != 0)
                .GroupBy(x => x.floor)
                .OrderBy(x => x.Count())
                .ThenBy(x => x.Key)
                .Select(x => x.Count().ToString() + ' ' 
                + x.Key.ToString() + ' ' 
                + x.Sum(d => d.debt).ToString("0.00", CultureInfo.InvariantCulture));

           File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
