using NUnit.Framework;
using System;
using System.Text;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;
        public static Random rnd = new Random();

        [SetUp]
        public void SetupApplicationManger()
        {
            app = ApplicationManager.GetInstanse();
        }

        public static string GenerateRandomStrring(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder bld = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                bld.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 223)));
            }
            return bld.ToString();
        }
    }
}
