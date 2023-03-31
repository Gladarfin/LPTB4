// File: "LinqObj51"
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
            //LinqObj51°. Исходная последовательность содержит сведения о результатах сдачи учащимися ЕГЭ по математике,
            //русскому языку и информатике (в указанном порядке). Каждый элемент последовательности включает следующие поля:

            //  < Баллы ЕГЭ >
            //  < Фамилия >
            //  < Инициалы >
            //  < Номер школы >

            //Баллы ЕГЭ представляют собой три целых числа в диапазоне от 0 до 100, которые отделяются друг от друга одним пробелом.
            //Для каждой школы вывести сведения об учащемся, набравшем наибольший балл ЕГЭ по информатике среди учащихся этой школы.
            //Если таких учащихся несколько, то вывести сведения о первом учащемся в порядке их следования в исходном наборе.
            //Сведения о каждом учащемся выводить на отдельной строке, указывая номер школы, фамилию учащегося, его инициалы и балл ЕГЭ
            //по информатике.Данные упорядочивать по возрастанию номера школы. 


            Task("LinqObj51");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[5]),
                        (x,y) => new { school = x, bestStudent = y.OrderByDescending(s => int.Parse(s[2])).First() })
                .OrderBy(x => x.school)
                .Select(x => $"{x.school} {x.bestStudent[3]} {x.bestStudent[4]} {x.bestStudent[2]}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
