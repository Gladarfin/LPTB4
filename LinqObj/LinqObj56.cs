// File: "LinqObj56"
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

            //LinqObj56°. Исходная последовательность содержит сведения о результатах сдачи учащимися ЕГЭ по математике,
            //русскому языку и информатике (в указанном порядке). Каждый элемент последовательности включает следующие поля:

            //< Фамилия >
            //< Инициалы >
            //< Баллы ЕГЭ >
            //< Номер школы >

            //Баллы ЕГЭ представляют собой три целых числа в диапазоне от 0 до 100, которые отделяются друг от друга одним пробелом.
            //Вывести сведения об учащихся, набравших более 90 баллов хотя бы по одному из предметов(вначале выводится фамилия и
            //инициалы, затем номер школы).Сведения о каждом учащемся выводить на отдельной строке и располагать в алфавитном порядке
            //фамилий и инициалов, а при их совпадении — по возрастанию номера школы. Если ни один из учащихся не удовлетворяет
            //указанным условиям, то записать в результирующий файл текст «Students not found». 

            Task("LinqObj56");

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .Select(x => new
                {
                    student = x[0] + ' ' + x[1],
                    math = int.Parse(x[2]),
                    rus = int.Parse(x[3]),
                    inf = int.Parse(x[4]),
                    school = x[5]
                })
                .Where(y => y.math > 90 || y.rus > 90 || y.inf > 90)
                .OrderBy(x => x.student)
                .ThenBy(x => x.school)
                .Select(x => $"{x.student} {x.school}")
                .DefaultIfEmpty("Students not found");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
