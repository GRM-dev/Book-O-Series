using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using Xamarin.Forms;

namespace Book_O_Series.ViewModels
{
    public class ViewModelBase : BaseViewModel
    {
        public ViewModelBase(Page page)
        {
            Page = page;
        }

        public Page Page { get; }
    }
}
