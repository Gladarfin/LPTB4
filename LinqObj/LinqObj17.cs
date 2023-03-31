// File: "LinqObj17"
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
            Task("LinqObj17");
            //LinqObj17∞. »сходна€ последовательность содержит сведени€ об абитуриентах.  аждый элемент последовательности 
            //включает следующие пол€:

            //    < Ќомер школы > 
            //    < √од поступлени€ > 
            //    < ‘амили€ >

            //ƒл€ каждого года, присутствующего в исходных данных, вывести число различных школ, которые окончили абитуриенты, 
            //поступившие в этом году(вначале указывать число школ, затем год).—ведени€ о каждом годе выводить на новой строке 
            //и упор€дочивать по возрастанию числа школ, а дл€ совпадающих чисел Ч по возрастанию номера года. 

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .GroupBy(x => x.Split(' ')[1],
                         (x, y) => y.Select(sn => sn.Split(' ')[0])
                                                    .Distinct()
                                                    .Count()
                                                    .ToString() + ' ' + x)
                .OrderBy(x => int.Parse(x.Split(' ')[0]))
                .ThenBy(y => int.Parse(y.Split(' ')[1]));

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
