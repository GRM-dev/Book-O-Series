using Book_O_Series.Views.Pages;
using Xamarin.Forms;

namespace Book_O_Series.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {

        public MainViewModel(Page page) : base(page)
        {
            Title = "Book-o-Series";
        }
    }
}