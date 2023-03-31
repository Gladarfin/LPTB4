// File: "LinqObj57"
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
            //LinqObj57°. Исходная последовательность содержит сведения о результатах сдачи учащимися ЕГЭ по математике,
            //русскому языку и информатике (в указанном порядке). Каждый элемент последовательности включает следующие поля:

                //< Номер школы >
                //< Фамилия >
                //< Инициалы >
                //< Баллы ЕГЭ >

            //Баллы ЕГЭ представляют собой три целых числа в диапазоне от 0 до 100, которые отделяются друг от друга одним пробелом.
            //Для каждой школы вывести фамилии и инициалы трех первых учащихся(в алфавитном порядке), набравших менее 50 баллов по
            //каждому предмету(вначале выводится номер школы, затем фамилия и инициалы). Сведения о каждом учащемся выводить на
            //отдельной строке и упорядочивать по возрастанию номера школы, а для совпадающих номеров — в алфавитном порядке фамилий
            //и инициалов. Если для некоторой школы имеется менее трех учащихся, удовлетворяющих указанным условиям, то вывести
            //сведения обо всех таких учащихся. Если в исходном наборе нет ни одного учащегося, удовлетворяющего указанным условиям,
            //то записать в результирующий файл текст «Students not found». 

            Task("LinqObj57");

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[0]),
                        (x,y) => new { students = y.Select(g => new {
                            school = x,
                            fullname = g[1] + ' ' + g[2],
                            math = int.Parse(g[3]),
                            rus = int.Parse(g[4]),
                            inf = int.Parse(g[5])
                        }).Where(s => s.math < 50 && s.rus < 50 && s.inf < 50)
                          .OrderBy(f => f.fullname)
                          .Take(3)
                        })
                .SelectMany(x => x.students)
                .OrderBy(x => x.school)
                .Select(x => $"{x.school} {x.fullname}")
                .DefaultIfEmpty("Students not found");
            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
