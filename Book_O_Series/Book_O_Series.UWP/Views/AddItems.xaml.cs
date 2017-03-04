using Book_O_Series.Helpers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Book_O_Series.Models;
using Book_O_Series.ViewModels;

namespace Book_O_Series.UWP.Views
{
    public sealed partial class AddItems : Page
    {
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            BrowseViewModel = (ItemsViewModel)e.Parameter;
        }

        public AddItems()
        {
            InitializeComponent();
        }

        private async void SaveItem_Click(object sender, RoutedEventArgs e)
        {
            var item = new Item
            {
                Text = txtText.Text,
                Description = txtDesc.Text
            };
            await BrowseViewModel.AddItem(item);
            Frame.GoBack();
        }

        public ItemsViewModel BrowseViewModel { get; set; }
    }
}