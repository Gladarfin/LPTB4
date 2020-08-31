using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Schema;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        // При решении задач группы LinqBegin доступны следующие
        // дополнительные методы, определенные в задачнике:
        //
        //   GetEnumerableInt() - ввод числовой последовательности;
        //
        //   GetEnumerableString() - ввод строковой последовательности;
        //
        //   Put() (метод расширения) - вывод последовательности;
        //
        //   Show() и Show(cmt) (методы расширения) - отладочная печать
        //     последовательности, cmt - строковый комментарий;
        //
        //   Show(e => r) и Show(cmt, e => r) (методы расширения) -
        //     отладочная печать значений r, полученных из элементов e
        //     последовательности, cmt - строковый комментарий.


        /// <summary>
        /// EN: Uncomment lines for required task
        /// RU: Убрать комментарии для запуска нужной задачи
        /// </summary>
        public static void Solve()
        {
            #region First group: LinqBegin1-LinqBegin15

            //Task("LinqBegin1");
            //var a = GetEnumerableInt();
            //Put(a.First(e => e>0));
            //Put(a.Last(e => e < 0));

            //Task("LinqBegin2");
            //int d = GetInt();
            //var a = GetEnumerableInt();
            //Put(a.FirstOrDefault(e => e > 0 && e.ToString().EndsWith(d.ToString())));

            //Task("LinqBegin3");
            //int l = GetInt();
            //var a = GetEnumerableString();
            //Put(a.LastOrDefault(s => s.Length!=0 && s[0] >= '0' && s[0] <= '9' && s.Length == l) ?? "Not found");

            //Task("LinqBegin4");
            //char c = GetChar();
            //var a = GetEnumerableString();
            //try
            //{
            //    Put(a.SingleOrDefault(s => s.Length != 0 && s[s.Length - 1] == c) ?? "");
            //}
            //catch
            //{
            //    Put("Error");
            //}

            //Task("LinqBegin5");
            //char c = GetChar();
            //var a = GetEnumerableString();
            //Put(a.Count(s => s.Length > 1 && s[0] == c && s[s.Length - 1] == c));

            //Task("LinqBegin6");
            //Put(GetEnumerableString().Sum(s => s.Length));

            //Task("LinqBegin7");
            //var i = GetEnumerableInt();
            //Put(i.Count(e => e < 0));
            //Put(i.Where(e => e< 0).Sum());

            //Task("LinqBegin8");
            //var i = GetEnumerableInt();
            //Put(i.Count(e => e > 0 && e.ToString().Length == 2));
            //Put(i.Where(e => e > 0 && e.ToString().Length == 2).DefaultIfEmpty(0).Average());

            //Task("LinqBegin9");
            //Put(GetEnumerableInt().Where(e => e > 0).DefaultIfEmpty(0).Min());

            //Task("LinqBegin10");
            //int l = GetInt();
            //var a = GetEnumerableString();
            //Put(a.Where(s => s.Length==l).DefaultIfEmpty("").Max());

            //Task("LinqBegin11");
            //Put(GetEnumerableString().Aggregate("", (str1,str2) => str1+str2[0]));

            //Task("LinqBegin12");
            //Put(GetEnumerableInt().Select(x => Math.Abs(x%10)).Aggregate(1.0, (a, b) => a*b));

            //Task("LinqBegin13");
            //int n = GetInt();
            //Put(Enumerable.Range(1,n).Sum(e => 1.0/e));

            //Task("LinqBegin14");
            //int a = GetInt();
            //int b = GetInt();
            //Put(Enumerable.Range(a, b - a + 1).Average(x => x * x));

            //Task("LinqBegin15");
            //int n = GetInt();
            //Put(Enumerable.Range(0, n).Aggregate(1.0, (num1, num2) => num1 + num1 * num2));
            #endregion

            #region Second group: LinqBegin16-LinqBegin31
            //RU: В большинстве заданий из этого блока
            //первое число должно быть КОЛИЧЕСТВОМ элементов выходной последовательности, 
            //хотя в заданиях об этом не сказано
            //EN: The first number (in the most tasks from this block) must be the Number of elements in output

            //Task("LinqBegin16");
            //var numbers = GetEnumerableInt().Where(e=>e>0);
            //Put(numbers.Count(), numbers.Select(e => e));

            //Task("LinqBegin17");
            //var numbers = GetEnumerableInt().Where(e => e % 2 == 1).Distinct();
            //Put(numbers.Count(), numbers);

            //Task("LinqBegin18");
            //var numbers = GetEnumerableInt().Where(e => e % 2 == 0 && e < 0).Reverse();
            //Put(numbers.Count(), numbers);

            //Task("LinqBegin19");
            //var d = GetInt();
            //var numbers = GetEnumerableInt().Where(e => e % 10 == d).Reverse().Distinct().Reverse();
            //Put(numbers.Count(), numbers);

            //Task("LinqBegin20");
            //var numbers = GetEnumerableInt().Where(e => e >= 10 && e <= 99).OrderBy(e => e);
            //Put(numbers.Count(), numbers);

            //Task("LinqBegin21");
            //var strings = GetEnumerableString().OrderBy(e => e.Length).ThenByDescending(e=>e);
            //Put(strings.Count(), strings);

            //Task("LinqBegin22");
            //int k = GetInt();
            //var a = GetEnumerableString().Where(e => e.Length == k && e[e.Length - 1] >= '0' && e[e.Length - 1] <= '9').OrderBy(s => s);
            //Put(a.Count(), a);

            //Task("LinqBegin23");
            //int k = GetInt();
            //var a = GetEnumerableInt().Skip(k - 1).Where(e => Math.Abs(e / 10) >= 1 && Math.Abs(e / 10) <= 9 && Math.Abs(e % 2) == 1).OrderByDescending(n=>n);
            //Put(a.Count(), a);

            //Task("LinqBegin24");
            //int k = GetInt();
            //var a = GetEnumerableString().Take(k-1).Where(e => e.Length % 2 == 1 && e[0]>='A' && e[0]<='Z').Reverse();
            //Put(a.Count(), a);

            //Task("LinqBegin25");
            //int k1 = GetInt();
            //int k2 = GetInt();
            //Put(GetEnumerableInt().Skip(k1-1).Take(k2-k1+1).Where(e => e > 0).Sum());

            //Task("LinqBegin26");
            //int k1 = GetInt();
            //int k2 = GetInt();
            //var a = GetEnumerableString();
            //Put(a.Take(k1-1).Union(a.Skip(k2).Take(a.Count()-k2)).Select(e=>e.Length).Average());

            //Task("LinqBegin27");
            //int d = GetInt();
            //var a = GetEnumerableInt().SkipWhile(e => e < d).Where(n => n % 2 == 1 && n > 0).Reverse();
            //Put(a.Count(), a);

            //Task("LinqBegin28");
            //int l = GetInt();
            //var a = GetEnumerableString().TakeWhile(e => e.Length <= l).Where(c => c[c.Length - 1] >= 'A' && c[c.Length - 1] <= 'Z').OrderByDescending(s => s.Length).ThenBy(s => s);
            //Put(a.Count(), a);

            //Task("LinqBegin29");
            //int d = GetInt();
            //int k = GetInt();
            //var a = GetEnumerableInt();
            //var b = a.TakeWhile(e => e < d).Union(a.Skip(k - 1)).Distinct().OrderByDescending(e => e);
            //Put(b.Count(), b);

            //Task("LinqBegin30");
            //int k = GetInt();
            //var a = GetEnumerableInt();
            //var b = a.Where(e => e % 2 == 0).Except(a.Skip(k)).Distinct().Reverse();
            //Put(b.Count(), b);

            //Task("LinqBegin31");
            //int k = GetInt();
            //var a = GetEnumerableString();
            //var b = a.Take(k).Intersect(a.Reverse().
            //        TakeWhile(c=> !char.IsDigit(c[c.Length-1])).Reverse())
            //        .Distinct().OrderBy(s => s.Length).ThenBy(s=>s);
            //Put(b.Count(), b);
            
            #endregion

        }
    }
}
