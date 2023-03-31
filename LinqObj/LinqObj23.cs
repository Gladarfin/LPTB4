// File: "LinqObj23"
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
            Task("LinqObj23");
            //LinqObj23°. Исходная последовательность содержит сведения об абитуриентах. 
            //Каждый элемент последовательности включает следующие поля:

            //    < Фамилия > 
            //    < Год поступления > 
            //    < Номер школы >

            //Для каждой пары «год–школа», присутствующей в исходных данных, найти число абитуриентов, 
            //относящихся к этому году и школе, и вывести год, номер школы и найденное число абитуриентов. 
            //Сведения о каждой паре «год–школа» выводить на новой строке и упорядочивать по убыванию года,
            //а для совпадающих годов — по возрастанию номера школы. 

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .GroupBy(x => new { year = x.Split(' ')[1], school = x.Split(' ')[2]})
                .OrderByDescending(x => int.Parse(x.Key.year))
                .ThenBy(x => int.Parse(x.Key.school))
                .Select(x => x.Key.year + ' ' + x.Key.school + ' '+ x.Count());

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
