using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class GroupTestBase : AuthTestBase
        
    {
        [TearDown]
        public void CompareGroup_DB()
        {
            if (PERFOM_LONG_UI_CHECK)
            {
                List<GroupData> fromUI = app.Groups.GetGroupList();
                List<GroupData> fromDB = GroupData.GetAll();
                fromDB.Sort();
                fromUI.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }

    }
}
