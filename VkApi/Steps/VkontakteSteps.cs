using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using demo.framework;
using LibPuzzle;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TestVkApi.Forms;
using VkApi.Enumerables;
using VkApi.Forms;
using VkApi.Utils;

namespace VkApi.Steps
{
    [Binding]
    public class VkontakteSteps : BaseEntity
    {
        private readonly string _token = RunConfigurator.GetValue("token");
        private readonly string _userId = RunConfigurator.GetValue("userId");
        private readonly string _photoOriginalName = RunConfigurator.GetValue("photoOriginalName");
        private readonly string _pathToFolderResources = RunConfigurator.GetValue("pathToFolderResources");
        private const int LenghtMessage = 15;
        public LoginForm loginF;
        public NewsForm newsF;
        public EditIntrestsInfo editIntrestsInfo;
        public EditContactInfo editContactInfo;
        public VkApiUtils vkApiUtils;
        public EditMainInfo editMainInfo;
        public MainForm mainF;
        public Dictionary<string, string> photoInfo;
        private FriendsForm friendsForm;
        private SikuliActions sikuliActions = new SikuliActions();


        [After()]
        public void After()
        {
            Browser.GetDriver().Quit();
        }

        [Before()]
        public void Before()
        {
            Browser.GetInstance();
            Browser.GetDriver().Manage().Window.Maximize();
        }

        [Given(@"I navigate to site")]
        public void GivenINavigateTo()
        {
            Browser.GetDriver().Navigate().GoToUrl(Configuration.GetBaseUrl());
            Log.Step("Navigate to vk.com");
            loginF = new LoginForm();
        }

        [When(@"I enter '(.*)' login and '(.*)' password")]
        public void WhenIEnteredLoginAndPassword(string login, string pass)
        {
            Log.Step("Login");
            loginF.Login(login, pass);
        }

        [When(@"I click button '(.*)'")]
        public void WhenIClickButton(string nameBtn)
        {
            FormUtil.ClickBtn(nameBtn);
        }

        [Then(@"I move to user profile page")]
        public void ThenIMovedToUserProfilePage()
        {
            WebDriverWait Wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromMilliseconds(Double.Parse(Configuration.GetTimeout())));
            Wait.Until(drv => drv.Title == "Новости");
            Assert.AreEqual(Browser.GetDriver().Title,"Новости");
        }

        [When(@"I click profile menu")]
        public void WhenIClickProfileMenu()
        {
            newsF = new NewsForm();
            newsF.ClickProfileMenuBtn();
        }

        [When(@"I navigate to '(.*)'")]
        public void WhenINavigateToMainPage(string item)
        {
            newsF = new NewsForm();
            newsF.sideMenu.NavigateToMenuItem(item);
        }

        [When(@"Create post with randomly generated text on the wall and get the record id from the response")]
        public void WhenReatePostWithRandomlyGeneratedTextOnTheWallAndGetTheRecordIdFromTheResponse()
        {
            Log.Step("Using the API request, create an post with randomly generated text on the wall and get the record id from the response");
            vkApiUtils = new VkApiUtils();
            var messagePost = RandomUtils.RandomString(LenghtMessage);
            ScenarioContext.Current["messagePost"] = messagePost;
            ScenarioContext.Current["idPost"] = vkApiUtils.CreateWallPost(_userId, MethodEnum.WALL_POST.GetStringMapping(), _token, messagePost);
        }

        [Then(@"Not updating the page, post exist on the wall with the right text from the right user")]
        public void ThenNotUpdatingThePagePostExistOnTheWallWithTheRightTextFromTheRightUser()
        {
            mainF = new MainForm();
            var messagePost = ScenarioContext.Current.Get<String>("messagePost");
            Log.Step("Not updating the page, check was an post on the wall with the right text from the right user");
            Assert.IsTrue(mainF.IsWallPostMessage(messagePost), "This post doesn't exist on the wall");
            Assert.IsTrue(mainF.IsWallPostUser(_userId, messagePost), "This user not sent this post to the wall");
        }

        [When(@"Change the text and add picture the post through the API request")]
        public void WhenChangeTheTextAndAddPictureThePostThroughTheAPIRequest()
        {
            Log.Step("Edit the post through the API request - change the text and add (load) any picture.");
            ScenarioContext.Current["messageEditPost"] = RandomUtils.RandomString(LenghtMessage);
            photoInfo = vkApiUtils.AddPhotoWithMessage(_userId, ScenarioContext.Current.Get<String>("idPost"),
                MethodEnum.PHOTOS_SAVE_WALL_PHOTO.GetStringMapping(), _token, _pathToFolderResources + _photoOriginalName, ScenarioContext.Current.Get<String>("messageEditPost"));
        }

