using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()  
        {
            app.Contacts.Create(new ContactData("Sergey", "Yusupov"));
        }   
    }
}
