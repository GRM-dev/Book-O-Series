using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_O_Series.Core;
using Book_O_Series.Core.Utils;
using Xamarin.Forms;

namespace Book_O_Series.Views.Components
{
    public class MenuPageItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public string Detail { get; set; }
        public ImageSource IconProperty => ImageResourceExtension.GetEmbeddedImage(IconSource);
        public NavPageType TargetType { get; set; }
    }
}
