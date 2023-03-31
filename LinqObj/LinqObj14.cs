// File: "LinqObj14"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            //LinqObj14°. Исходная последовательность содержит сведения об абитуриентах. Каждый элемент последовательности 
            //включает следующие поля:

            //    < Год поступления > 
            //    < Номер школы > 
            //    < Фамилия >

            //Определить, в какие годы общее число абитуриентов для всех школ было наибольшим, и вывести это число, 
            //а также количество таких лет. Каждое число выводить на новой строке. 

            Task("LinqObj14");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .GroupBy(x => int.Parse(x.Split(' ')[0]),
                        (x, y) => new { year = x, count = y.Count() })
                .GroupBy(x => x.count)
                .OrderByDescending(g => g.Key)
                .Select(y => new[] { 
                    y.Key.ToString(), 
                    y.Count().ToString() })
                .First();

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
