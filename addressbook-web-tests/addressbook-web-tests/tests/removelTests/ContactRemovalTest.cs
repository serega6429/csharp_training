using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
			app.Contacts.IfNeedToCreate();
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Remove(0);
            List<ContactData> newContacts = app.Contacts.GetContactList();
			ContactData oldContact = oldContacts[0];
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