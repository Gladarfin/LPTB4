// File: "LinqObj53"
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
            //LinqObj53∞. »сходна€ последовательность содержит сведени€ о результатах сдачи учащимис€ ≈√Ё по математике,
            //русскому €зыку и информатике (в указанном пор€дке).  аждый элемент последовательности включает следующие пол€:

                //< ‘амили€ >
                //< »нициалы >
                //< Ќомер школы >
                //< Ѕаллы ≈√Ё >

            //Ѕаллы ≈√Ё представл€ют собой три целых числа в диапазоне от 0 до 100, которые отдел€ютс€ друг от друга одним пробелом.
            //ƒл€ каждой школы определить количество учащихс€, суммарный балл которых превышает 150 баллов(вначале выводитс€ количество
            //учащихс€, набравших в сумме более 150 баллов, затем номер школы; количество учащихс€ может быть равно 0). —ведени€
            //о каждой школе выводить на новой строке и упор€дочивать по убыванию количества учащихс€, а дл€ одинакового количества
            //Ч по возрастанию номера школы. 

            Task("LinqObj53");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[2]),
                        (x, y) => new
                        {
                            school = x,
                            studentsCount = y.Select(f => int.Parse(f[3]) + int.Parse(f[4]) + int.Parse(f[5]))
                                                                   .Count(s => s > 150)
                        }
                        )
                .OrderByDescending(x => x.studentsCount)
                .ThenBy(x => x.school)
                .Select(x => $"{x.studentsCount} {x.school}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
