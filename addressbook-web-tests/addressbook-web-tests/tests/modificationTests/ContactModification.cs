using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModification : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContact = new ContactData("Ivan", "Popov");

            app.Contacts.IfNeedToCreate();
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData modificationContact = oldContacts[1];
            app.Contacts.Modify(0, newContact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newContact.Firstname;
            oldContacts[0].Lastname = newContact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                if (contact.Equals(modificationContact))
                {
                    Assert.AreEqual(contact, modificationContact);
                }
            }

        }

    }
}
