﻿using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager manager) : base(manager)
        {
            baseURL = manager.BASEURL;
        }

        public void GoToHomePage()
        {
            if (!(driver.Url.EndsWith("addressbook/") &&
                !IsElementPresent(By.Name("pass"))))
            {
                driver.FindElement(By.LinkText("home")).Click();
            }
        }
        public void GoToGroupPage()
        {           
            if (!(driver.Url.EndsWith("group.php") 
                && IsElementPresent(By.Name("new"))))
            {
                driver.FindElement(By.LinkText("groups")).Click();
            }
        }
        public void OpenLoginPage()
        {
            if (!(driver.Url.EndsWith("addressbook/")
                && IsElementPresent(By.Name("pass"))))
            {
                driver.Navigate().GoToUrl(baseURL);
            }
        }

    }
}
