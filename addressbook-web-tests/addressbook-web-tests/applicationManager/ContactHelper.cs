using OpenQA.Selenium;
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

		internal ContactData GetInformationTable(int index)
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

		public ContactData GetInformationFrom(int index)
		{
			manager.Navigator.GoToHomePage();
			EditContact(index);
			string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
			string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
			string address = driver.FindElement(By.Name("address")).GetAttribute("value");

			string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
			string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
			string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

			string email = driver.FindElement(By.Name("email")).GetAttribute("value");
			string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
			string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

			return new ContactData(firstName, lastName)
			{
				Address = address,
				HomePhone = homePhone,
				MobilePhone = mobilePhone,
				WorkPhone = workPhone,
				Email = email,
				Email2 = email2,
				Email3 = email3
			};
		}

		public ContactHelper IfNeedToCreate()
        {
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
            FillContactForm(new ContactData("Sergey", "Yusupov"));
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

        public ContactHelper Modify(int v, ContactData contactData)
        {
            EditContact(v);
            FillContactForm(contactData);
            UpdateContact();
            return this;
        }

        private ContactHelper UpdateContact()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private ContactHelper EditContact(int v)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + v + 1 + "]")).Click();
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
        public ContactHelper DeleteContact()
        {
            acceptNextAlert = true;
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }
    }
}
