// File: "LinqObj13"
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
            //LinqObj13∞. »сходна€ последовательность содержит сведени€ об абитуриентах.  аждый элемент последовательности 
            //включает следующие пол€:

            //    < Ќомер школы > 
            //    < √од поступлени€ > 
            //    < ‘амили€ >

            //ƒл€ каждого года, присутствующего в исходных данных, найти школу с наибольшим номером среди школ,
            //которые окончили абитуриенты, поступившие в этом году, и вывести год и найденный номер школы. 
            //—ведени€ о каждом годе выводить на новой строке и упор€дочивать по возрастанию номера года. 

            Task("LinqObj13");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .GroupBy(x => x.Split(' ')[1],
                         (x, y) => new {year = x, schoolNumber = y.Max(n => int.Parse(n.Split(' ')[0]))})
                .OrderBy(x => x.year)
                .Select(x => x.year + ' ' + x.schoolNumber.ToString());

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
