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
            app.Groups.IfNeedToCreate(new GroupData("AA", "SS", "DD"));
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = null;
            if (oldList.Count == 0)
            {
                contact = app.Contacts.GetContactWithOutGroup();
                app.Contacts.AddContactToGroup(contact, group);
            }
            else
            {
                contact = oldList[0];
            }
            app.Contacts.RemoveContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);

        }

    }
}
