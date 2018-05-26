using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using demo.framework;
using demo.framework.Elements;
using demo.framework.forms;
using OpenQA.Selenium;

namespace VkApi.Forms
{
    public class MainForm : BaseForm
    {
        private TextBox _txbWallPostUserId;
        private TextBox _txbWallPostComment;
        private readonly Button _btnShowFullInfo = new Button(By.XPath("//div[@id='profile_short']//span[contains(@class,'profile_label_more')]"), "Show full info button");
        private readonly Button _btnEditInfo = new Button(By.XPath("//*[@id='profile_edit_act']"), "Edit button");
        private readonly TextBox _txbPageBlock = 
            new TextBox(By.XPath("//div[@id='profile_wall']/div[contains(@class,('page_block'))]"), "Page Block Wall" );
        private string _namePhotoDownloaded = "";
        private const string TemplateWallPostLocator = "//div[contains(@class,'wall_text')]//div[contains(text(),'{0}')]";
        private const string RegularFindUrlPhoto = "{0}.+url\\((.+)\\)";
        private const string SeparatorPathToFolder = "\\";

        public MainForm()
            : base(By.XPath("//div[@id='narrow_column']/div[contains(@class,'page_photo')]"), "Main Page")
        {
        }

        public void AddLikeWallPost(string wallPostMessage)
        {
            var wallPostLocator = string.Format(TemplateWallPostLocator, wallPostMessage);
            var _btnLikeWalPost = 
                new Button (By.XPath(wallPostLocator + "/ancestor::div[contains(@class,'post_info')]//a[contains(@class,'like_btn like _like')][1]"),
                "Button 'Like' on the wall post");
            if (_btnLikeWalPost.IsDisplayed())
            {
                _btnLikeWalPost.Click();
            }
        }

        public void ClickEditInfo()
        {
            _btnEditInfo.ClickAndWait();
        }

        public void ClickShowFullInfo()
        {
            _btnShowFullInfo.Click();
        }


        public bool IsWallPostUser(string userId, string wallPostMessage)
        {
            var wallPostLocator = string.Format(TemplateWallPostLocator, wallPostMessage);
            _txbWallPostUserId = new TextBox(By.XPath(string.Format(wallPostLocator
                + "/ancestor::div[contains(@class,'_post_content')]//a[contains(@href,'{0}')]", userId)), "User id sent post to the wall");
            _txbPageBlock.ScrollToElement();
            var _txbWallPost = new TextBox(By.XPath(wallPostLocator), "Post on the wall");
            return _txbWallPost.IsPresent();
        }

        public bool IsWallPostMessage(string wallPostMessage)
        {
            var wallPostLocator = string.Format(TemplateWallPostLocator, wallPostMessage);
            BaseElement.WaitForElementPresent(By.XPath(wallPostLocator), "Post present on the wall");
            var _txbWallPost = new TextBox(By.XPath(wallPostLocator), "Post on the wall");
            return _txbWallPost.IsPresent();
        }

        public bool IsDeletedWallPost()
        {
            return !_txbWallPostUserId.IsPresent();
        }

        public bool IsCommentWallPost(string wallPostMessage)
        {
            _txbWallPostComment = new TextBox(By.XPath(string.Format(TemplateWallPostLocator,
                wallPostMessage)), "Post on the wall");
            return _txbWallPostComment.IsPresent();
        }

        public bool IsCommentWallPostUser(string userId, string commentWallMessage)
        {
            var commentWallPostLocator = string.Format("//div[contains(@class, 'reply_content')]//div[contains(text(),'{0}')]",
                commentWallMessage);
            BaseElement.WaitForElementPresent(By.XPath(commentWallPostLocator), "Post on the wall");
            var _txbWallPostCommentUserId = new TextBox(By.XPath(string.Format(commentWallPostLocator
                  + "/ancestor::div[contains(@class, 'reply_content')]//a[contains(@href,'{0}')]", userId)), "User id sent post to the wall");
            return _txbWallPostCommentUserId.IsPresent();
        }

        public bool IsCommentWallPostMesage(string commentWallMessage)
        {
            var commentWallPostLocator = string.Format("//div[contains(@class, 'reply_content')]//div[contains(text(),'{0}')]",
                commentWallMessage);
            BaseElement.WaitForElementPresent(By.XPath(commentWallPostLocator), "Post on the wall");
            var _txbCommentWall = new TextBox(By.XPath(commentWallPostLocator), "Comment on the wall post");
            return _txbCommentWall.IsPresent();
        }

        public double ComparePhoto(string pathToFolderDownload, string originalPhoto, string namePhotoDownloadedFromVk)
        {
            var similarity = 0.2;
            return similarity;
        }

        public string TakeUrlPhoto(string photoId)
        {
            var urlPhoto = "";
            var pageSource = Browser.GetDriver().PageSource;
            foreach (Match match in Regex.Matches(pageSource, string.Format(RegularFindUrlPhoto, photoId), RegexOptions.IgnoreCase))
            {
                urlPhoto = match.Groups[1].Value;
            }

            return urlPhoto;
        }

        public string DownloadFile(string pathToFolderDownload, string photoId)
        {
            var fullPatgToFile = Environment.CurrentDirectory + pathToFolderDownload;
            var url = TakeUrlPhoto(photoId);
            _namePhotoDownloaded = GetFilename(url);
            using (var client = new WebClient())
            {
                client.DownloadFile(url, fullPatgToFile + SeparatorPathToFolder + _namePhotoDownloaded);
            }
            return _namePhotoDownloaded;
        }

        private static string GetFilename(string hreflink)
        {
            var uri = new Uri(hreflink);
            var filename = Path.GetFileName(uri.LocalPath);
            return filename;
        }

        public void DeletePhotoDownloadedFromVk(string pathToFolderDownload, string photoName)
        {
            var fullPatgToFile = Environment.CurrentDirectory + pathToFolderDownload;
            File.Delete(fullPatgToFile + SeparatorPathToFolder + _namePhotoDownloaded);
        }
    }
}