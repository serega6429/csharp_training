﻿using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        
        [Test]
        public void GroupRemovalTest()
        {
			app.Groups.IfNeedToCreate(new GroupData("AA", "SS", "DD"));
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(0);
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
