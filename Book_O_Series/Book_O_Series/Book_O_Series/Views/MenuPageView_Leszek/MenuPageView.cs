using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Book_O_Series.Views
{
    public class MenuPageView : ContentPage
    {
        private Grid _globalGrid;
        private Button _menuButton;
        private MenuBaner _menuBaner;
        private Image _backgroundImage;

        public MenuPageView()
        {
            //wczytanie tła
            _backgroundImage = new Image{
                Source = ImageSource.FromResource("Book_O_Series.Images.wallPaper.png"),
                Aspect = Aspect.AspectFill
            };
            //stworzenie tego banera menu
            _menuBaner = new MenuBaner {
                BackgroundColor = new Color(0.5F, 0.9F, 0.79F, 0.69F),
            };

            //stworzenie grida 11x21(tak naprawdę to 10x20 ale musiałem dla każdego z pierwszych dać auto bo coś nie stykało
            _globalGrid = new Grid{
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowSpacing = 0,
                ColumnSpacing = 0,
                Padding = new Thickness(0, 0, 0, 0),
                RowDefinitions = {
                    new RowDefinition{Height = GridLength.Auto},
                },
                ColumnDefinitions = {
                    new ColumnDefinition{Width = GridLength.Auto},
                },
            };

            for(int i=0;i<20; i++)
            {
                
                _globalGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                if (i % 2 == 0)
                    _globalGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            //tymczasowy przycisk aktywacji menu 
            _menuButton = new Button{
                Text = "menu",
            };

            _menuButton.Clicked += _menuBaner.onMenuButtonClick;


            _globalGrid.Children.Add(_backgroundImage, 1, 11, 1, 21);
            _globalGrid.Children.Add(_menuBaner,6,11,2,11);
            _globalGrid.Children.Add(_menuButton, 1, 11, 1, 2);

            Content = _globalGrid;
        }

        


    }
}
