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
        // Для чтения набора строк из исходного текстового файла
        // в массив a типа string[] используйте оператор:
        //
        //   a = File.ReadAllLines(GetString(), Encoding.Default);
        //
        // Для записи последовательности s типа IEnumerable<string>
        // в результирующий текстовый файл используйте оператор:
        //
        //   File.WriteAllLines(GetString(), s.ToArray(), Encoding.Default);
        //
        // При решении задач группы LinqObj доступны следующие
        // дополнительные методы расширения, определенные в задачнике:
        //
        //   Show() и Show(cmt) - отладочная печать последовательности,
        //     cmt - строковый комментарий;
        //
        //   Show(e => r) и Show(cmt, e => r) - отладочная печать
        //     значений r, полученных из элементов e последовательности,
        //     cmt - строковый комментарий.

        public static void Solve()
        {
            //LinqObj10°. Исходная последовательность содержит сведения о клиентах фитнес - центра.
            //Каждый элемент последовательности включает следующие целочисленные поля:
            //< Год > < Номер месяца > < Код клиента > < Продолжительность занятий(в часах) >
            // Для каждой пары «год–месяц», присутствующей в исходных данных, определить количество клиентов, 
            //которые посещали центр в указанное время(вначале выводится год, затем месяц, затем количество клиентов).
            //Сведения о каждой паре «год–месяц» выводить на новой строке и упорядочивать по убыванию номера года, 
            //а для одинакового номера года — по возрастанию номера месяца.

            Task("LinqObj10");
            var d = File.ReadAllLines(GetString(), Encoding.Default)
                    .GroupBy(x => new { year = x.Split(' ')[0], month = x.Split(' ')[1]},
                             y => y,
                             (x,y) => x.year + ' '+x.month + ' ' + y.Count().ToString()) 
                    .OrderByDescending(x => int.Parse(x.Split(' ')[0]))
                    .ThenBy(x => int.Parse(x.Split(' ')[1]));
            File.WriteAllLines(GetString(), d, Encoding.Default);
        }
    }
}
