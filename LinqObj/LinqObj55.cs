// File: "LinqObj55"
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
            //LinqObj55°. Исходная последовательность содержит сведения о результатах сдачи учащимися ЕГЭ по математике,
            //русскому языку и информатике(в указанном порядке). Каждый элемент последовательности включает следующие поля:

                //< Баллы ЕГЭ >
                //< Фамилия >
                //< Инициалы >
                //< Номер школы >

            //Баллы ЕГЭ представляют собой три целых числа в диапазоне от 0 до 100, которые отделяются друг от друга одним пробелом.
            //Вывести сведения об учащихся, набравших не менее 50 баллов по каждому предмету(вначале выводится фамилия и инициалы,
            //затем номер школы и суммарный балл ЕГЭ по всем предметам). Сведения о каждом учащемся выводить на отдельной строке в
            //алфавитном порядке фамилий и инициалов, а при их совпадении — в порядке следования учащихся в наборе исходных данных.
            //Если ни один из учащихся не удовлетворяет указанным условиям, то записать в результирующий файл текст «Students not found». 

            Task("LinqObj55");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .Select(x => new
                {
                    student = x[3] + ' ' + x[4],
                    math = int.Parse(x[0]),
                    rus = int.Parse(x[1]),
                    inf = int.Parse(x[2]),
                    school = x[5]
                })
                .Where(y => y.math >= 50 && y.rus >= 50 && y.inf >= 50)
                .OrderBy(x => x.student)
                .Select(x => $"{x.student} {x.school} {x.math + x.rus + x.inf}")
                .DefaultIfEmpty("Students not found");
            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
