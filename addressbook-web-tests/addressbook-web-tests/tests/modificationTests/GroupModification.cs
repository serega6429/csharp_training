using NUnit.Framework;
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
			app.Groups.IfNeedToCreate(newGroup);
			app.Groups.Modify(1, newGroup);
        }
    }
    
    
}
