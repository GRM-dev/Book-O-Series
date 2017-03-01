using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Book_O_Series.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public MenuViewModel(Page page) : base(page)
        {
            Title = "Main Menu";
        }
    }
}
