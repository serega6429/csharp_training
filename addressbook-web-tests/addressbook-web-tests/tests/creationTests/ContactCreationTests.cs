using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()  
        {
            app.Auth.Login(app.Admin);
            app.Contacts.GoToNewContact();
            app.Contacts.FillContactForm(new ContactData("Sergey", "Yusupov"));
            app.Contacts.SubmitContactCreation();
            app.Navigator.GoToHomePage();
            app.Auth.Logout();
        }   
    }
}
