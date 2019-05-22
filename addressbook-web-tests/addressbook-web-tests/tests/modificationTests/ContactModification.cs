using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModification : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
			app.Contacts.IfNeedToCreate();
			app.Contacts.Modify(1, new ContactData("Ivan", "Popov"));
            
        }

    }
}
