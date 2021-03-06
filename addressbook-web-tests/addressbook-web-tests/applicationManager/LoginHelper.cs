﻿using System;
using OpenQA.Selenium;


namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void Login(AccountData account)
        {
            if (isLoginIn())
            {
                if(isLoginIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void Logout()
        {
            if (isLoginIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
                driver.FindElement(By.Name("user"));

            }
        }

        private bool isLoginIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool isLoginIn(AccountData account)
        {
			return isLoginIn()
				&& GetHashCodeLoggetUserName() == account.Username;
        }

		private string GetHashCodeLoggetUserName()
		{
			string acc = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
			return acc.Substring(1, acc.Length - 2);
		}
	}
}
