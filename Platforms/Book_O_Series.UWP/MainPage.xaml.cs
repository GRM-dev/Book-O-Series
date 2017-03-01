using Xamarin.Forms.Platform.UWP;

namespace Book_O_Series.UWP
{
    public sealed partial class MainPage : WindowsPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new Book_O_Series.App());
        }
    }
}
