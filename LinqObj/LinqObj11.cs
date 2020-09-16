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
            //LinqObj11°. Исходная последовательность содержит сведения о клиентах фитнес - центра.
            //Каждый элемент последовательности включает следующие целочисленные поля:
            //< Код клиента > < Год > < Номер месяца > < Продолжительность занятий(в часах) >
            //Для каждой пары «год–месяц», присутствующей в исходных данных, определить общую продолжительность занятий всех клиентов 
            //в указанное время(вначале выводится общая продолжительность, затем год, затем месяц). 
            //Сведения о каждой паре «год–месяц» выводить на новой строке и упорядочивать по возрастанию общей продолжительности занятий, 
            //для одинаковой продолжительности — по убыванию номера года, а для одинакового номера года — по возрастанию номера месяца.
            Task("LinqObj11");
            var d = File.ReadAllLines(GetString(), Encoding.Default)
                        .GroupBy(x => new { year = x.Split(' ')[1], month = x.Split(' ')[2] },
                                 y => y.Split(' ')[3],
                                 (x,y) => y.Select(j => int.Parse(j)).Sum().ToString() + ' '+ x.year+ ' ' +x.month )
                        .OrderBy(x => int.Parse(x.Split(' ')[0]))
                        .ThenByDescending(x => int.Parse(x.Split(' ')[1]))
                        .ThenBy(x => int.Parse(x.Split(' ')[2]));
            File.WriteAllLines(GetString(), d, Encoding.Default);
        }
    }
}
