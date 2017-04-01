using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
namespace Book_O_Series.Views
{
    class MenuBaner:StackLayout
    {
        static public Label _accuntData;
        static public Label _options;
        private bool _isOff;
        private bool _isAnimated;


        public MenuBaner()
        {
            _isOff = true;
            _isAnimated = false;
            this.IsVisible = false;
            StackLayout stackLayout = new StackLayout();
            stackLayout.Orientation = StackOrientation.Horizontal;
            stackLayout.Children.Add(new Image {
                Source = ImageSource.FromResource("Book_O_Series.Images.userIcon.png"),
                HorizontalOptions = LayoutOptions.CenterAndExpand
            });
            stackLayout.Children.Add(new Label
            {
                Text = "SampeText",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            });
            (stackLayout.Children[0] as Image).WidthRequest = (stackLayout.Children[1] as Label).FontSize;
            (stackLayout.Children[0] as Image).HeightRequest = (stackLayout.Children[1] as Label).FontSize;

            this.Orientation = StackOrientation.Vertical;
            this.Children.Add(stackLayout);
            this.VerticalOptions = LayoutOptions.Fill;
            this.HorizontalOptions = LayoutOptions.Fill;
            this.Padding = new Thickness(5, 5, 5, 5);
        }
        public void onMenuButtonClick(Object sender, EventArgs e)
        {
            // _globalGrid.Children[1].IsVisible = false;

            if (_isOff && !this._isAnimated)
            {
                this.TranslationX = 600;
                this.IsVisible = true;
                this._isAnimated = true;
                Device.StartTimer(TimeSpan.FromMilliseconds(1), () => {
                    if (this.TranslationX > 0)
                    {
                        this.TranslationX -= 10 + this.TranslationX / 5;
                        return true;
                    }
                    else
                        this.TranslationX = 0;
                    this._isAnimated = false;
                    return false;
                });

                _isOff = false;
            }
            if (!_isOff && !this._isAnimated)
            {
                this._isAnimated = true;
                Device.StartTimer(TimeSpan.FromMilliseconds(1), () => {
                    if (this.TranslationX < 600)
                    {
                        this.TranslationX += 10 + this.TranslationX / 5;
                        return true;
                    }
                    else
                    {
                        this.IsVisible = false;
                        this.TranslationX = 0;
                        this._isAnimated = false;
                        return false;
                    }

                });

                _isOff = true;
            }
        }
    }
}
