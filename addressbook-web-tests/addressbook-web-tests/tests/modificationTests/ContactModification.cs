using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModification : AuthTestBase
    {
        [Test]
        public void ContactModoficationTest()
        {
            app.Contacts.Modify(2, new ContactData("Ivan", "Popov"));
        }

    }
}
