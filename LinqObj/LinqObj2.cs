using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        // ƒл€ чтени€ набора строк из исходного текстового файла
        // в массив a типа string[] используйте оператор:
        //
        //   a = File.ReadAllLines(GetString(), Encoding.Default);
        //
        // ƒл€ записи последовательности s типа IEnumerable<string>
        // в результирующий текстовый файл используйте оператор:
        //
        //   File.WriteAllLines(GetString(), s.ToArray(), Encoding.Default);
        //
        // ѕри решении задач группы LinqObj доступны следующие
        // дополнительные методы расширени€, определенные в задачнике:
        //
        //   Show() и Show(cmt) - отладочна€ печать последовательности,
        //     cmt - строковый комментарий;
        //
        //   Show(e => r) и Show(cmt, e => r) - отладочна€ печать
        //     значений r, полученных из элементов e последовательности,
        //     cmt - строковый комментарий.

        public static void Solve()
        {
            //LinqObj2∞. »сходна€ последовательность содержит сведени€ о клиентах фитнес - центра.
			// аждый элемент последовательности включает следующие целочисленные пол€:
            //< Ќомер мес€ца > < √од > <  од клиента > < ѕродолжительность зан€тий(в часах) >
            //Ќайти элемент последовательности с максимальной продолжительностью зан€тий. 
			//¬ывести эту продолжительность, а также соответствующие ей год и номер мес€ца(в указанном пор€дке на той же строке). 
			//≈сли имеетс€ несколько элементов с максимальной продолжительностью, то вывести данные, соответствующие самой поздней дате.

            Task("LinqObj2");
            var a = new[]
            {
                File.ReadAllLines(GetString(), Encoding.Default)
                                                                .OrderBy(e => int.Parse(e.Split(' ')[3]))
																.ThenBy(y => y.Split(' ')[1])
																.ThenBy(m => m.Split(' ')[0])
																.Last() }
            .Select(e => e.Split(' ')[3]+' '+e.Split(' ')[1]+' '+e.Split(' ')[0]);
            File.WriteAllLines(GetString(), a, Encoding.Default);

        }
    }
}
