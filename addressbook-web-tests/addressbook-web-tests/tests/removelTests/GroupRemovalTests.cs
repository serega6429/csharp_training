using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        
        [Test]
        public void GroupRemovalTest()
        {
			app.Groups.IfNeedToCreate(new GroupData("AA", "SS", "DD"));
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData removingGroup = oldGroups[0];
            app.Groups.Remove(removingGroup);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupListCount());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData groupData in newGroups)
            {
                Assert.AreNotEqual(groupData.Id, removingGroup.Id);
            }

        }
    }
}
