// File: "LinqObj52"
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
            //LinqObj52°. Исходная последовательность содержит сведения о результатах сдачи учащимися ЕГЭ по математике,
            //русскому языку и информатике (в указанном порядке). Каждый элемент последовательности включает следующие поля:

                //< Номер школы >
                //< Фамилия >
                //< Инициалы >
                //< Баллы ЕГЭ >

            //Баллы ЕГЭ представляют собой три целых числа в диапазоне от 0 до 100, которые отделяются друг от друга одним пробелом.
            //Для каждой школы вывести сведения об учащемся, набравшем наименьший суммарный балл ЕГЭ среди учащихся этой школы.
            //Если таких учащихся несколько, то вывести сведения о первом учащемся в алфавитном порядке их фамилий и инициалов.
            //Сведения о каждом учащемся выводить на отдельной строке, указывая номер школы, суммарный балл ЕГЭ, фамилию учащегося
            //и его инициалы. Данные упорядочивать по убыванию номера школы. 

            Task("LinqObj52");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[0]),
                        (x, y) => new
                        {
                            school = x,
                            studentWithMin = y.Select(d => new {
                                                                grade = int.Parse(d[3]) + int.Parse(d[4]) + int.Parse(d[5]),
                                                                fullName = d[1] + ' ' + d[2] 
                                                               })
                                              .OrderBy(g => g.grade)
                                              .ThenBy(fn => fn.fullName).First()
                        })
                .OrderByDescending(x => x.school)
                .Select(x => $"{x.school} {x.studentWithMin.grade} {x.studentWithMin.fullName}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
