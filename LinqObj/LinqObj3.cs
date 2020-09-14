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
			//LinqObj3°. Исходная последовательность содержит сведения о клиентах фитнес - центра.
            //Каждый элемент последовательности включает следующие целочисленные поля:
            //< Год > < Номер месяца > < Продолжительность занятий(в часах) > < Код клиента >
            //Определить год, в котором суммарная продолжительность занятий всех клиентов была наибольшей, и вывести этот год и наибольшую суммарную продолжительность. 
            //Если таких годов было несколько, то вывести наименьший из них.
            Task("LinqObj3");
            var d = File.ReadAllLines(GetString(), Encoding.Default)
                    .Select(s => new[] {
                                  int.Parse(s.Split(' ')[0]),
                                  int.Parse(s.Split(' ')[2])})
                                                              .GroupBy(x => x[0])
                                                              .Select(x => new { year = x.Key, item = x.Sum(y => y[1]) })
                                                              .OrderByDescending(y => y.item)
                                                              .ThenBy(y => y.year)
                                                              .Select(e => new[] { e.year.ToString() + ' ' + e.item.ToString() })
                                                              .First();
            File.WriteAllLines(GetString(), d, Encoding.Default);
        }
    }
}