        [Then(@"Without updating the page, message should be changed and the uploaded image should be added")]
        public void ThenWithoutUpdatingThePageMessageShouldBeChangedAndTheUploadedImageShouldBeAdded()
        {
            Log.Step(@"Without updating the page, make sure that the text of the
            message has changed and the uploaded image has been added(make sure that the pictures are the same)");
            Assert.IsTrue(mainF.IsWallPostMessage(ScenarioContext.Current.Get<String>("messageEditPost")), "This post didn't edited on the wall");
            var downloadedFileName = mainF.DownloadFile(_pathToFolderResources, photoInfo["photoId"]);
            ScenarioContext.Current["downloadedFileName"] = downloadedFileName;
            var similarityImages = mainF.ComparePhoto(_pathToFolderResources, _photoOriginalName, downloadedFileName);
            Assert.IsTrue(similarityImages < IPuzzle.LowSimilarityThreshold, "Images don't match");
        }

        [Then(@"I move to first page")]
        public void ThenIMovedToFirstPage()
        {
            WebDriverWait Wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromMilliseconds(Double.Parse(Configuration.GetTimeout())));
            Wait.Until(drv => drv.Title.Contains("ВКонтакте"));
            Assert.IsTrue(Browser.GetDriver().Title.Contains("ВКонтакте"));
        }

        [Then(@"I stay on the page with '(.*)' title")]
        public void ThenIStayOnTheFirstPage(string title)
        {
            Thread.Sleep(2000);
            Assert.IsTrue(Browser.GetDriver().Title.Contains(title));
        }


        [When(@"Using the API request, add a comment to the post with random text")]
        public void WhenUsingTheAPIRequestAddACommentToThePostWithRandomText()
        {
            Log.Step("Using the API request, add a comment to the post with random text");
            var messageComment = RandomUtils.RandomString(LenghtMessage);
            ScenarioContext.Current["messageComment"] = messageComment;
            vkApiUtils.ExecuteMessageActionWall(_userId, ScenarioContext.Current.Get<String>("idPost"), MethodEnum.WALL_CREATE_COMMENT.GetStringMapping(), _token, messageComment);
        }

        [Then(@"Not updating the page,comment from the right user should be added to the correct post")]
        public void ThenNotUpdatingThePageCommentFromTheRightUserShouldBeAddedToTheCorrectPost()
        {
            Log.Step("Not updating the page, it's necessary that a comment from the right user is added to the correct post");
            Assert.IsTrue(mainF.IsCommentWallPost(ScenarioContext.Current.Get<String>("messageEditPost")), "This post not present on the wall");
            Assert.IsTrue(mainF.IsCommentWallPostUser(_userId, ScenarioContext.Current.Get<String>("messageComment")), "This user not sent this post to the wall");
            Assert.IsTrue(mainF.IsCommentWallPostMesage(ScenarioContext.Current.Get<String>("messageComment")), "This comment not present on the wall");
        }

        [When(@"Add Like for the record")]
        public void WhenAddForTheRecord()
        {
            mainF.AddLikeWallPost(ScenarioContext.Current.Get<String>("messageEditPost"));
        }

        [Then(@"Through the request to the API, Like should be sent from the right user")]
        public void ThenThroughTheRequestToTheAPILikeShouldBeSentFromTheRightUser()
        {
            Log.Step("Through the request to the API, make sure that the 'Like' was sent from the right user");
            Assert.IsTrue(vkApiUtils.IsUserLikePost(_userId, ScenarioContext.Current.Get<String>("idPost"),
                MethodEnum.LIKES_ISLIKED.GetStringMapping(), "post", _token), "No like from this user");
        }

        [When(@"delete the created record")]
        public void WhenDeleteTheCreatedRecord()
        {
            Log.Step("Via the API request, delete the created record");
            vkApiUtils.DeleteWallPost(_userId, ScenarioContext.Current.Get<String>("idPost"), MethodEnum.WALL_DELETE.GetStringMapping(), _token);
        }

        [Then(@"Not updating the page, the entry should be deleted")]
        public void ThenNotUpdatingThePageTheEntryShouldBeDeleted()
        {
            Log.Step("Not updating the page, it's necessary to make sure that the entry is deleted");
        }

