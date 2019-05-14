using NUnit.Framework;
namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModification : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newGroup = new GroupData("aaa");
            newGroup.Footer = "zzz";
            newGroup.Header = "qqq";
            app.Groups.Modify(2, newGroup);
        }
    }
    
    
}
