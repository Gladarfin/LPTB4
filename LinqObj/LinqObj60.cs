// File: "LinqObj60"
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
            //LinqObj60°. Исходная последовательность содержит сведения о результатах сдачи учащимися ЕГЭ по математике,
            //русскому языку и информатике (в указанном порядке). Каждый элемент последовательности включает следующие поля:

                //< Фамилия >
                //< Инициалы >
                //< Баллы ЕГЭ >
                //< Номер школы >

            //Баллы ЕГЭ представляют собой три целых числа в диапазоне от 0 до 100, которые отделяются друг от друга одним пробелом.
            //Для каждой школы и каждого предмета найти среднее значение балла ЕГЭ, набранного учащимися этой школы(среднее значение
            //является целым числом — результатом деления нацело суммы баллов всех учащихся на количество учащихся). Сведения о каждой
            //школе выводить на отдельной строке, указывая номер школы и средние баллы по математике, русскому языку и информатике.
            //Данные упорядочивать по убыванию номера школы. 
            Task("LinqObj60");
            Task("LinqObj59");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[5]),
                        (x, y) => new {
                            school = x,
                            math = Math.Truncate(y.Select(m => int.Parse(m[2])).Average()),
                            rus = Math.Truncate(y.Select(ru => int.Parse(ru[3])).Average()),
                            inf = Math.Truncate(y.Select(i => int.Parse(i[4])).Average())
                        })
                .OrderByDescending(x => x.school)
                .Select(x => $"{x.school} {x.math} {x.rus} {x.inf}");

            File.WriteAllLines(GetString(), r, Encoding.Default);

        }
    }
}
