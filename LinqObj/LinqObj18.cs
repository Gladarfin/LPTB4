// File: "LinqObj18"
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
            Task("LinqObj18");

            //LinqObj18∞. »сходна€ последовательность содержит сведени€ об абитуриентах.  аждый элемент последовательности 
            //включает следующие пол€:

            //    < √од поступлени€ > 
            //    < Ќомер школы > 
            //    < ‘амили€ >

            //Ќайти годы, дл€ которых число абитуриентов было не меньше среднего значени€ по всем годам(вначале указывать число 
            //абитуриентов дл€ данного года, затем год). —ведени€ о каждом годе выводить на новой строке и упор€дочивать 
            //по убыванию числа абитуриентов, а дл€ совпадающих чисел Ч по возрастанию номера года. 

            var f = File
                .ReadAllLines(GetString(), Encoding.Default)
                .GroupBy(x => x.Split(' ')[0])
                .Select(x => new { year = x.Key, stud = x.Count() })
                .OrderByDescending(y => y.stud)
                .ThenBy(x => x.year);
            var avg = f.Average(x => x.stud);
            var r = f.Where(x => x.stud >= avg)
                .Select(x => x.stud.ToString() + ' ' + x.year);
               
            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
