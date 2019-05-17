using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()  
        {
            app.Contacts.Create(new ContactData("Sergey", "Yusupov"));
        }   
    }
}
