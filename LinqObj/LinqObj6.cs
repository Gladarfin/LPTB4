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
            //LinqObj6°. Исходная последовательность содержит сведения о клиентах фитнес - центра.Каждый элемент последовательности включает следующие целочисленные поля:
            //< Код клиента > < Продолжительность занятий(в часах) > < Год > < Номер месяца >
            //Для каждого месяца определить суммарную продолжительность занятий всех клиентов за все годы(вначале выводить суммарную продолжительность, затем номер месяца).Если данные о некотором месяце отсутствуют, то для этого месяца вывести 0.Сведения о каждом месяце выводить на новой строке и упорядочивать по убыванию суммарной продолжительности, а при равной продолжительности — по возрастанию номера месяца.
            Task("LinqObj6");
            var k = File.ReadAllLines(GetString(), Encoding.Default).Concat(Enumerable.Range(1, 12)
                                                                                      .Select(i => String.Format("{0} {1} {2} {3}", 0, 0, 0, i))) //add all 12 month with 0 values, another option is to use dictionaries...
                                                                    .Select(s => new[] { int.Parse(s.Split(' ')[1]),
                                                                                         int.Parse(s.Split(' ')[3])})
                                                                    .GroupBy(month => month[1])
                                                                    .Select(x => new { month = x.Key , duration = x.Select(y => y[0]).Sum() })
                                                                    .OrderByDescending(x => x.duration)
                                                                    .ThenBy(x => x.month)
                                                                    .Select(e => e.duration.ToString() + ' ' + e.month.ToString());
            File.WriteAllLines(GetString(), k, Encoding.Default);
        }
    }
}
