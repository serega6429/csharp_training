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
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + v + "]")).Click();
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
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[ " + index + 1 + "]")).Click();
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
