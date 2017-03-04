using Book_O_Series.Helpers;
using Book_O_Series.Models;
using Book_O_Series.Services;

namespace Book_O_Series.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        private bool _isBusy;

        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        private string _title = string.Empty;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <summary>
        /// Get the azure service instance
        /// </summary>
        public IDataStore<Item> DataStore => ServiceLocator.Instance.Get<IDataStore<Item>>();
    }
}

