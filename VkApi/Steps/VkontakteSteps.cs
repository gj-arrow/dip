using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using demo.framework;
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
        private Dictionary<string, string> photoInfo;
        private MainForm mainF;
        private readonly SikuliActions _sikuliActions = new SikuliActions();


        [After]
        public void After()
        {
            Browser.GetDriver().Quit();
        }

        [Before]
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
        }

        [When(@"I enter '(.*)' login and '(.*)' password")]
        public void WhenIEnteredLoginAndPassword(string login, string pass)
        {
            var loginF = new LoginForm();
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
            Assert.AreEqual("Новости", Browser.GetDriver().Title);
        }

        [When(@"I click profile menu")]
        public void WhenIClickProfileMenu()
        {
            var newsF = new NewsForm();
            newsF.ClickProfileMenuBtn();
        }

        [When(@"I navigate to '(.*)'")]
        public void WhenINavigateToMainPage(string item)
        {
            var newsF = new NewsForm();
            newsF.sideMenu.NavigateToMenuItem(item);
        }

        [When(@"Create post with randomly generated text on the wall and get the record id from the response")]
        public void WhenReatePostWithRandomlyGeneratedTextOnTheWallAndGetTheRecordIdFromTheResponse()
        {
            Log.Step("Using the API request, create an post with randomly generated text on the wall and get the record id from the response");
            var messagePost = RandomUtils.RandomString(LenghtMessage);
            ScenarioContext.Current["messagePost"] = messagePost;
            ScenarioContext.Current["idPost"] = VkApiUtils.CreateWallPost(_userId, VkMethodItems.WALL_POST.GetStringMapping(), _token, messagePost);
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
            photoInfo = VkApiUtils.AddPhotoWithMessage(_userId, ScenarioContext.Current.Get<String>("idPost"),
                VkMethodItems.PHOTOS_SAVE_WALL_PHOTO.GetStringMapping(), _token, _pathToFolderResources + _photoOriginalName, ScenarioContext.Current.Get<String>("messageEditPost"));
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
            Assert.IsTrue(similarityImages < 0.3, "Images don't match");
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
            VkApiUtils.ExecuteMessageActionWall(_userId, ScenarioContext.Current.Get<String>("idPost"), VkMethodItems.WALL_CREATE_COMMENT.GetStringMapping(), _token, messageComment);
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
            Assert.IsTrue(VkApiUtils.IsUserLikePost(_userId, ScenarioContext.Current.Get<String>("idPost"),
                VkMethodItems.LIKES_ISLIKED.GetStringMapping(), "post", _token), "No like from this user");
        }

        [When(@"delete the created record")]
        public void WhenDeleteTheCreatedRecord()
        {
            Log.Step("Via the API request, delete the created record");
            VkApiUtils.DeleteWallPost(_userId, ScenarioContext.Current.Get<String>("idPost"), VkMethodItems.WALL_DELETE.GetStringMapping(), _token);
        }

        [Then(@"Not updating the page, the entry should be deleted")]
        public void ThenNotUpdatingThePageTheEntryShouldBeDeleted()
        {
            Log.Step("Not updating the page, it's necessary to make sure that the entry is deleted");
        }

        [Then(@"Delete created info by test")]
        public void ThenDeleteCreatedInfoByTest()
        {
            VkApiUtils.DeletePhotoFromSite(VkMethodItems.PHOTOS_DELETE.GetStringMapping(), _userId, photoInfo["photoId"], _token);
            mainF.DeletePhotoDownloadedFromVk(_pathToFolderResources, ScenarioContext.Current.Get<String>("downloadedFileName"));
        }

        [When(@"click to Extended configuration")]
        public void WhenClickToExtendedConfiguration()
        {
            var friendsForm = new FriendsForm();
            friendsForm.ClickToExtendedConfiguration();
        }

        [When(@"select '(.*)' region")]
        public void WhenSelectRegion(string region)
        {
            var friendsForm = new FriendsForm();
            friendsForm.SelectRegion(region);
        }

        [When(@"enter the '(.*)' name of person")]
        public void WhenEnterTheNameOfPerson(string name)
        {
            var friendsForm = new FriendsForm();
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
            _sikuliActions.Click(photo);
        }

        [Then(@"the user must be true")]
        public void ThenTheUserMustBeTrue()
        {
            Thread.Sleep(3000);
        }

        [When(@"I click edit info about user button")]
        public void WhenIClickEditInfoAboutUserButton()
        {
            mainF.ClickEditInfo();
        }

        [When(@"navigate to '(.*)' from right menu")]
        public void WhenNavigateToFromRightMenu(string item)
        {
            var editMainInfo = new EditMainInfo();
            editMainInfo.rightMenu.NavigateToMenuItem(item);
        }

        [When(@"(fill|clear) info about '(.*)' in fields and save this changing")]
        public void WhenFillInfoInFiledsAndSaveThisChanging(string mode, string tab)
        {
            Thread.Sleep(1000);
            if (mode == "fill")
            {
                switch (tab)
                {
                    case "Интересы":
                    {
                        var editIntrestsInfo = new EditIntrestsInfo();
                        editIntrestsInfo.FillInfoUser("test");
                    }
                        break;
                    case "Основное":
                            {
                                var editMainInfo = new EditMainInfo();
                                editMainInfo.FillInfoUser("test");
                            }
                        break;
                    case "Контакты":
                    {
                        var editContactInfo = new EditContactInfo();
                        editContactInfo.FillInfoUser("test");
                    }
                        break;
                    case "Образование":
                    {
                        var editStudyInfo = new EditStudyInfo();
                        editStudyInfo.FillInfoUser("test");
                    }
                        break;
                    case "Карьера":
                    {
                        var editCarrierInfo = new EditCarrierInfo();
                        editCarrierInfo.FillInfoUser("test");
                    }
                        break;
                    case "Военная служба":
                    {
                        var editArmyInfo = new EditArmyInfo();
                        editArmyInfo.FillInfoUser("test");
                    }
                        break;
                    case "Жизненная позиция":
                    {
                        var editLivePositionInfo = new EditLivePositionInfo();
                        editLivePositionInfo.FillInfoUser("test");
                    }
                        break;
                }

            }
            else
            {
                switch (tab)
                {
                    case "Интересы":
                    {
                        var editIntrestsInfo = new EditIntrestsInfo();
                        editIntrestsInfo.FillInfoUser(""); }
                    break;
                    case "Основное":
                    {
                        var editMainInfo = new EditMainInfo();
                        editMainInfo.FillInfoUser("");
                    }
                        break;
                    case "Контакты":
                    {
                        var editContactInfo = new EditContactInfo();
                        editContactInfo.FillInfoUser("");
                    }
                    break;
                    case "Образование":
                    {
                        var editStudyInfo = new EditStudyInfo();
                        editStudyInfo.FillInfoUser("");
                    }
                        break;
                    case "Карьера":
                    {
                        var editCarrierInfo = new EditCarrierInfo();
                        editCarrierInfo.FillInfoUser("");
                    }
                        break;
                    case "Военная служба":
                    {
                        var editArmyInfo = new EditArmyInfo();
                        editArmyInfo.FillInfoUser("");
                    }
                        break;
                    case "Жизненная позиция":
                    {
                        var editLivePositionInfo = new EditLivePositionInfo();
                        editLivePositionInfo.FillInfoUser("");
                    }
                        break;
                }
            }
            Thread.Sleep(2000);
        }

        [When(@"click show full information button")]
        public void WhenClickShowFullInformationButton()
        {
            mainF.ClickShowFullInfo();
        }

        [Then(@"all info '(.*)' equals true info")]
        public void ThenAllInfoEqualsTrueInfo(string value)
        {
            Thread.Sleep(2000);
        }
    }
}
