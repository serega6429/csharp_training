using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : GroupTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
			app.Contacts.IfNeedToCreate();
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldContact = oldContacts[0];
            app.Contacts.Remove(oldContact);
            List<ContactData> newContacts = ContactData.GetAll();
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactListCount());
            oldContacts.RemoveAt(0);
			Assert.AreEqual(oldContacts, newContacts);
			foreach(ContactData contact in newContacts)
			{
				Assert.AreNotEqual(contact.Id, oldContact.Id);
			}
        }
    }
}