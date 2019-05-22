using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
			app.Contacts.IfNeedToCreate();
			app.Contacts.Remove(1);
        }
    }
}