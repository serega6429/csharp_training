using NUnit.Framework;
using System;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            app.Auth.Logout();
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);
            Assert.IsTrue(app.Auth.isLoginIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            app.Auth.Logout();
            AccountData invalidAccount = new AccountData("admin", "1111");
            app.Auth.Login(invalidAccount);
            Assert.IsFalse(app.Auth.isLoginIn(invalidAccount));
        }

    }
}
