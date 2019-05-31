using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
	[TestFixture]
	public class ContactInformationTests : AuthTestBase
	{
		[Test]
		public void TestContactInformation()
		{
			ContactData fromTable = app.Contacts.GetInformationTable(2);
			ContactData fromForm = app.Contacts.GetInformationFrom(2);

			Assert.AreEqual(fromTable, fromForm);
			Assert.AreEqual(fromTable.Address, fromForm.Address);
			Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
			Assert.AreEqual(fromTable.AllMails, fromForm.AllMails);
		}
	}
}
