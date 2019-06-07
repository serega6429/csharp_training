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
			ContactData fromTable = app.Contacts.GetInformationTable(3);
			ContactData fromForm = app.Contacts.GetInformationFrom(3);

			Assert.AreEqual(fromTable, fromForm);
			Assert.AreEqual(fromTable.Address, fromForm.Address);
			Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
			Assert.AreEqual(fromTable.AllMails, fromForm.AllMails);
		}

		[Test]
		public void TestDetailsContactInformation()
		{
			ContactData fromForm = app.Contacts.GetInformationFrom(2);
			ContactData fromDetails = app.Contacts.GetInformationDetails(2);
			Assert.AreEqual(fromDetails.DetailsContactInfo, fromForm.FullContactInfo);


		}
	}
}
