using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        
        [Test]
        public void GroupRemovalTest()
        {
			app.Groups.IfNeedToCreate(new GroupData("AA", "SS", "DD"));
			app.Groups.Remove(1);
        }
    }
}
