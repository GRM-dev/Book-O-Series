using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_O_Series.Core;
using Book_O_Series.ViewModels;
using Book_O_Series.Views.Components;
using Xamarin.Forms;

namespace Book_O_Series.Views.Pages
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = new MenuViewModel(this);
            MasterPageItems = new List<MenuPageItem>
            {
                new MenuPageItem
                {
                    Title = "Strona Startowa",
                    Detail = "Home",
                    IconSource = "Book_O_Series.Core.Resources.home.png",
                    TargetType = NavPageType.MainPage
                }
            };

            listView.ItemsSource = MasterPageItems;
            listView.ItemSelected += ListViewOnItemSelected;
        }

        private void ListViewOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuPageItem;
            if (item == null)
            {
                return;
            }
            ListView.SelectedItem = null;
            Debug.WriteLine("By menu Page changed to: " + item.Title);
            BosCore.Current.App.NavigateToMain(item.TargetType, item.Title);
        }

        public ListView ListView => listView;
        public List<MenuPageItem> MasterPageItems { get; }

        public bool IsDisabled
        {
            get { return !IsEnabled; }
            set
            {
                IsEnabled = !value;
                listView.IsEnabled = !value;
            }
        }
    }
}
