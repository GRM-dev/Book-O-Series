using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Book_O_Series.Views
{
    class MenuOption:StackLayout
    {   //niedokończone

        public MenuOption(Image image,string text)
        {
            StackLayout stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
            };
            
            Label label = new Label
            {
                Text = text,
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Image icon = new Image
            {
                Source = image.Source,
            };
            icon.HorizontalOptions = LayoutOptions.Center;
            icon.VerticalOptions = LayoutOptions.Center;
            icon.WidthRequest = label.FontSize;
            icon.HeightRequest = label.FontSize;

            BoxView separator = new BoxView
            {
                Color = Color.Gray,
                HorizontalOptions = LayoutOptions.Fill,
                HeightRequest = 2.0F,
                
            };

            stackLayout.Children.Add(icon);
            stackLayout.Children.Add(label);
            this.Children.Add(stackLayout);
            this.Children.Add(separator);

        }
    }
}
