using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManger()
        {
            app = ApplicationManager.GetInstanse();
        }
    }
}
