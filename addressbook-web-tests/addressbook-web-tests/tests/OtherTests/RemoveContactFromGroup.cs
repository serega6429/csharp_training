using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class RemoveContactFromGroup : AuthTestBase
    {
        [Test]
        public void TestRemoveContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList[0];

            app.Contacts.RemoveContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);

        }

    }
}
