using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModification : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContact = new ContactData("Petr", "Petrov");

            app.Contacts.IfNeedToCreate();
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData modificationContact = oldContacts[0];
            app.Contacts.Modify(modificationContact, newContact);
            List<ContactData> newContacts = ContactData.GetAll();
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
