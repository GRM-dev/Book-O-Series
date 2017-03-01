using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_O_Series.Core;
using Book_O_Series.Views.Components;
using Book_O_Series.Views.Pages;
using Xamarin.Forms;

namespace Book_O_Series
{
    public partial class App : BosApp
    {
        private readonly Color _mainBgColor = Color.FromRgb(169, 169, 169);
        private readonly Color _menuBgColor = Color.FromRgb(95, 158, 160);
        private readonly Color _topBarColor = Color.FromRgb(95, 158, 160);
        private readonly Color _topBarTextColor = Color.FromRgb(byte.MaxValue, byte.MaxValue, byte.MaxValue);
        private MasterDetailPage _mdp;
        private bool _isOnMain;
        private NavPageType _lastType = NavPageType.MainPage;

        public App() : base()
        {
            _mdp = new MasterDetailPage
            {
                Master = new MenuPage
                {
                    BackgroundColor = _menuBgColor,
                    IsBusy = true,
                    IsDisabled = true
                },
                Detail = new ContentPage(),
                MasterBehavior = MasterBehavior.Popover
            };
            MainPage = _mdp;
            try
            {
                DialogManager = new DialogManager();
                DataCore = new BosCore(this);
                NavigateToMain(NavPageType.MainPage, "Book-o-Series");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            var menuPage = (MenuPage)((MasterDetailPage)MainPage).Master;
            menuPage.IsBusy = false;
            menuPage.IsDisabled = false;
        }

        protected override void OnStart()
        {
            NavigateToMain(NavPageType.MainPage, "Book-o-Series");
            try
            {
#if DEBUG
                //NavigateToMain(NavPageType., "");
#else
                ((MasterDetailPage)MainPage).IsPresented = true;
#endif
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("Sleeping");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("Resuming");
            if (MainPage != _mdp)
            {
                MainPage = _mdp;
            }
            if (_isOnMain)
            {
                NavigateTo(NavPageType.MainPage, "Book-o-Series");
            }
            else
            {
                NavigateTo(_lastType);
            }
        }

        public void OnDestroy()
        {
            MainPage = new ContentPage();
        }

        public override async void NavigateToModal(ContentPage modal)
        {
            await NavPage.PushAsync(modal);
        }

        public override async void NavigateToPage(Page page, bool removePrevious = false)
        {
            if (NavPage.CurrentPage == page)
            {
                NavPage.Title = page.Title;
            }
            else
            {
                if (removePrevious)
                {
                    await NavPage.PopAsync(false);
                }
                await NavPage.PushAsync(page);
            }
        }

        public override void NavigateToMain(NavPageType pageType, string title)
        {
            NavigateTo(pageType, "Book-o-Series", false);
        }

        public override void NavigateBack()
        {
            NavPage.PopAsync();
        }

        private async void NavigateTo(NavPageType pageType, string title = null, bool inner = true)
        {
            var newPage = GetPage<Page>(pageType, title);
            if (newPage != null)
            {
                _isOnMain = pageType == NavPageType.MainPage || pageType == NavPageType.AboutPage;
                _lastType = pageType;
                if (inner)
                {
                    await NavPage.PushAsync(newPage);
                }
                else
                {
                    NavPage = new NavigationPage(newPage)
                    {
                        Title = newPage.Title,
                        BarBackgroundColor = _topBarColor,
                        BarTextColor = _topBarTextColor,
                        BackgroundColor = _mainBgColor
                    };
                    _mdp.Detail = NavPage;
                }
                _mdp.IsPresented = false;
            }
        }

        public T GetPage<T>(NavPageType pageType, string title = null)
        {
            try
            {
                Page page = GetMainPage(pageType);
                if (!string.IsNullOrWhiteSpace(title) && page.Title != title)
                {
                    page.Title = title;
                }
                if (page != null)
                {
                    return (T)(object)page;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return default(T);
        }

        private Page GetMainPage(NavPageType pageType)
        {
            return !MainPages.ContainsKey(pageType) ? CreatePage(pageType) : MainPages[pageType];
        }

        private Page CreatePage(NavPageType pageType)
        {
            Page page;
            Type type;
            switch (pageType)
            {
                case NavPageType.MainPage:
                    type = typeof(MainPage);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pageType), pageType, null);
            }
                page = Activator.CreateInstance(type) as Page;
                MainPages.Add(pageType, page);
            return page;
        }

        private NavigationPage NavPage { get; set; }
    }
}
