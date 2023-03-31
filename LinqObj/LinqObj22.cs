// File: "LinqObj22"
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
            Task("LinqObj22");
            //»сходна€ последовательность содержит сведени€ об абитуриентах.  аждый элемент последовательности включает следующие пол€:

            //    < ‘амили€ > 
            //    < Ќомер школы > 
            //    < √од поступлени€ >

            //ƒл€ каждой школы найти годы поступлени€ абитуриентов из этой школы и вывести номер школы и найденные дл€ нее годы
            //(годы располагаютс€ на той же строке, что и номер школы, и упор€дочиваютс€ по возрастанию). —ведени€ о каждой школе 
            //выводить на новой строке и упор€дочивать по возрастанию номеров школ. 

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .OrderBy(x => int.Parse(x.Split(' ')[2]))
                .GroupBy(x => x.Split(' ')[1])
                .OrderBy(x => int.Parse(x.Key))
                .Select(x => x.Key + ' ' + string.Join(" ", x.Select(y => y.Split(' ')[2]).Distinct()));

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
