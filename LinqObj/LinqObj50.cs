// File: "LinqObj50"
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

            //LinqObj50°. Исходная последовательность содержит сведения о результатах сдачи учащимися ЕГЭ по математике,
            //русскому языку и информатике (в указанном порядке). Каждый элемент последовательности включает следующие поля:

            //      < Фамилия >
            //      < Инициалы >
            //      < Баллы ЕГЭ >
            //      < Номер школы >

            //Баллы ЕГЭ представляют собой три целых числа в диапазоне от 0 до 100, которые отделяются друг от друга одним пробелом.
            //Определить два наибольших суммарных балла и вывести эти баллы на одной строке в порядке убывания(считать, что в исходных
            //данных всегда присутствуют учащиеся с различными суммарными баллами).Также вывести сведения обо всех учащихся,
            //получивших один из двух наибольших суммарных баллов(для каждого учащегося указывать фамилию, инициалы и суммарный балл).
            //Сведения о каждом учащемся выводить на отдельной строке и располагать в порядке их следования в исходном наборе. 
            
            Task("LinqObj50");
            var f = File.ReadAllLines(GetString(), Encoding.Default).Select(x => x.Split(' '));
            var max = f.Select(y => int.Parse(y[2]) + int.Parse(y[3]) + int.Parse(y[4]))
                .Distinct()
                .OrderByDescending(x => x)
                .Take(2)
                .ToArray();
            var r = f
                .GroupBy(x => new { fullName = x[0] + ' ' + x[1] },
                         (x, y) => new {
                             fullname = x.fullName,
                             sum = y.Select(yy => int.Parse(yy[2]) + int.Parse(yy[3]) + int.Parse(yy[4])).First()
                         })
                .Where(x => x.sum == max[0] || x.sum == max[1])
                .Select(x => $"{x.fullname} {x.sum}");

            var result = r.Select(x => x).Prepend($"{max[0]} {max[1]}");
            File.WriteAllLines(GetString(), result, Encoding.Default);
        }
    }
}
