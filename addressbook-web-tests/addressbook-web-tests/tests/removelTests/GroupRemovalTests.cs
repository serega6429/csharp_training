using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        
        [Test]
        public void GroupRemovalTest()
        {
            app.Auth.Login(app.Admin);
            app.Navigator.GoToGroupPage();
            app.Groups.SelectGroup(2);
            app.Groups.RemoveGroup();
            app.Groups.ReturnToGroupPage();
            app.Auth.Logout();
        }
    }
}
