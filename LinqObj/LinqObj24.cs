// File: "LinqObj24"
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
            Task("LinqObj24");
            //LinqObj24°. Исходная последовательность содержит сведения об абитуриентах. 
            //Каждый элемент последовательности включает следующие поля:

            //    < Фамилия > 
            //    < Номер школы > 
            //    < Год поступления >

            //Для каждой пары «школа–год», присутствующей в исходных данных, найти трех первых абитуриентов, 
            //относящихся к этой школе и году, и вывести номер школы, год и найденные фамилии(в порядке их следования
            //в исходном наборе данных). Если для некоторой пары «школа–год» имеется менее трех абитуриентов, то вывести
            //информацию обо всех абитуриентах, относящихся к этой паре. Сведения о каждой паре «школа–год» выводить на 
            //новой строке и упорядочивать по возрастанию номера школы, а для совпадающих номеров — по убыванию года.

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .GroupBy(x => new { school = x.Split(' ')[1], year = x.Split(' ')[2] })
                .OrderBy(x => int.Parse(x.Key.school))
                .ThenByDescending(x => int.Parse(x.Key.year))
                .Select(x => x.Key.school + ' ' + x.Key.year + ' ' + string.Join(" ", x.Select(y => y.Split(' ')[0]).Take(3)));

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
