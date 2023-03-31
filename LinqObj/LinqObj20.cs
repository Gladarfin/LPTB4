// File: "LinqObj20"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("LinqObj20");
            //LinqObj20°. Исходная последовательность содержит сведения об абитуриентах. 
            //Каждый элемент последовательности включает следующие поля:

            //    < Фамилия > 
            //    < Номер школы > 
            //    < Год поступления >

            //Определить, для каких школ общее число абитуриентов за все годы было наибольшим, и вывести данные об абитуриентах из 
            //этих школ(вначале указывать номер школы, затем фамилию абитуриента). Сведения о каждом абитуриенте выводить на новой 
            //строке и упорядочивать по возрастанию номеров школ, а для одинаковых номеров — в порядке следования абитуриентов в 
            //исходном наборе данных. 

            var r = File.ReadAllLines(GetString(), Encoding.Default)
                .GroupBy(x => x.Split(' ')[1])
                .Select(x => new {
                    school = x.Key, 
                    count = x.Count(), 
                    students = x.Select(y => y.Split(' ')[0]).ToArray()
                });
            var max = r.Max(x => x.count);
            var result = r.Where(x => x.count == max)
                .OrderBy(y => int.Parse(y.school))
                .SelectMany(x => x.students.Select(y => $"{x.school} {y}"))
                .ToArray();


            File.WriteAllLines(GetString(), result, Encoding.Default);
        }
    }
}
