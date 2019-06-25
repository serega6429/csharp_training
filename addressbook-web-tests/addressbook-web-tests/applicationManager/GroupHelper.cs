using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        private List<GroupData> GroupCache = null;
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }
        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            return this;
        }

        public void IfNeedToCreateGroupWithContact(GroupData groupData)
        {
            manager.Navigator.GoToGroupPage();
        }

        public GroupHelper IfNeedToCreate(GroupData newGroup)
        {
            manager.Navigator.GoToGroupPage();
            if (!(IsElementPresent(By.ClassName("group"))))
            {
                Create(newGroup);
            }
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            if (GroupCache == null)
            {
                GroupCache = new List<GroupData>();
                manager.Navigator.GoToGroupPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));

                foreach (IWebElement element in elements)
                {
                    GroupCache.Add(new GroupData(element.Text) {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<GroupData>(GroupCache);
        }

        public int GetGroupListCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public GroupHelper Modify(int v, GroupData newGroup)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newGroup);
            SubmitGroupModofocation();
            ReturnToGroupPage();
            return this;
        }
        public GroupHelper Modify(GroupData modGroup, GroupData newGroup)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(modGroup.Id);
            InitGroupModification();
            FillGroupForm(newGroup);
            SubmitGroupModofocation();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(group.Id);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }

        private GroupHelper SubmitGroupModofocation()
        {
            driver.FindElement(By.Name("update")).Click();
            GroupCache = null;
            return this;
        }

        private GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            GroupCache = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[ " + index + 1 + "]")).Click();
            return this;
        }

        public GroupHelper SelectGroup(string groupId)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' " +
                "and @value='" + groupId + "'])")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            GroupCache = null;
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

    }
}
