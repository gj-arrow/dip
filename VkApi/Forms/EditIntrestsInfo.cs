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
   public class EditIntrestsInfo : BaseForm
    {
        private readonly TextBox _txbActivities = new TextBox(By.Id("pedit_interests_activities"), "Acivities");
        private readonly TextBox _txbIntrests = new TextBox(By.Id("pedit_interests_interests"), "Intrests");
        private readonly TextBox _txbFavouriteMusic = new TextBox(By.Id("pedit_interests_music"), "FavouriteMusic");
        private readonly TextBox _txbFavouriteMovies = new TextBox(By.Id("pedit_interests_movies"), "FavouriteMovies");

        public EditIntrestsInfo()
            : base(By.ClassName("page_block_header"), "Friends Page")
        {
        }

        public void FillInfoUser(string text) {
            if (!string.IsNullOrEmpty(text))
            {
                _txbActivities.SetText(text);
                _txbIntrests.SetText(text);
                _txbFavouriteMusic.SetText(text);
                _txbFavouriteMovies.ScrollToElement();
                Thread.Sleep(700);
                _txbFavouriteMovies.SetText(text);
                var _txbFavouriteTV = new TextBox(By.Id("pedit_interests_tv"), "FavouriteTv");
                _txbFavouriteTV.SetText(text);
                var _txbFavouriteBooks = new TextBox(By.Id("pedit_interests_books"), "FavouriteBooks");
                _txbFavouriteBooks.SetText(text);
                Thread.Sleep(700);
                var _txbFavouriteGames = new TextBox(By.Id("pedit_interests_games"), "FavouriteGames");
                _txbFavouriteGames.ScrollToElement();
                _txbFavouriteGames.SetText(text);
                var _txbFavouriteAbout = new TextBox(By.Id("pedit_interests_about"), "FavouriteAbout");
                _txbFavouriteAbout.SetText(text);
                var _txbFavouriteQuotes = new TextBox(By.Id("pedit_interests_quotes"), "FavouriteQuotes");
                _txbFavouriteQuotes.SetText(text);
                Thread.Sleep(500);
                var _btnSave = new Button(By.XPath("//button[contains(@class, 'flat_button button_big_width')]"), "Save button");
                if (_btnSave.IsDisplayed())
                {
                    _btnSave.Click();
                }
                Thread.Sleep(1000);
            }
            else
            {
                _txbActivities.Clear();
                _txbIntrests.Clear();
                _txbFavouriteMusic.Clear();
                _txbFavouriteMovies.ScrollToElement();
                Thread.Sleep(700);
                _txbFavouriteMovies.Clear();
                var _txbFavouriteTV = new TextBox(By.Id("pedit_interests_tv"), "FavouriteTv");
                _txbFavouriteTV.Clear();
                var _txbFavouriteBooks = new TextBox(By.Id("pedit_interests_books"), "FavouriteBooks");
                _txbFavouriteBooks.Clear();
                Thread.Sleep(700);
                var _txbFavouriteGames = new TextBox(By.Id("pedit_interests_games"), "FavouriteGames");
                _txbFavouriteGames.ScrollToElement();
                _txbFavouriteGames.Clear();
                var _txbFavouriteAbout = new TextBox(By.Id("pedit_interests_about"), "FavouriteAbout");
                _txbFavouriteAbout.Clear();
                var _txbFavouriteQuotes = new TextBox(By.Id("pedit_interests_quotes"), "FavouriteQuotes");
                _txbFavouriteQuotes.Clear();
                Thread.Sleep(500);
                var _btnSave = new Button(By.XPath("//button[contains(@class, 'flat_button button_big_width')]"), "Save button");
                if (_btnSave.IsDisplayed())
                {
                    _btnSave.Click();
                }
                Thread.Sleep(1000);
            }

        }
    }
}
