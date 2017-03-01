using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Book_O_Series.Core
{
    public abstract class BosApp : Application
    {
        public static double ScreenWidth;
        public static double ScreenHeight;

        protected BosApp()
        {
        }

        public abstract void NavigateToModal(ContentPage modal);
        public abstract void NavigateToPage(Page page, bool removePrevious = false);
        public abstract void NavigateToMain(NavPageType pageType, string title);
        public abstract void NavigateBack();
        public IDialogManager DialogManager { get; protected set; }
        public BosCore DataCore { get; protected set; }
        protected Dictionary<NavPageType, Page> MainPages { get; } = new Dictionary<NavPageType, Page>();
    }
}
