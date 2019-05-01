using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactCreationTests : CreationTests
    {
        [Test]
        public void ContactCreationTest()  
        {
            OpenLoginPage();
            Login(accountAdmin);
            GoToNewContact();
            FillContactForm(new ContactData("Sergey", "Yusupov"));
            SubmitContactCreation();
            GoToHomePage();
            Logout();
        }

        private void GoToNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
        }

        private void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
        }
    }
}
