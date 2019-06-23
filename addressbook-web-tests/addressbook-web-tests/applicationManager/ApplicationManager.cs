using System;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            Driver = new FirefoxDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            BASEURL = "http://localhost/addressbook";
            verificationErrors = new StringBuilder();
            Auth = new LoginHelper(this);
            Navigator = new NavigationHelper(this);
            Groups = new GroupHelper(this);
            Contacts = new ContactHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                Auth.Logout();
                Driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstanse()
        {
            if(!app.IsValueCreated)
            {
                app.Value = new ApplicationManager();
                app.Value.Navigator.OpenLoginPage();
            }
            return app.Value;
        }

        public LoginHelper Auth { get; }
        public NavigationHelper Navigator { get; }
        public GroupHelper Groups { get; }
        public ContactHelper Contacts { get; }
        public IWebDriver Driver { get; }
        public string BASEURL { get; set; }
    }
}
