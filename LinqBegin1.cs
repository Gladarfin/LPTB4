using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

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

            //Мда
            //Task("LinqBegin12");
            //Put(GetEnumerableInt().Aggregate(1.0, (num1, num2) => num1 * Math.Abs((num2%10))));

            //Task("LinqBegin13");
            //int n = GetInt();
            //Put(Enumerable.Range(1,n).Sum(e => 1.0/e));

            //Task("LinqBegin14");
            //int a = GetInt();
            //int b = GetInt();
            //Put(Enumerable.Range(a, b-a+1).Select(x=>x*x).Average());

            //Task("LinqBegin15");
            //int n = GetInt();
            //Put(Enumerable.Range(0, n).Aggregate(1.0, (num1, num2) => num1 + num1 * num2));
            #endregion

            #region Second group: LinqBegin16-LinqBegin31



            #endregion

        }
    }
}
