using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModification : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newGroup = new GroupData("aaa");
            newGroup.Footer = "zzz";
            newGroup.Header = "qqq";
			app.Groups.IfNeedToCreate(newGroup);
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];
			app.Groups.Modify(oldData, newGroup);

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups[0].Name = newGroup.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach(GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newGroup.Name, group.Name);
                }
            }
        }
    }
    
    
}
