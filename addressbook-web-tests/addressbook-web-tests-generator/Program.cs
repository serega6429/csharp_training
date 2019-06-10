using System;
using System.IO;
using WebAddressbookTests;
namespace addressbook_web_tests_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            TestBase.GenerateRandomStrring(10);
            for (int i = 0;i < count; i++)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    TestBase.GenerateRandomStrring(10),
                    TestBase.GenerateRandomStrring(10),
                    TestBase.GenerateRandomStrring(10)));
            }
            writer.Close();
        }
    }
}
