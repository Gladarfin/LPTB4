// File: "LinqObj19"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("LinqObj19");
            //LinqObj19∞. »сходна€ последовательность содержит сведени€ об абитуриентах.  аждый элемент последовательности 
            //включает следующие пол€:

            //    < ‘амили€ > 
            //    < √од поступлени€ > 
            //    < Ќомер школы >

            //ƒл€ каждой школы вывести общее число абитуриентов за все годы и фамилию первого из абитуриентов этой школы, 
            //содержащихс€ в исходном наборе данных(вначале указывать номер школы, затем число абитуриентов, затем фамилию). 
            //—ведени€ о каждой школе выводить на новой строке и упор€дочивать по возрастанию номеров школ. 

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .GroupBy(x => x.Split(' ')[2],
                         (x, y) => x + ' ' + y.Count() + ' ' + y.First().Split(' ')[0])
                .OrderBy(x => int.Parse(x.Split(' ')[0]));

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
