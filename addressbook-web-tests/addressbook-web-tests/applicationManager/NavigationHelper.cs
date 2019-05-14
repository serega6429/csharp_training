using OpenQA.Selenium;

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
            driver.FindElement(By.LinkText("home page")).Click();
        }
        public void GoToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

    }
}
