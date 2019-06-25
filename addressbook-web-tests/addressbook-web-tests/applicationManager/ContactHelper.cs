using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        private List<ContactData> ContactCache = null;
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

		public ContactData GetInformationTable(int index)
		{
			manager.Navigator.GoToHomePage();
			IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].
				FindElements(By.TagName("td"));
			string firstName = cells[2].Text;
			string lastName = cells[1].Text; ;
			string address = cells[3].Text;
			string allPhones = cells[5].Text;
			string allMails = cells[4].Text;

			return new ContactData(firstName, lastName)
			{
				Address = address,
				AllPhones = allPhones,
				AllMails = allMails
			};
		}

        public ContactData GetContactWithOutGroup()
        {
            manager.Navigator.GoToHomePage();
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[none]");
            if (!(IsElementPresent(By.ClassName("center"))))
            {
                Create(new ContactData()
                {
                    Firstname = DateTime.Now.ToString(),
                    Lastname = DateTime.Now.ToString()
                });
            }
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[none]");

            IList < IWebElement > cells = driver.FindElements(By.Name("entry"))[0].
                FindElements(By.TagName("td"));
            string firstName = cells[2].Text;
            string lastName = cells[1].Text; ;
            string Id = cells[0].FindElement(By.Name("selected[]")).GetAttribute("value").ToString();

            return new ContactData(firstName, lastName)
            {
                Id = Id
            };

        }

        public void RemoveContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            EditGroupFromFilter(group.Name);
            SelectContact(contact.Id);
            DeleteContact();
            WaitMsgBox();
        }

        private void EditGroupFromFilter(string nameGroup)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(nameGroup);
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroup(group.Name);
            CommitAddingContactToGroup();
            WaitMsgBox();

        }

        public void WaitMsgBox()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).
                            Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroup(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public ContactData GetInformationDetails(int index)
		{
			manager.Navigator.GoToHomePage();
			DetailsContact(index);
			string allInfo = driver.FindElement(By.Id("content")).Text;

			return new ContactData("", "")
			{
				DetailsContactInfo = allInfo
				
			};


		}

		private ContactHelper DetailsContact(int index)
		{
			driver.FindElement(By.XPath("(//img[@alt='Details'])[" + (index + 1) + "]")).Click();
			return this;
		}

		public ContactData GetInformationFrom(int index)
		{
			manager.Navigator.GoToHomePage();
			EditContact(index);
			string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
			string midlName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
			string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
			string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");

			string company = driver.FindElement(By.Name("company")).GetAttribute("value");
			string title = driver.FindElement(By.Name("title")).GetAttribute("value");

			string address = driver.FindElement(By.Name("address")).GetAttribute("value");

			string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
			string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
			string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
			string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");

			string email = driver.FindElement(By.Name("email")).GetAttribute("value");
			string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
			string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

			string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
			string bDay = driver.FindElement(By.Name("bday")).GetAttribute("value");
			string bMounth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
			string bYear = driver.FindElement(By.Name("byear")).GetAttribute("value");

			string aDay = driver.FindElement(By.Name("aday")).GetAttribute("value");
			string aMounth = driver.FindElement(By.Name("amonth")).GetAttribute("value");
			string aYear = driver.FindElement(By.Name("ayear")).GetAttribute("value");

			string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
			string pHome2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
			string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");
			


			return new ContactData(firstName, lastName)
			{
				Firstname = firstName,
				MidlName = midlName,
				Lastname = lastName,
				NickName = nickName,
				Company = company,
				Title = title,
				Address = address,
				HomePhone = homePhone,
				MobilePhone = mobilePhone,
				WorkPhone = workPhone,
				Fax = fax,
				Email = email,
				Email2 = email2,
				Email3 = email3,
				HomePage = homePage,
				BDay = bDay,
				BMounth = bMounth,
				BYear = bYear,
				ADay = aDay,
				AMounth = aMounth,
				AYear = aYear,
				Address2 = address2,
				Phome2 = pHome2,
				Notes = notes
			};
		}

		public ContactHelper IfNeedToCreate()
        {
            manager.Navigator.GoToHomePage();
            if (!(IsElementPresent(By.ClassName("center"))))
            {
                Create(new ContactData("Sergey", "Yusupov"));
            }
            return this;
        }

        public List<ContactData> GetContactList()
        {
            if (ContactCache == null)
            {
                ContactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements
                    (By.Name("entry"));

                foreach (IWebElement element in elements)
                {
                    ContactCache.Add(new ContactData(element.FindElement
						(By.XPath(".//td[3]")).Text,
						element.FindElement(By.XPath(".//td[2]")).Text)
					{Id = element.FindElement(By.TagName("input")).GetAttribute("id")
					});
                }
            }
            return new List<ContactData>(ContactCache);
        }
        public int GetContactListCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }


        public ContactHelper Create(ContactData contactData)
        {
            GoToNewContact();
            FillContactForm(contactData);
            SubmitContactCreation();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            SelectContact(v);
            DeleteContact();
            ContactCache = null;
            return this;
        }
        public ContactHelper Remove(ContactData contactData)
        {
            SelectContact(contactData.Id);
            DeleteContact();
            WaitMsgBox();
            ContactCache = null;
            return this;
        }

        public ContactHelper Modify(int v, ContactData contactData)
        {
            EditContact(v);
            FillContactForm(contactData);
            UpdateContact();
            return this;
        }

        public ContactHelper Modify(ContactData modify, ContactData contactData)
        {
            EditContact(modify.Id);
            FillContactForm(contactData);
            UpdateContact();
            WaitMsgBox();
            return this;
        }

        private ContactHelper UpdateContact()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private ContactHelper EditContact(int v)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (v + 1) + "]")).Click();
            return this;
        }

        private ContactHelper EditContact(string v)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]' and @value='" + v + "']/../..//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper GoToNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            Type(By.Name("firstname"), contact.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            ContactCache = null;
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElements(By.Name("entry"))[index].FindElement(By.Name("selected[]")).Click();
            return this;
        }
        public ContactHelper SelectContact(string index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' " +
                 "and @value='" + index + "'])")).Click();
            return this;
        }
        public ContactHelper DeleteContact()
        {
            acceptNextAlert = true;
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }
    }
}
