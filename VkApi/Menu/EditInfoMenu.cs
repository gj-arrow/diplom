using demo.framework.Elements;
using demo.framework.forms;
using OpenQA.Selenium;
using VkApi.Enumerables;

namespace VkApi.Menu
{
    public class EditInfoMenu : BaseForm
    {
        private  Link _linkMenuItem;
        private const string TemplateMenuLocator = "//*[@id='narrow_column']/div//a/span[contains(text(),'{0}')]";

        public EditInfoMenu() : base(By.XPath("//ol"),
            "Main side menu")
        {
        }

        public void NavigateToMenuItem(string menuItem)
        {
            _linkMenuItem = new Link(
                By.XPath(string.Format(TemplateMenuLocator, menuItem)),
                "Edit info menu item:" + menuItem);
            _linkMenuItem.Click();
        }
    }
}
