﻿using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModification : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newGroup = new GroupData("aaa");
            newGroup.Footer = "zzz";
            newGroup.Header = "qqq";
            List<GroupData> oldGroups = app.Groups.GetGroupList();
			app.Groups.IfNeedToCreate(newGroup);
			app.Groups.Modify(0, newGroup);
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups[0].Name = newGroup.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
    
    
}
