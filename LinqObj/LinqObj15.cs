// File: "LinqObj15"
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
            Task("LinqObj15");

            //LinqObj15∞. »сходна€ последовательность содержит сведени€ об абитуриентах.  аждый элемент последовательности 
            //включает следующие пол€:

            //    < Ќомер школы > 
            //    < √од поступлени€ > 
            //    < ‘амили€ >

            //ќпределить, в какие годы общее число абитуриентов дл€ всех школ было наибольшим, и вывести это число, 
            //а также годы, в которые оно было достигнуто(годы упор€дочивать по возрастанию, каждое число выводить 
            //на новой строке). 

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .GroupBy(x => int.Parse(x.Split(' ')[1]),
                        (x, y) => new { year = x, count = y.Count() })
                .GroupBy(y => y.count)
                .OrderByDescending(yc => yc.Key)
                .Select(x => new{x.Key, years = x.Select(xx => xx.year.ToString()).OrderBy(xy => xy)})
                .First();
            var result = r.years.Prepend(r.Key.ToString());
            File.WriteAllLines(GetString(), result, Encoding.Default);
        }
    }
}
