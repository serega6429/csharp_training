﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            app.Groups.IfNeedToCreate(new GroupData("AA", "SS", "DD"));
            app.Contacts.IfNeedToCreate();

            List<ContactData> allContacts = ContactData.GetAll();
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            if (oldList.Count == allContacts.Count)
            {
                app.Contacts.Create(new ContactData()
                {
                    Firstname = "aa",
                    Lastname = "bb"
                });
                //app.Contacts.WaitMsgBox();
            }
            ContactData contact = ContactData.GetAll().Except(oldList).First();
            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }

    }
}
