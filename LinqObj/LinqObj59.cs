// File: "LinqObj59"
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
            //LinqObj59∞. »сходна€ последовательность содержит сведени€ о результатах сдачи учащимис€ ≈√Ё по математике, русскому €зыку и информатике(в указанном пор€дке).  аждый элемент последовательности включает следующие пол€:

            //< Ќомер школы >
            //< Ѕаллы ≈√Ё >
            //< ‘амили€ >
            //< »нициалы >

            //Ѕаллы ≈√Ё представл€ют собой три целых числа в диапазоне от 0 до 100, которые отдел€ютс€ друг от друга одним пробелом.
            //ƒл€ каждой школы и каждого предмета определить количество учащихс€, набравших не менее 50 баллов по этому предмету
            //(вначале выводитс€ номер школы, затем три числа Ч количество учащихс€ этой школы, набравших требуемое число баллов
            //по математике, русскому €зыку и информатике; некоторые из чисел могут быть равны 0). —ведени€ о каждой школе выводить
            //на новой строке и упор€дочивать по возрастанию номера школы. 
            Task("LinqObj59");
            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .Select(x => x.Split(' '))
                .GroupBy(x => int.Parse(x[0]),
                        (x, y) => new {school = x, 
                                       math = y.Select(m => int.Parse(m[1])).Count(mm => mm >= 50),
                                       rus = y.Select(ru => int.Parse(ru[2])).Count(rr => rr >= 50),
                                       inf = y.Select(i => int.Parse(i[3])).Count(ii => ii >= 50)
                        })
                .OrderBy(x => x.school)
                .Select(x => $"{x.school} {x.math} {x.rus} {x.inf}");

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
