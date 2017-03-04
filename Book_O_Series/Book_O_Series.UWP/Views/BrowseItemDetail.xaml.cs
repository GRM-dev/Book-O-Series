using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Book_O_Series.Models;
using Book_O_Series.ViewModels;

namespace Book_O_Series.UWP.Views
{
    public sealed partial class BrowseItemDetail : Page
    {
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel = new ItemDetailViewModel((Item)e.Parameter);
            DataContext = ViewModel;
        }

        public BrowseItemDetail()
        {
            InitializeComponent();
        }

        public ItemDetailViewModel ViewModel { get; set; }
    }
}