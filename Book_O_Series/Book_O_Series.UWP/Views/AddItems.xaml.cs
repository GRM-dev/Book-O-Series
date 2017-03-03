﻿using Book_O_Series.Helpers;
using Book_O_Series.Model;
using Book_O_Series.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Book_O_Series.UWP.Views
{
    public sealed partial class AddItems : Page
    {
        ItemsViewModel BrowseViewModel { get; set; }

        public AddItems()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            BrowseViewModel = (ItemsViewModel)e.Parameter;
        }

        private async void SaveItem_Click(object sender, RoutedEventArgs e)
        {
            var _item = new Item();
            _item.Text = txtText.Text;
            _item.Description = txtDesc.Text;
            await BrowseViewModel.AddItem(_item);

            this.Frame.GoBack();
        }
    }
}