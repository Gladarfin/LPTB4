using PT4;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        // При решении задач группы LinqXml доступны следующие
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
            Task("LinqXml1");

            //LinqXml1°. Даны имена существующего текстового файла и создаваемого XML-документа.
            //Создать XML - документ с корневым элементом root и элементами первого уровня line, 
            //каждый из которых содержит одну строку из исходного файла.

            //Указание. В конструкторе корневого элемента использовать последовательность 
            //объектов XElement, полученную методом Select из исходного набора строк. 

            //Считываем файл в переменную
            var file = File.ReadAllLines(GetString(), Encoding.Default);

            //Создаем новый XML-документ
            XDocument doc = new XDocument(

                //Создаем объявление документа
                new XDeclaration(null, "windows-1251", null),
                //Создаем корневой элемент
                new XElement("root",
                //Добавляем строки из файла в документ
                file.Select(e => new XElement("line", e))));

            //Сохраняем документ
            doc.Save(GetString());

        }
    }
}
