// File: "LinqObj16"
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
            Task("LinqObj16");
            //LinqObj16∞. »сходна€ последовательность содержит сведени€ об абитуриентах. 
            // аждый элемент последовательности включает следующие пол€:

            //    < √од поступлени€ > 
            //    < Ќомер школы > 
            //    < ‘амили€ >

            //ƒл€ каждого года, присутствующего в исходных данных, вывести общее число абитуриентов, 
            //поступивших в этом году(вначале указывать число абитуриентов, затем год).—ведени€ о каждом годе 
            //выводить на новой строке и упор€дочивать по убыванию числа поступивших, а дл€ совпадающих чисел Ч 
            //по возрастанию номера года. 
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .GroupBy(x => x.Split(' ')[0],
                        (x, y) => y.Count().ToString() + ' ' + x)
                .OrderByDescending(x => int.Parse(x.Split(' ')[0]))
                .ThenBy(y => int.Parse(y.Split(' ')[1]));

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
