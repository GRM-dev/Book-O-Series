using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Book_O_Series.Views
{
    class MenuOption:StackLayout
    {
        public MenuOption(Image image,string text)
        {
            StackLayout stackLayout = new StackLayout{
                Orientation = StackOrientation.Horizontal,
            };

        }
    }
}
