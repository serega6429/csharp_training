using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.Start();
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
    }
}
