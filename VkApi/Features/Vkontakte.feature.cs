﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.2.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace VkApi.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Vkontakte")]
    public partial class VkontakteFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Vkontakte.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Vkontakte", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User log in")]
        public virtual void UserLogIn()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User log in", ((string[])(null)));
#line 3
this.ScenarioSetup(scenarioInfo);
#line 4
 testRunner.Given("I navigate to site", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
  testRunner.When("I enter \'autoperftester@gmail.com\' login and \'PuV6j_.2&amp;$m9h?UY\' password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 7
  testRunner.And("I click button \'Войти\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
   testRunner.Then("I move to user profile page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
  testRunner.When("I click profile menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
  testRunner.And("I click button \'Выйти\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
   testRunner.Then("I move to first page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User log in (Negative)")]
        [NUnit.Framework.TestCaseAttribute("", "", "Добро пожаловать", null)]
        [NUnit.Framework.TestCaseAttribute("1qwawerxtcy", "", "Добро пожаловать", null)]
        [NUnit.Framework.TestCaseAttribute("", "trhfdgchbjk", "Добро пожаловать", null)]
        [NUnit.Framework.TestCaseAttribute("dfxcgfghlhkgfxbfcngvhbvvjcfxfxhxgfxgxhgfxhf", "hghkfhfyf76of8fff", "Вход", null)]
        [NUnit.Framework.TestCaseAttribute("hghkfhfyf76of8fff", "hghkfhfyf76of8fff", "Вход", null)]
        public virtual void UserLogInNegative(string password, string login, string nameOfTitle, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User log in (Negative)", exampleTags);
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
 testRunner.Given("I navigate to site", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
  testRunner.When(string.Format("I enter \'{0}\' login and \'{1}\' password", login, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
  testRunner.And("I click button \'Войти\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
   testRunner.Then(string.Format("I stay on the page with \'{0}\' title", nameOfTitle), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Main test")]
        public virtual void MainTest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Main test", ((string[])(null)));
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
 testRunner.Given("I navigate to site", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
  testRunner.When("I enter \'autoperftester@gmail.com\' login and \'PuV6j_.2&amp;$m9h?UY\' password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
  testRunner.And("I click button \'Войти\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
   testRunner.Then("I move to user profile page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
  testRunner.When("I navigate to \'Моя Страница\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
  testRunner.And("Create post with randomly generated text on the wall and get the record id from t" +
                    "he response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
   testRunner.Then("Not updating the page, post exist on the wall with the right text from the right " +
                    "user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
  testRunner.When("Change the text and add picture the post through the API request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
   testRunner.Then("Without updating the page, message should be changed and the uploaded image shoul" +
                    "d be added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
  testRunner.When("Using the API request, add a comment to the post with random text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
   testRunner.Then("Not updating the page,comment from the right user should be added to the correct " +
                    "post", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
  testRunner.When("Add Like for the record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
   testRunner.Then("Through the request to the API, Like should be sent from the right user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
  testRunner.When("delete the created record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
   testRunner.Then("Not updating the page, the entry should be deleted", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
   testRunner.And("Delete created info by test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
  testRunner.When("I click profile menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
  testRunner.And("I click button \'Выйти\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Serach person")]
        [NUnit.Framework.TestCaseAttribute("sasha.jpg", "Беларусь", "Ховрин Александр", null)]
        public virtual void SerachPerson(string photoName, string country, string name, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Serach person", exampleTags);
#line 55
this.ScenarioSetup(scenarioInfo);
#line 56
 testRunner.Given("I navigate to site", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 58
  testRunner.When("I enter \'autoperftester@gmail.com\' login and \'PuV6j_.2&amp;$m9h?UY\' password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
  testRunner.And("I click button \'Войти\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
   testRunner.Then("I move to user profile page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 62
  testRunner.When("I navigate to \'Друзья\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
  testRunner.And("click to Extended configuration", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
  testRunner.And(string.Format("select \'{0}\' region", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
  testRunner.And(string.Format("enter the \'{0}\' name of person", name), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
   testRunner.Then(string.Format("all persons should have \'{0}\' name", name), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 68
  testRunner.When(string.Format("click to user according existing photo \'{0}\'", photoName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 69
   testRunner.Then("the user must be true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
  testRunner.When("I click profile menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 72
  testRunner.And("I click button \'Выйти\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