        [Then(@"Delete created info by test")]
        public void ThenDeleteCreatedInfoByTest()
        {
            vkApiUtils.DeletePhotoFromSite(MethodEnum.PHOTOS_DELETE.GetStringMapping(), _userId, photoInfo["photoId"], _token);
            mainF.DeletePhotoDownloadedFromVk(_pathToFolderResources, ScenarioContext.Current.Get<String>("downloadedFileName"));
        }

        [When(@"click to Extended configuration")]
        public void WhenClickToExtendedConfiguration()
        {
            friendsForm = new FriendsForm();
            friendsForm.ClickToExtendedConfiguration();
        }

        [When(@"select '(.*)' region")]
        public void WhenSelectRegion(string region)
        {
            friendsForm.SelectRegion(region);
        }

        [When(@"enter the '(.*)' name of person")]
        public void WhenEnterTheNameOfPerson(string name)
        {
            friendsForm.EnterNameForSearch(name);
        }

        [Then(@"all persons should have '(.*)' name")]
        public void ThenAllPersonsShouldHaveName(string p0)
        {
            Thread.Sleep(1000);
        }

        [When(@"click to user according existing photo '(.*)'")]
        public void WhenClickToUserAccordingExistingPhoto(string photo)
        {
            sikuliActions.Click(photo);
        }

        [Then(@"the user must be true")]
        public void ThenTheUserMustBeTrue()
        {
            Thread.Sleep(3000);
        }

        [When(@"I click edit info about user button")]
        public void WhenIClickEditInfoAboutUserButton()
        {
            mainF = new MainForm();
            mainF.ClickEditInfo();
        }

        [When(@"navigate to '(.*)' from right menu")]
        public void WhenNavigateToFromRightMenu(string item)
        {
            editMainInfo = new EditMainInfo();
            editMainInfo.rightMenu.NavigateToMenuItem(item);
        }

        [When(@"(fill|clear) info about (Intrests|Main|Contacts|Study|Carrier|Army|LivePosition) in fields and save this changing")]
        public void WhenFillInfoInFiledsAndSaveThisChanging(string mode, string tab)
        {
            Thread.Sleep(1000);
            if (mode == "fill")
            {
                switch (tab)
                {
                    case "Intrests":
                        {
                            editIntrestsInfo = new EditIntrestsInfo();
                            editIntrestsInfo.FillInfoUser("test");
                        }
                        break;
                    case "Main":
                        {
                            editMainInfo = new EditMainInfo();
                            editMainInfo.FillInfoUser("test");
                        }
                        break;
                    case "Contacts":
                        {
                            editContactInfo = new EditContactInfo();
                            editContactInfo.FillInfoUser("test");
                        }
                        break;
                    case "Study":
                        { editIntrestsInfo.FillInfoUser("test"); }
                        break;
                    case "Carrier":
                        { editIntrestsInfo.FillInfoUser("test"); }
                        break;
                    case "Army":
                        { editIntrestsInfo.FillInfoUser("test"); }
                        break;
                    case "LivePosition":
                        { editIntrestsInfo.FillInfoUser("test"); }
                        break;
                    default: break;
                }

            }
            else
            {
                switch (tab)
                {
                    case "Intrests":
                        {
                            editIntrestsInfo = new EditIntrestsInfo();
                            editIntrestsInfo.FillInfoUser(""); }
                        break;
                    case "Main":
                        {
                            editMainInfo = new EditMainInfo();
                            editMainInfo.FillInfoUser("");
                        }
                        break;
                    case "Contacts":
                        {
                            editContactInfo = new EditContactInfo();
                            editContactInfo.FillInfoUser("test");
                        }
                        break;
                    case "Study":
                        { editIntrestsInfo.FillInfoUser("test"); }
                        break;
                    case "Carrier":
                        { editIntrestsInfo.FillInfoUser("test"); }
                        break;
                    case "Army":
                        { editIntrestsInfo.FillInfoUser("test"); }
                        break;
                    case "LivePosition":
                        { editIntrestsInfo.FillInfoUser("test"); }
                        break;
                    default:
                        break;
                }
            }
            Thread.Sleep(2000);
        }

        [When(@"click show full information button")]
        public void WhenClickShowFullInformationButton()
        {
            mainF = new MainForm();
            mainF.ClickShowFullInfo();
        }


        [Then(@"all info (Intrests|Main|Contacts|Study|Carrier|Army|LivePosition) equals true info")]
        public void ThenAllInfoEqualsTrueInfo(string value)
        {
            Thread.Sleep(2000);
        }


    }
}
