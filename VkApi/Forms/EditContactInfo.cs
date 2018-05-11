using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using demo.framework.Elements;
using demo.framework.forms;
using OpenQA.Selenium;
using VkApi.Menu;

namespace VkApi.Forms
{
   public class EditContactInfo : BaseForm
    {
        private const string TemplateSelectLocator = "//input[@id='{0}']/preceding-sibling::input";
        private const string TemplateLiLocator = "//li[contains(text(), '{0}')]";
        private TextBox _txbCity;
        private Button _btnSave;
        public EditInfoMenu rightMenu = new EditInfoMenu();

        public EditContactInfo()
            : base(By.ClassName("page_block_header"), "Friends Page")
        {
        }

        public void FillInfoUser(string text) {
            if (!string.IsNullOrEmpty(text))
            {
                new TextBox(By.Id("//div[contains(@id, 'pedit_country_row')]//input[@type = 'text']"), "Country").Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Россия")), "CountryLi").Click();
                Thread.Sleep(1000);
                _txbCity = new TextBox(By.XPath("//div[contains(@id, 'pedit_country_row')]//input[@type = 'text']"), "City");
                _txbCity.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Воронеж")), "CityLi").Click();
                Thread.Sleep(500);
                _btnSave = new Button(By.XPath("//button[contains(@class, 'flat_button button_big_width')]"), "Save button");
                if (_btnSave.IsDisplayed())
                {
                    _btnSave.Click();
                }
                Thread.Sleep(1000);
            }
            else
            {
                new TextBox(By.Id("//div[contains(@id, 'pedit_country_row')]//input[@type = 'text']"), "Country").Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Украина")), "CountryLi").Click();
                _txbCity = new TextBox(By.XPath("//div[contains(@id, 'pedit_country_row')]//input[@type = 'text']"), "City");
                _txbCity.Click();
                new TextBox(By.XPath(string.Format(TemplateLiLocator, "Донецк")), "CityLi").Click();
                Thread.Sleep(500);
                _btnSave = new Button(By.XPath("//button[contains(@class, 'flat_button button_big_width')]"), "Save button");
                if (_btnSave.IsDisplayed())
                {
                    _btnSave.Click();
                }
                Thread.Sleep(1000);
            }

        }
    }
}
