using PT4;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        // ��� ������� ����� ������ LinqXml �������� ���������
        // �������������� ������ ����������, ������������ � ���������:
        //
        //   Show() � Show(cmt) - ���������� ������ ������������������,
        //     cmt - ��������� �����������;
        //
        //   Show(e => r) � Show(cmt, e => r) - ���������� ������
        //     �������� r, ���������� �� ��������� e ������������������,
        //     cmt - ��������� �����������.

        public static void Solve()
        {
            Task("LinqXml1");

            //LinqXml1�. ���� ����� ������������� ���������� ����� � ������������ XML-���������.
            //������� XML - �������� � �������� ��������� root � ���������� ������� ������ line, 
            //������ �� ������� �������� ���� ������ �� ��������� �����.

            //��������. � ������������ ��������� �������� ������������ ������������������ 
            //�������� XElement, ���������� ������� Select �� ��������� ������ �����. 

            //��������� ���� � ����������
            var file = File.ReadAllLines(GetString(), Encoding.Default);

            //������� ����� XML-��������
            XDocument doc = new XDocument(

                //������� ���������� ���������
                new XDeclaration(null, "windows-1251", null),
                //������� �������� �������
                new XElement("root",
                //��������� ������ �� ����� � ��������
                file.Select(e => new XElement("line", e))));

            //��������� ��������
            doc.Save(GetString());

        }
    }
}
