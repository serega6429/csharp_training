using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModification : TestBase
    {
        [Test]
        public void ContactModoficationTest()
        {
            app.Contacts.Modify(2, new ContactData("Ivan", "Popov"));
        }

    }
}
