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
            //LinqObj5°. Исходная последовательность содержит сведения о клиентах фитнес - центра.Каждый элемент последовательности включает следующие целочисленные поля:
            //< Код клиента > < Продолжительность занятий(в часах) > < Год > < Номер месяца >
            //Для каждого клиента, присутствующего в исходных данных, определить общее количество месяцев, в течение которых он посещал занятия(вначале выводить количество месяцев, затем код клиента).Сведения о каждом клиенте выводить на новой строке и упорядочивать по возрастанию количества месяцев, а при их равенстве — по возрастанию кода клиента.
            Task("LinqObj5");
            var c = File.ReadAllLines(GetString(), Encoding.Default)
                    .Select(s => new[] { int.Parse(s.Split(' ')[3]),
                                         int.Parse(s.Split(' ')[0])})
                                                                     .GroupBy(code => code[1])
                                                                     .Select(x => new { monthCount = x.Select(y => y[0]).Count() ,
                                                                                        code = x.Key})
                                                                     .OrderBy(x => x.monthCount)
                                                                     .ThenBy(x => x.code)
                                                                     .Select(e => e.monthCount.ToString()+ ' ' + e.code.ToString());
            File.WriteAllLines(GetString(), c, Encoding.Default);
        }
    }
}
