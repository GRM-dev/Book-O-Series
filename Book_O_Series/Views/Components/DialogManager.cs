using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_O_Series.Core;
using Xamarin.Forms;

namespace Book_O_Series.Views.Components
{
    public class DialogManager : IDialogManager
    {
        public void ShowWarningDialog(string header, string message)
        {
            var app = Application.Current as App;
            Device.BeginInvokeOnMainThread(async () =>
            {
                await app.MainPage.DisplayAlert(header, message, "Zamknij");
            });
        }
    }
}
