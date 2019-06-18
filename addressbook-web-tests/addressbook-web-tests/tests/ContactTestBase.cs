using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareContact_DB()
        {
            if (PERFOM_LONG_UI_CHECK)
            {
                List<ContactData> fromUI = app.Contacts.GetContactList();
                List<ContactData> fromDB = ContactData.GetAll();
                fromDB.Sort();
                fromUI.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}
