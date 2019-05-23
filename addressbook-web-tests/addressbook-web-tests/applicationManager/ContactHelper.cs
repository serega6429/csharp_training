using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
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
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements
                (By.Name("entry"));

            foreach (IWebElement element in elements)
            {
                contacts.Add(new ContactData(element.FindElement
                    (By.XPath(".//td[3]")).Text, 
                    element.FindElement(By.XPath(".//td[2]")).Text));
            }
            return contacts;
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
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.Id("" + index + "")).Click();
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
