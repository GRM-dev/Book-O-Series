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
       
        private bool _isOff;
        private bool _isAnimated;


        public MenuBaner()
        {
            this._isOff = true;
            this._isAnimated = false;
            this.IsVisible = false;

            Image image = new Image
            {
                Source = ImageSource.FromResource("Book_O_Series.Images.userIcon.png"),
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            StackLayout stackLayout = new StackLayout();

            stackLayout.Children.Add(new MenuOption(image,"name"));
            stackLayout.Children.Add(new MenuOption(image, "option1"));
            stackLayout.Children.Add(new MenuOption(image, "option2"));
            stackLayout.Children.Add(new MenuOption(image, "option3"));
            stackLayout.Children.Add(new MenuOption(image, "option4"));
            stackLayout.Children.Add(new MenuOption(image, "option1"));
            stackLayout.Children.Add(new MenuOption(image, "option2"));
            stackLayout.Children.Add(new MenuOption(image, "option3"));
            stackLayout.Children.Add(new MenuOption(image, "option4"));
            stackLayout.Children.Add(new MenuOption(image, "option1"));
            stackLayout.Children.Add(new MenuOption(image, "option2"));
            stackLayout.Children.Add(new MenuOption(image, "option3"));
            stackLayout.Children.Add(new MenuOption(image, "option4"));

            this.Orientation = StackOrientation.Vertical;
            this.Children.Add(new ScrollView { VerticalOptions = LayoutOptions.FillAndExpand, Content = stackLayout });
            this.VerticalOptions = LayoutOptions.Fill;
            this.HorizontalOptions = LayoutOptions.Fill;
            this.Padding = new Thickness(5, 5, 5, 5);
        }

        // handler który odpowiada za pojawienie i zniknięcie menu
        public void onMenuButtonClick(Object sender, EventArgs e)
        {

            if (_isOff && !this._isAnimated)
            {
                this.TranslationX = 600;
                this.RotationY = 180;
                this.IsVisible = true;
                this._isAnimated = true;
                Device.StartTimer(TimeSpan.FromMilliseconds(1), () => {
                    if (this.TranslationX > 0)
                    {
                        this.TranslationX -= 10 + this.TranslationX / 5;
                        this.RotationY -= 3 + this.RotationY / 5;
                        return true;
                    }
                    else
                    {
                        this.TranslationX = 0;
                        this.RotationY = 0;
                        this._isAnimated = false;
                        return false;
                    }
                    
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
                        this._isAnimated = false;
                        return false;
                    }

                });

                _isOff = true;
            }
        }
    }
}
