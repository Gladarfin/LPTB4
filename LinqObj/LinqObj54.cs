// File: "LinqObj54"
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
            //LinqObj54∞. »сходна€ последовательность содержит сведени€ о результатах сдачи учащимис€ ≈√Ё по математике,
            //русскому €зыку и информатике(в указанном пор€дке).  аждый элемент последовательности включает следующие пол€:
    
                //< Ѕаллы ≈√Ё >
                //< Ќомер школы >
                //< ‘амили€ >
                //< »нициалы >

            //Ѕаллы ≈√Ё представл€ют собой три целых числа в диапазоне от 0 до 100, которые отдел€ютс€ друг от друга одним пробелом.
            //ƒл€ каждой школы найти среднее значение суммарного балла ≈√Ё, набранного учащимис€ этой школы(среднее значение €вл€етс€
            //целым числом Ч результатом делени€ нацело суммы баллов всех учащихс€ на количество учащихс€). —ведени€ о каждой школе
            //выводить на отдельной строке, указыва€ средний суммарный балл ≈√Ё и номер школы.ƒанные упор€дочивать по убыванию
            //среднего балла, а при равных значени€х среднего балла Ч по возрастанию номера школы. 

            Task("LinqObj54");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[3]),
                        (x, y) => new
                        {
                            school = x,
                            avgGrade = y.Select(g => int.Parse(g[0]) + int.Parse(g[1]) + int.Parse(g[2])).Sum() / y.Count()
                        })
                .OrderByDescending(x => x.avgGrade)
                .ThenBy(x => x.school)
                .Select(x => $"{x.avgGrade} {x.school}");                


            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
