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
            //LinqObj4°. Исходная последовательность содержит сведения о клиентах фитнес - центра.Каждый элемент последовательности включает следующие целочисленные поля:
            //< Год > < Номер месяца > < Продолжительность занятий(в часах) > < Код клиента >
            //Для каждого клиента, присутствующего в исходных данных, определить суммарную продолжительность занятий в течение всех лет(вначале выводить суммарную продолжительность, затем код клиента). Сведения о каждом клиенте выводить на новой строке и упорядочивать по убыванию суммарной продолжительности, а при их равенстве — по возрастанию кода клиента.
            Task("LinqObj4");
            var c = File.ReadAllLines(GetString(), Encoding.Default)
                    .Select(s => new[] { int.Parse(s.Split(' ')[2]),
                                         int.Parse(s.Split(' ')[3])})
                                                                     .GroupBy(code => code[1])
                                                                     .Select(x => new { duration = x.Sum(y => y[0]), code = x.Key })
                                                                     .OrderByDescending(x => x.duration)
                                                                     .ThenBy(x => x.code)
                                                                     .Select(e => e.duration.ToString() + ' ' + e.code.ToString());            
            File.WriteAllLines(GetString(), c, Encoding.Default);
        }
    }
}
