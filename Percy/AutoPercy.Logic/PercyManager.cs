using System;
using System.Collections.Generic;
using System.Configuration;
using WatiN.Core;

namespace AutoPercy.Logic
{
    public class PercyManager
    {
        private static PercyManager _instance;
        private Browser _ieMain;
        private Browser _ieSearch;
        private IDictionary<string, string> _appSettings;

        private PercyManager()
        {
            Settings.AutoStartDialogWatcher = false;
            Settings.HighLightElement = false;
            Settings.AutoMoveMousePointerToTopLeft = false;

            //_ieMain = new IE();
            //_ieSearch = new IE();
        }

        public IDictionary<string, string> AppSettings
        {
            get
            {
                if (_appSettings == null)
                {
                    var appSettings = ConfigurationManager.AppSettings;

                    _appSettings = new Dictionary<string, string>(3);
                    _appSettings.Add("Login.UserName", appSettings.Get("Login.UserName"));
                    _appSettings.Add("Login.Password", appSettings.Get("Login.Password"));
                    _appSettings.Add("Percy.Url", appSettings.Get("Percy.Url"));
                }

                return _appSettings;
            }
        }

        public static PercyManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PercyManager();
                }

                return _instance;
            }
        }

        internal Browser IeMain
        {
            get
            {
                if (_ieMain == null)
                {
                    _ieMain = new IE();
                }
                return _ieMain;
            }
        }

        internal Browser IeSearch
        {
            get
            {
                if (_ieSearch == null)
                {
                    _ieSearch = new IE();
                }
                return _ieSearch;
            }
        }

        public void OpenSite()
        {
            string url = AppSettings["Percy.Url"];
            var uri = new Uri(url);
            IeMain.GoTo(uri);
        }

        public void Login()
        {
            Button logout = IeMain.Button(Find.ByValue("Logga ut"));
            if (logout.Exists)
            {
                return;
            }

            string username = AppSettings["Login.UserName"];
            TextField uid = IeMain.TextField(Find.ById("login_email"));
            uid.TypeText(username);

            string password = AppSettings["Login.Password"];
            TextField pwd = IeMain.TextField(Find.ById("login_password"));
            pwd.TypeText(password);

            Button login = IeMain.Button(Find.ByName("login"));
            login.Click();
        }


        public void Logout()
        {
            Button logout = IeMain.Button(Find.ByValue("Logga ut"));
            if (logout.Exists)
            {
                logout.Click();
            }
        }

        public void GotoAddBook()
        {
            Link yours = IeMain.Link(Find.ByText("DINA ANNONSER"));
            yours.Click();

            Link insert = IeMain.Link(Find.ByText("Lägg till"));
            insert.Click();

            RadioButton typ = IeMain.RadioButton(Find.ById("article-input-type-book"));
            typ.Checked = true;
        }

        public void AddBookStep1(string author, string title, string year, string publisher, string format, string isbn, string price, string originalTitle,
                             string quantity, string subTitle, string locClassification, string pages, string language, string genre)
        {
            if(!string.IsNullOrEmpty(locClassification))
            {
                return;
            }

            TextField authorF = IeMain.TextField(Find.ById("book-input-author"));
            authorF.TypeText(author);

            TextField titleF = IeMain.TextField(Find.ById("book-input-title"));
            titleF.TypeText(title);

            TextField isbnF = IeMain.TextField(Find.ById("book-input-standard_number"));
            isbnF.TypeText(isbn); // 10 eller 13 siffror

            if(string.IsNullOrEmpty(price))
            {
                price = "23";
            }
            TextField priceF = IeMain.TextField(Find.ById("book-input-price"));
            priceF.TypeText(price);

            //---

            TextField publisherF = IeMain.TextField(Find.ById("input-publisher"));
            publisherF.TypeText(publisher);

            //  TextField edition = IeMain.TextField(Find.ById("input-edition"));
            //  edition.TypeText("upplaga");

            TextField yearF = IeMain.TextField(Find.ById("input-year"));
            yearF.TypeText(year);

            TextField pagesF = IeMain.TextField(Find.ById("input-pages"));
            pagesF.TypeText(pages);

            SelectList bindings = IeMain.SelectList(Find.ById("input-binding_simple"));
            if (format == "Hardcover" || format == "Leather" || format == "Pansarband")
            {
                bindings.Select("Inbunden"); // Häftad, Inbunden, Pocket
            }
            else if (format == "Softcover")
            {
                bindings.Select("Häftad"); 
            }
            else if (format == "Pocket")
            {
                bindings.Select("Pocket"); 
            }

            // TextField bindingd = IeMain.TextField(Find.ById("input-binding_detailed"));
            // bindingd.TypeText("Bindning detaljerad");

            SelectList quality = IeMain.SelectList(Find.ById("input-quality"));
            quality.Select("Gott skick");

            // SelectList cover = IeMain.SelectList(Find.ById("input-protective_cover"));
            // cover.Select("Saknas");

            string other=string.Empty; //= originalTitle + quantity + subTitle + language;
            if (!string.IsNullOrEmpty(subTitle))
            {
                other += " " + subTitle + ". ";
            }
            if (!string.IsNullOrEmpty(originalTitle))
            {
                other += "Orginaltitel: " + other +". ";
            }
            if (!language.Equals("svenska", StringComparison.InvariantCultureIgnoreCase))
            {
                other += " Språk: " + language + ". ";
            }
            if (format=="Pansarband")
            {
                other += " Biblioteksband. ";
            }


            TextField otherF = IeMain.TextField(Find.ById("input-other"));
            otherF.TypeText(other);
            
            SelectList formatF = IeMain.SelectList(Find.ById("book-input-format"));
            if (format == "Magazine")
            {
                formatF.Select("Tidningar, tidskrifter");
            }
            else if (genre == "Noter")
            {
                formatF.Select("Noter");
            }
            else
            {
                formatF.Select("Begagnade böcker");
            }

            SelectList category = IeMain.SelectList(Find.ById("book-input-bbcategory"));
            category.Select(genre);



            Button next = IeMain.Button(Find.ByValue("Fortsätt"));
            //next.Click();
        }

        public void AddBookStep2()
        {
            throw new NotImplementedException();
        }

        public void PercyTitle(string author, string title)
        {
            string baseurl = AppSettings["Percy.Url"];

            string url =
                "{0}/page-start?issearch=1&sall=1&scat=0&maincat=1&extendedsearch=1&mediatype=0&sallstr=&screator={1}&stitle={2}";
            string url2 = string.Format(url, baseurl, author, title);
            string url3 = Uri.EscapeUriString(url2);
            IeSearch.GoTo(url3);
        }
    }
}
